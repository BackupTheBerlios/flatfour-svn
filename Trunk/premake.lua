project.name = "FlatFour"


-- Build Options 

	addoption("no-bootstrap", "Exclude bootstrap application")
	addoption("no-editor",    "Exclude the editor application")
	addoption("no-graphics",  "Exclude graphics subsystem")
	addoption("no-platform",  "Exclude platform abstraction subsystem")
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

	dopackage("Framework/FlatFour")

	if (not options["no-graphics"]) then
		dopackage("Framework/FlatFour.Graphics")
	end
	
	if (not options["no-platform"]) then
		dopackage("Framework/FlatFour.Platform")
	end


	if (options["with-toolkit"]) then
		dopackage("Framework/Libs/GameGuts/code/toolkit")
	end
	

-- Support Functions

	function doclean(cmd, arg)
		docommand(cmd, arg)
	end
