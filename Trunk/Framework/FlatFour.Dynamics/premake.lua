package.name = "FlatFour.Dynamics"
package.kind = "dll"
package.language = "c#"

package.links = 
{
	"GameGuts.NET",
	"ode.net"
}

package.files = 
{
	matchrecursive("*.cs")
}

configure_package()
