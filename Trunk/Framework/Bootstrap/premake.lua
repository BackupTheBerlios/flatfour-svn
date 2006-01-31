package.name = "Bootstrap"
package.target = "start"
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
	"System"
}

package.files =
{
	matchfiles("*.cs")
}
