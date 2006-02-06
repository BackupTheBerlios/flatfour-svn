package.name = "FlatFour.Tests"
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
	"FlatFour",
	"nunit.framework"
}

package.files = 
{
	matchrecursive("*.cs")
}
