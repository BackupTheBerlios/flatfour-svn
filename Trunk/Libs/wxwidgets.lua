package.name = "wxWidgets"
package.path = "wxWidgets"
package.kind = "lib"
package.language = "c++"


-- Build Settings

	package.buildflags =
	{
		"no-64bit-checks"
	}
	
	package.includepaths = 
	{
		"include",
		"../include",
		"src/jpeg",
		"src/png",
		"src/tiff",
		"src/zlib"
	}


-- Defined Symbols
	
	package.defines = 
	{
		"_LIB"
	}
	
	package.config["Debug"].defines =
	{
		"_DEBUG",
		"__WXDEBUG__"
	}

	if (windows) then
		table.insert(package.defines, { "WIN32", "__WXMSW__", "__WIN95__" })
	end
	

-- Files

	package.files = 
	{
		matchfiles("src/common/*.cpp"),
		matchfiles("src/generic/*.cpp"),
		matchfiles("src/html/*.cpp"),
		matchfiles("src/jpeg/*.c"),
		matchfiles("src/png/*.c"),
		matchfiles("src/tiff/*.c"),
		matchfiles("src/xml/*.cpp")
	}

	package.excludes =
	{
		-- These should be excluded from all builds
		"src/common/execcmn.cpp",
		"src/jpeg/jmemansi.c",
		"src/jpeg/jmemdos.c",
		"src/jpeg/jmemmac.c",
		"src/jpeg/jmemname.c",
		"src/jpeg/jpegtran.c",
		"src/png/ansi2knr.c",
		"src/png/pngtest.c",
		"src/tiff/fax3sm_winnt.c",
		"src/tiff/mkg3states.c",
		"src/tiff/mkspans.c",
		"src/tiff/mkversion.c",
		"src/tiff/tif_acorn.c",
		"src/tiff/tif_apple.c",
		"src/tiff/tif_atari.c",
		"src/tiff/tif_msdos.c",
		"src/tiff/tif_os2.c",
		"src/tiff/tif_unix.c",
		"src/tiff/tif_vms.c",
		"src/tiff/tif_win3.c",
		
		-- Windows only?
		"src/generic/msgdlgg.cpp",
		"src/generic/paletteg.cpp"
	}
		
	if (windows) then
		table.insert(package.files, matchfiles("src/msw/*.cpp", "src/msw/ole/*.cpp"))
	end
	
