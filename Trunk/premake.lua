project.name = "FlatFour"


-- Build Options 

	addoption("no-bootstrap", "Exclude bootstrap application")
	addoption("no-collision", "Exclude the collision subsystem")
	addoption("no-dynamics",  "Exclude the dynamics subsystem")
	addoption("no-editor",    "Exclude the editor application")
	addoption("no-graphics",  "Exclude graphics subsystem")
	addoption("no-platform",  "Exclude platform abstraction subsystem")
	addoption("no-tests",     "Exclude unit tests")
	addoption("with-toolkit", "Include GameGuts in build (separate download)")


-- Project-wide settings

	project.bindir = "Bin"
	project.libdir = "Framework/Libs"


-- Build system support code

	dofile("Framework/Build/functions.lua")
	
	
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

	if (options["with-toolkit"]) then
		dopackage("Framework/Libs/GameGuts/code/toolkit")
		dopackage("Framework/Libs/GameGuts/bindings/dotnet")
	end
	
	dopackage("Framework/FlatFour")

	if (not options["no-collision"]) then
		dopackage("Framework/FlatFour.Collision")
	end
	
	if (not options["no-dynamics"]) then
		dopackage("Framework/FlatFour.Dynamics")
	end
	
	if (not options["no-graphics"]) then
		dopackage("Framework/FlatFour.Graphics")
	end
	
	if (not options["no-platform"]) then
		dopackage("Framework/FlatFour.Platform")
	end



-- Command Handlers

	function doclean(cmd, arg)
		docommand(cmd, arg)
		os.remove("FlatFour.nunit")
	end

	function dotarget(cmd, arg)
		docommand(cmd, arg)
		setup_nunit()
	end
	
