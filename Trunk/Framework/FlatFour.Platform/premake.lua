package.name = "FlatFour.Platform"
package.kind = "dll"
package.language = "c#"

package.links =
{
	"Sim8.GameGuts"
}

package.files = 
{
	matchrecursive("*.cs")
}

configure_package()
	
