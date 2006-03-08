package.name = "Bootstrap"
package.target = "start"
package.kind = "winexe"
package.language = "c#"

package.links =
{
	"System.Drawing",
	"FlatFour.Platform",
	"FlatFour.Graphics",
	"FlatFour.Collision"
}

package.files =
{
	matchrecursive("*.cs")
}

configure_package()
