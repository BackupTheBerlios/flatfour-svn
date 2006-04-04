package.name = "FlatFour.Editor"
package.kind = "winexe"
package.language = "c#"

package.links =
{
	"System.Drawing",
	"System.Windows.Forms",
	"FlatFour.Graphics",
	"NUnitForms"
}

package.files =
{
	matchrecursive("*.cs", "*.resx", "*.settings")
}

configure_package()
