package.name = "wx-c"
package.path = "wx.NET"
package.kind = "dll"
package.language = "c++"


-- Build Settings

	package.buildflags =
	{
		"no-64bit-checks",
		"no-import-lib"
	}

	package.config["Release"].buildflags =
	{
		"optimize-size",
		"no-symbols",
		"no-frame-pointer"
	}
	
	package.includepaths = 
	{
		"../include",
		"../wxWidgets/include"
	}

-- On non-Windows platforms, you need to run ./configure first to build
-- a setup.h for the platform. Eventually I'll try to get rid of this step

	if (not windows) then
		setup_h = matchrecursive("../wxWidgets/lib/setup.h")
		if (table.getn(setup_h) == 0) then
			error("setup.h not found; please run wxWidgets/configure")
		end
		
		setup_path = path.getdir(setup_h[1])
		table.insert(package.includepaths, setup_path)
	end

	if (linux) then
		package.buildoptions = 
		{ 
			"-Wall",
			"-Wundef",
			"-DNO_GCC_PRAGMA",
			"-DGTK_NO_CHECK_CASTS"
		}
	end

-- Defined Symbols

	package.config["Debug"].defines =
	{
		"_DEBUG",
		"__WXDEBUG__"
	}
	
	if (windows) then
		table.insert(package.defines, { "__WXMSW__", "_WINDOWS", "WIN32" })
	end

	if (linux) then
		table.insert(package.defines, { "__WXGTK__" })
	end
	
	
-- Libraries

	package.links =
	{
		"wxWidgets"
	}
	
	msw_links =
	{
		"comctl32",
		"rpcrt4",
		"wsock32",
		"oleacc",
		"odbc32"
	}
	
	if (windows) then
		table.insert(package.links, msw_links)
	end
	
-- Files

	package.files = 
	{
		matchfiles("Src/wx-c/*.cxx")
	}
