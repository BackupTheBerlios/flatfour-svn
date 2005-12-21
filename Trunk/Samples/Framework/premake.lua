package.name = "Samples.Framework"
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
	"Straight8.Framework"
}

package.files =
{
	matchfiles("*.cs")
}
