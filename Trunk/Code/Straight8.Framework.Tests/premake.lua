package.name = "Straight8.Framework.Tests"
package.kind = "dll"
package.language = "c#"


-- Flags and Settings

	package.defines =
	{
		"TRACE"
	}

	package.config["Debug"].defines =
	{
		"DEBUG"
	}


-- Links

	package.libpaths =
	{
		"../Libs"
	}
	
	package.links = 
	{
		"System",
		"System.Drawing",
		"nunit.framework",
		"Straight8.Framework",
	}


-- Files

	package.files =
	{
		matchfiles("*.cs", "*.resx"),
		matchfiles("CoreTests/*.cs"),
		matchfiles("GraphicsTests/*.cs"),
		matchfiles("PlatformTests/*.cs"),
		matchfiles("Utils/*.cs")
	}
