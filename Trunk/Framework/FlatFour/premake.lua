package.name = "FlatFour"
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
	"System.Drawing",
	"System.Xml" 
}

package.files = 
{
	matchfiles("*.cs")
}


-- Unit test support

	enable_tests()
