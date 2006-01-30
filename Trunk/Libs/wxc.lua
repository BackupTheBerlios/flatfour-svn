package.name = "wx-c"
package.path = "wx.NET"
package.kind = "dll"
package.language = "c++"


-- Build Settings

	package.buildflags =
	{
		"no-64bit-checks"
	}

	package.includepaths = 
	{
		"../include",
		"../wxWidgets/include"
	}


-- Defined Symbols

	if (windows) then
		table.insert(package.defines, "_WINDOWS")
	end

	
-- Libraries

	package.links =
	{
		"wxWidgets"
	}
	
	
-- Files

	package.files = 
	{
		matchfiles("Src/wx-c/*.cxx")
	}