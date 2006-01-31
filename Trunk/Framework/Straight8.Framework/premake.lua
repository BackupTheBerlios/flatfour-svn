package.name = "Straight8.Framework"
package.kind = "dll"
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
	"System.Xml" 
}

package.files = 
{
	matchfiles("*.cs"),
	matchfiles("Core/*.cs"),
	matchfiles("Graphics/*.cs"),
	matchfiles("Internals/*.cs"),
	matchfiles("Math/*.cs"),
	matchfiles("Platform/*.cs")
}
