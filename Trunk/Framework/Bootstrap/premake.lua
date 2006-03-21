package.name = "Bootstrap"
package.target = "start"
package.kind = "winexe"
package.language = "c#"

package.links =
{
	"System.Drawing",
	"FlatFour.Platform",
	"FlatFour.Graphics",
	
	-- Remove these!
	"FlatFour.Collision",
	"FlatFour.Dynamics"
}

package.files =
{
	matchrecursive("*.cs")
}

configure_package()
