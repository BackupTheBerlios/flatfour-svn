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


-- Defined Symbols

	package.config["Debug"].defines =
	{
		"_DEBUG",
		"__WXDEBUG__"
	}
	
	if (windows) then
		table.insert(package.defines, { "__WXMSW__", "_WINDOWS", "WIN32" })
	end

	
-- Libraries

	package.links =
	{
		"wxWidgets",
		"comctl32",
		"rpcrt4",
		"wsock32",
		"oleacc",
		"odbc32"
	}
	
	
-- Files

	package.files = 
	{
		matchfiles("Src/wx-c/*.cxx")
	}