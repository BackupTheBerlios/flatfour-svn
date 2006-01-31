package.name = "wxWidgets"
package.path = "wxWidgets"
package.kind = "lib"
package.language = "c++"


-- Build Settings

	package.buildflags =
	{
		"no-64bit-checks"
	}
	
	package.config["Release"].buildflags =
	{
		"optimize-size",
		"no-symbols",
		"no-frame-pointer"
	}
	
	package.includepaths = 
	{
		"include",
		"../include",
		"src/expat/lib",
		"src/jpeg",
		"src/png",
		"src/tiff",
		"src/zlib"
	}


-- Defined Symbols
	
	package.defines = 
	{
		"_LIB",
		"COMPILED_FROM_DSP"
	}
	
	package.config["Debug"].defines =
	{
		"_DEBUG",
		"__WXDEBUG__"
	}

	if (windows) then
		table.insert(package.defines, { "WIN32", "__WXMSW__" })
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
		matchfiles("src/expat/lib/*.c"),
		matchfiles("src/xml/*.cpp"),
		matchfiles("src/xrc/*.cpp"),
		matchfiles("src/zlib/*.c")
	}

	package.excludes =
	{
		-- These should be excluded from all builds
		"src/common/execcmn.cpp",
		"src/expat/lib/xmltok_impl.c",
		"src/expat/lib/xmltok_ns.c",
		"src/jpeg/ansi2knr.c",
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
		"src/zlib/example.c",
		"src/zlib/minigzip.c",
		
		-- Windows only?
		"src/generic/accel.cpp",
		"src/generic/caret.cpp",
		"src/generic/fdrepdlg.cpp",
		"src/generic/imaglist.cpp",
		"src/generic/listctrl.cpp",
		"src/generic/msgdlgg.cpp",
		"src/generic/notebook.cpp",
		"src/generic/paletteg.cpp",
		"src/generic/statline.cpp",
		"src/generic/timer.cpp"
	}
		
	if (windows) then
		table.insert(package.files, matchfiles("src/msw/*.cpp", "src/msw/ole/*.cpp"))
	end
	
