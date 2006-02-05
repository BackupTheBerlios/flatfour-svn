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
		"../include",
		"include",
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

	if (linux) then
		table.insert(package.defines, { "__WXGTK__" })
	end
		

-- On non-Windows platforms, you need to run ./configure first to build
-- a setup.h for the platform. Eventually I'll try to get rid of this step

	if (not windows) then
		setup_h = matchrecursive("lib/setup.h")
		if (table.getn(setup_h) == 0) then
			error("setup.h not found; please run wxWidgets/configure")
		end
		table.insert(package.includepaths, "lib/wx/include/gtk2-ansi-release-2.6/wx")
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
		"src/zlib/minigzip.c"
	}
	
	msw_excludes =
	{	
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
	
	gtk_excludes =
	{
		"src/generic/notebook.cpp",
		"src/generic/statline.cpp",
		"src/generic/timer.cpp"
	}
		
	if (windows) then
		table.insert(package.files, matchfiles("src/msw/*.cpp", "src/msw/ole/*.cpp"))
		table.insert(package.excludes, msw_excludes)
	end
	
	if (linux) then
		table.insert(package.files, matchfiles("src/gtk/*.cpp"))
		table.insert(package.excludes, gtk_excludes)
	end
	
