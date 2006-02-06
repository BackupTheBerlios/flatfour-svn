-- Configure the current package for unit testing

	nunit_modules = { }
	
	function enable_tests()
		if (not options["no-tests"]) then
			table.insert(package.links, "nunit.framework")
			table.insert(package.files, matchrecursive("Tests/*.cs"))
			if (package.target) then
				table.insert(nunit_modules, package.target)
			else
				table.insert(nunit_modules, package.name)
			end
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

