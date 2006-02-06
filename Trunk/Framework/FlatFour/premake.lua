package.name = "FlatFour"
package.kind = "dll"
package.language = "c#"

package.links = 
{ 
	"System.Drawing",
	"System.Xml" 
}

package.files = 
{
	matchrecursive("*.cs")
}


configure_package()
