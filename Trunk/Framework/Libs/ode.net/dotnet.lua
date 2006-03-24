package.name = "ode.net"
package.kind = "dll"
package.language = "c#"
-- package.objdir = "obj/ode.net"

-- Separate distribution files into toolset subdirectories

--  if (options["usetargetpath"]) then
--    package.path = options["target"]
--  else
--    package.path = "custom"
--  end


-- Build Settings

  package.defines = { "TRACE" }
  package.config["Debug"].defines = { "DEBUG" }

  if (options["with-doubles"]) then
    table.insert(package.defines, "dDOUBLE")
  else
    table.insert(package.defines, "dSINGLE")
  end


-- Files

--  package.files = matchfiles("../../contrib/DotNet/*.cs")
  package.files = matchfiles("*.cs")

