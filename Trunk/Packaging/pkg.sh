#!/bin/bash

script_dir=`pwd`

# Make sure a version is supplied
if [ $# -ne 1 ]; then
	echo 1>&2 Usage: $0 version
	exit 1
fi
echo "PREPARING BUILD $1"
echo ""

echo "WARNING: this script contains temporary code. Fix it before releasing!"
read line
echo ""

# Make sure all prerequisites are met
echo "Is the version ($1) in the format Major.Minor.Build.Revision?"
read line
echo ""
echo "Did you update the required Toolkit version in README?"
read line
echo ""
echo "Did you update the project status in README.txt?"
read line
echo ""
echo "Did you update CHANGES.txt?"
read line
echo ""
echo "Ready to build packages for version $1."
echo "Press [Enter] to begin."
read line


#####################################################################
# Stage 1: Testing
#
# Pull down the source code from Subversion, build it an run all
# of the unit tests. Kill it right here if there are any problems.
#####################################################################

echo ""
echo "RETRIEVING SOURCE CODE FROM REPOSITORY..."
echo ""
cd ../..
# svn co https://starkos.gotdns.org/Svn/Sim8/FlatFour/Tags/$1 FlatFour-$1
premake --with-all --clean  # TEMPORARY
cp -r F4 FlatFour-$1        # TEMPORARY

echo ""
echo "BUILDING TEST VERSION..."
echo ""
pwd
cd FlatFour-$1
premake --with-all --target vs2003
"c:/Program Files/Microsoft Visual Studio .NET 2003/Common7/IDE/devenv.exe" /rebuild Debug FlatFour.sln

echo ""
echo "RUNNING UNIT TESTS..."
echo ""
"c:/Program Files/NUnit 2.2/bin/nunit-console.exe" /nologo Straight8.Framework.nunit
echo "Were the unit tests successful?"
read line


#####################################################################
# Stage 2: Preparation
#
# Update all version numbers and create a tag in the repository.
#####################################################################

echo ""
echo "CLEANING UP..."
echo ""
premake --with-all --clean

echo ""
echo "UPDATING VERSION STRINGS..."
echo ""

build_str=$1
date_str=`date +%F`
year_str=`date +%Y`

sed -e "s/@BUILD@/$build_str/" -e "s/@DATE@/$date_str/" -e "s/@YEAR@/$year_str/" README.txt > README.tmp
mv README.tmp README.txt

cd Code/Straight8.Framework
sed -e "s/AssemblyVersion(\"0.0.0.0\")/AssemblyVersion(\"$build_str\")/" AssemblyInfo.cs > AssemblyInfo.tmp
mv AssemblyInfo.tmp AssemblyInfo.cs
sed -e "s/@YEAR@/$year_str/" AssemblyInfo.cs > AssemblyInfo.tmp
mv AssemblyInfo.tmp AssemblyInfo.cs
cd ../..

echo ""
echo "TAGGING SOURCE CODE..."
echo ""
# svn copy ...


#####################################################################
# Stage 3: Source Code Package
#
# Build the source code package
#####################################################################

echo ""
echo "REMOVING PRIVATE FILES..."
echo ""

rm -rf `find . -name .svn`
rm -rf Packaging
rm -rf Design
rm -rf Docs
rm -f TODO.txt
rm -f TestResult.xml

echo ""
echo "PACKAGING SOURCE CODE..."
echo ""

cd ..
zip -r9 $script_dir/FlatFour-src-$1.zip FlatFour-$1/*


#####################################################################
# Stage 4: Binary Package
#
# Build the binary package
#####################################################################

echo ""
echo "BUILDING RELEASE BINARY..."
echo ""

cd FlatFour-$1
premake --target vs2003
"c:/Program Files/Microsoft Visual Studio .NET 2003/Common7/IDE/devenv.exe" /rebuild Release FlatFour.sln
cd Bin
zip -9 $script_dir/FlatFour-bin-$1.zip Straight8.Framework.dll
cd ../..


#####################################################################
# Stage 5: Publish Files
#
# Send the files to SourceForge
#####################################################################

echo ""
echo "Upload packages to SourceForge?"
read line
if [ $line = "y" ]; then
	echo "Uploading to SourceForge..."
	ftp -n upload.sourceforge.net < pkg_ftp.txt 
fi


#####################################################################
# All done
#####################################################################

echo ""
echo "CLEANING UP..."
echo ""
rm -rf FlatFour-$1

cd $script_dir
echo ""
echo "Done."
