package.name = "FlatFour.Platform"
package.kind = "dll"
package.language = "c#"

package.links =
{
	"System.Drawing",
	"GameGuts.NET"
}

package.files = 
{
	matchrecursive("*.cs")
}

configure_package()
	
