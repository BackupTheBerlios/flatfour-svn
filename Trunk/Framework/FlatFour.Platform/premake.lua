package.name = "FlatFour.Platform"
package.kind = "dll"
package.language = "c#"

package.defines = 
{ 
	"TRACE" 
}

package.config["Debug"].defines =
{
	"DEBUG"
}

package.libpaths =
{
	"../Libs"
}

package.links = 
{ 
	"System",
	"FlatFour"
}

package.files = 
{
	matchfiles("*.cs")
}


-- Unit test support

	enable_tests()
	
