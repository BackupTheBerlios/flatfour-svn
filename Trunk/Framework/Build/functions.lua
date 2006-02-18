
-- Unit testing support 

	nunit_modules = { }
	
	function configure_unittests()
		if (not options["no-tests"]) then
			table.insert(package.links, "nunit.framework")
			if (package.target) then
				table.insert(nunit_modules, package.target)
			else
				table.insert(nunit_modules, package.name)
			end
		else
			table.insert(package.excludes, matchrecursive("Tests/*"))
		end
	end
		
	function setup_nunit()
		if (not options["no-tests"]) then
			file = io.open("FlatFour.nunit", "w")
			file:write('<NUnitProject>\n')
			file:write('  <Settings activeconfig="Debug" />\n')
			file:write('  <Config name="Debug" binpathtype="Auto">\n')

			table.foreach(nunit_modules, function (key,val) file:write('    <assembly path="Bin/' .. val .. '.dll" />\n') end)

			file:write('  </Config>\n')
			file:write('</NUnitProject>\n')
			io.close(file)
		end
	end


-- Configure a new package

	function configure_package()
		-- Standard .NET defines
		table.insert(package.defines, "TRACE")
		table.insert(package.config["Debug"].defines, "DEBUG")
	
		-- Mono's .NET 2.0 support isn't quite there yet. I use this symbol
		-- to block out code that doesn't work there yet
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
		
		-- Enable unit testing
		if (package.language ~= "c" and package.language ~= "c++") then
			configure_unittests()
		end
	end
	