package.name = "Minimal"
package.path = "wxWidgets"
package.kind = "winexe"
package.language = "c++"
package.target = "minimal"

-- Build Settings

	package.buildflags =
	{
		"no-64bit-checks",
		"no-main"
	}
	
	package.includepaths = 
	{
		"include",
		"../include"
	}

	
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
		matchfiles("samples/minimal/*.cpp")
	}

