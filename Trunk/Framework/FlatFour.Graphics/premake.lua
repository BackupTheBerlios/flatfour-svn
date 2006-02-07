package.name = "FlatFour.Graphics"
package.kind = "dll"
package.language = "c#"

package.links = 
{
	"System.Drawing",
	"FlatFour.Platform",
	"GameGuts.NET"
}

package.files = 
{
	matchrecursive("*.cs")
}

configure_package()
