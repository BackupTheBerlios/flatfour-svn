project.name = "FlatFour"


-- Build Options 

	addoption("no-bootstrap", "Exclude bootstrap application")
	addoption("no-editor",    "Exclude the editor application")
	addoption("no-samples",   "Exclude sample applications")
	addoption("no-tests",     "Exclude unit tests")
	addoption("with-toolkit", "Include GameGuts in build (separate download)")


-- Project-wide settings

	project.bindir = "Bin"
	project.libdir = "Code/Libs"


-- Let the user customize their own build environment

	-- if (os.fileexists("user.lua")) then
	--	dofile("user.lua")
	-- end
	

-- Packages

	if (not options["no-editor"]) then
		dopackage("Framework/Editor")
	end
		
	if (not options["no-bootstrap"]) then
		dopackage("Framework/Bootstrap")
	end

	if (not options["no-samples"]) then
		dopackage("Samples/Framework")
	end
	
	if (not options["no-tests"]) then
		dopackage("Framework/Straight8.Framework.Tests")
	end

	dopackage("Framework/Straight8.Framework")

	if (options["with-toolkit"]) then
		dopackage("Framework/Libs/GameGuts/code/toolkit")
	end
	

-- Support Functions

	function doclean(cmd, arg)
		docommand(cmd, arg)
	end
