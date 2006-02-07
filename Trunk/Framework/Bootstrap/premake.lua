package.name = "Bootstrap"
package.target = "start"
package.kind = "winexe"
package.language = "c#"

package.links =
{
	"FlatFour.Platform",
	"FlatFour.Graphics"
}

package.files =
{
	matchrecursive("*.cs")
}

configure_package()
