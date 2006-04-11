package.name = "Carburetor"
package.kind = "winexe"
package.language = "c#"

package.links =
{
	"System.Drawing",
	"System.Windows.Forms",
	"FlatFour.Editing",
	"FlatFour.Graphics",
	"NUnitForms",
	"nmock"
}

package.files =
{
	matchrecursive("*.cs", "*.resx", "*.settings")
}

configure_package()
