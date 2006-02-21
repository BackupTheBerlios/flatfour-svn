package.name = "FlatFour.Graphics"
package.kind = "dll"
package.language = "c#"

package.links = 
{
	"System.Drawing",
	"FlatFour.Platform",
	"GameGuts.NET"
}

if (not options["no-tests"]) then
	table.insert(package.links, "System.Windows.Forms")
end

package.files = 
{
	matchrecursive("*.cs")
}

configure_package()
