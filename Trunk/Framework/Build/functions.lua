function configure_package()

	-- Standard .NET defines
	table.insert(package.defines, "TRACE")
	table.insert(package.config["Debug"].defines, "DEBUG")

	-- Mono's .NET 2.0 support isn't quite there yet. I use this symbol
	-- to block out code that gmcs can't compile yet
	if (options["target"] == "gnu") then
		table.insert(package.defines, "MONO")
	end
	
	-- Add the support libraries directory
	table.insert(package.libpaths, "../Libs")
	
	-- Add the standard Framework libraries
	table.insert(package.links, "System")
	if (package.name ~= "FlatFour") then
		table.insert(package.links, "FlatFour")
	end
	
	-- Configure unit testing
	if (package.language ~= "c" and package.language ~= "c++") then
		if (options["no-tests"]) then
			table.insert(package.excludes, matchrecursive("Tests/*"))
		else
			table.insert(package.links, "nunit.framework")
		end
	end

end
