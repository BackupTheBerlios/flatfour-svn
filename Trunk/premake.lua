project.name = "FlatFour"


-- Build Options 

	addoption("no-samples",   "Exclude sample applications")
	addoption("no-tests",     "Exclude unit tests")
	addoption("with-toolkit", "Include GameGuts in build (separate download)")


-- Project-wide settings

	project.bindir = "Bin"
	project.libdir = "Libs"


-- Packages

	if (not options["no-samples"]) then
		dopackage("Samples/Framework")
	end
	
	if (not options["no-tests"]) then
		dopackage("Code/Straight8.Framework.Tests")
	end

	dopackage("Code/Straight8.Framework")

	if (options["with-toolkit"]) then
		dopackage("Libs/GameGuts/code/toolkit")
	end
	

-- Support Functions

	function doclean(cmd, arg)
		docommand(cmd, arg)
		os.rmdir(project.bindir)
	end
