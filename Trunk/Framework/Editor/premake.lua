package.name = "Editor"
package.target = "editor"
package.kind = "winexe"
package.language = "c#"

package.links =
{
	"System.Drawing",
	"System.Windows.Forms"
}

package.files =
{
	matchrecursive("*.cs", "*.resx", "*.settings")
	--matchfiles("*.cs"),
	--matchfiles("Properties/AssemblyInfo.cs"),
	--matchfiles("Properties/Resources.resx")
}

configure_package()
