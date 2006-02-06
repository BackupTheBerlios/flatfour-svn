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

package.links = 
{ 
	"System", 
	"System.Drawing",
	"System.Xml" 
}

package.files = 
{
	matchrecursive("*.cs")
}
