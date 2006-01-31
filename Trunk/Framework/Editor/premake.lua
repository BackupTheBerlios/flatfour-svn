package.name = "Editor"
package.target = "editor"
package.kind = "winexe"
package.language = "c#"

package.defines =
{
	"TRACE"
}

package.config["Debug"].defines =
{
	"DEBUG"
}

package.links =
{
	"System",
	"System.Drawing",
	"wx.NET"
}

package.files =
{
	matchfiles("*.cs")
}
