package.name = "Editor"
package.target = "editor"
package.kind = "winexe"
package.language = "c#"

package.links =
{
	"System.Drawing",
	"wx.NET"
}

package.files =
{
	matchrecursive("*.cs")
}

configure_package()
