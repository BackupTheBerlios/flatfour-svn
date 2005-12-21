project.name = "FlatFour"


-- Build Options 

	addoption("no-samples", "Exclude sample applications")
	addoption("no-tests", "Exclude unit tests")
	addoption("with-toolkit", "Include GameGuts in build (separate download)")


-- Project-wide settings

project.config["Debug"].bindir = "Bin/Debug"
project.config["Debug"].libdir = "Bin/Debug"

project.config["Release"].bindir = "Bin/Release"
project.config["Release"].libdir = "Bin/Release"


-- Packages

	if (not options["no-samples"]) then
		dopackage("Samples/Framework")
	end
	
	if (not options["no-tests"]) then
		dopackage("Code/Straight8.Framework.Tests")
	end

	dopackage("Code/Straight8.Framework")

	if (options["with-toolkit"]) then
		dopackage("Code/GameGuts/code/toolkit")
	end
	

-- Support Functions

	function doclean(cmd, arg)
		docommand(cmd, arg)
		os.rmdir(project.config["Debug"].bindir)
		os.rmdir(project.config["Release"].bindir)
	end
