package.name = "Editor"
package.target = "editor"
package.kind = "winexe"
package.language = "c#"

package.links =
{
	"System.Drawing",
	"System.Windows.Forms",
	"FlatFour.Graphics"
}

package.files =
{
	matchrecursive("*.cs", "*.resx", "*.settings")
}

configure_package()
