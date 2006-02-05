/****************************************************************************
 * Custom configuration library for Flat Four version of wxWidgets. Only 
 * enables the features actually used by the Flat Four editor and addons.
 ***************************************************************************/

#ifndef _FLATFOUR_SETUP_H_
#define _FLATFOUR_SETUP_H_

/* On non-Windows platforms, load ./configure generated setup.h */
#if !defined(__WXMSW__)
#include <setup.h>
#endif

#if defined(__WXMSW__) && defined(__VISUALC__)
#pragma warning(disable:4800)   /* forcing value to bool (performance warning) */
#endif

#define wxUSE_BASE                    1  /* Do want the base classes */
#define wxUSE_GUI                     1  /* Do want the GUI classes */
#define WXWIN_COMPATIBILITY_2_2       0  /* Don't care about 2.2 compatibility */
#define WXWIN_COMPATIBILITY_2_4       1  /* Required by wx.NET */
#define wxDIALOG_UNIT_COMPATIBILITY   0  /* Recommended value */
#define wxUSE_DEBUG_CONTEXT           0  /* Not using wx memory debugging */
#define wxUSE_MEMORY_TRACING          0
#define wxUSE_GLOBAL_MEMORY_OPERATORS 0
#define wxUSE_DEBUG_NEW_ALWAYS        0
#define wxUSE_ON_FATAL_EXCEPTION      1  /* Let fatal exceptions bubble up */
#define wxUSE_STACKWALKER             1  /* Generate readable stack traces */
#define wxUSE_DEBUGREPORT             1  /* Enable wxDebugReport */
#define wxUSE_UNICODE                 0  /* Pure UNICODE support */
#define wxUSE_WCHAR_T                 1  /* Pseudo-UNICODE support */
#define wxUSE_EXCEPTIONS              1  /* Support C++ exceptions */
#define wxUSE_EXTENDED_RTTI           0  /* Support C++ RTTI */
#define wxUSE_STL                     0  /* Make collections use STL */
#define wxUSE_LOG                     1  /* Enable logging */
#define wxUSE_LOGWINDOW               1
#define wxUSE_LOGGUI                  1
#define wxUSE_LOG_DIALOG              1
#define wxUSE_CMDLINE_PARSER          1  /* Enable cmd-line parsing */
#define wxUSE_THREADS                 0  /* Use .NET threading */
#define wxUSE_STREAMS                 1  /* Enable stream classes */
#define wxUSE_STD_IOSTREAM            0  /* Use C++ streams */
#define wxUSE_STD_STRING              0  /* Use std::string */
#define wxUSE_LONGLONG                1  /* 64-bit ints, for DateTime */
#define wxUSE_FILE                    1  /* Enable file classes */
#define wxUSE_FFILE                   1
#define wxUSE_FSVOLUME                1  /* Enable file volumes */
#define wxUSE_STDPATHS                1  /* Enable standard file locations */
#define wxUSE_TEXTBUFFER              1  /* Enable text buffer class */
#define wxUSE_TEXTFILE                1  /* Enable text file class */
#define wxUSE_INTL                    1  /* Enable i18n features */
#define wxUSE_DATETIME                1  /* Enable date/time support */
#define wxUSE_TIMER                   1  /* Enable timers */
#define wxUSE_STOPWATCH               1  /* Enable stopwatch (for sockets) */
#define wxUSE_CONFIG                  1  /* Enable wxConfig and related */
#define wxUSE_CONFIG_NATIVE           1
#define wxUSE_DIALUP_MANAGER          1  /* Support for dialup connections */
#define wxUSE_DYNLIB_CLASS            1  /* Support dynamic library loading */
#define wxUSE_DYNAMIC_LOADER          1
#define wxUSE_SOCKETS                 1  /* Enable sockets classes */
#define wxUSE_FILESYSTEM              1  /* Enable virtual file systems (for HTML) */
#define wxUSE_FS_ZIP                  1  /* Enable .zip file systems */
#define wxUSE_FS_INET                 1  /* Enable internet file systems */
#define wxUSE_ARCHIVE_STREAMS         1  /* Enable compressed streams */
#define wxUSE_ZIPSTREAM               0  /* No need for .ZIP streams */
#define wxUSE_ZLIB                    1  /* Include zlib support */
#define wxUSE_APPLE_IEEE              1  /* Support IEEE floats to disk */
#define wxUSE_JOYSTICK                0  /* Enable joystick support */
#define wxUSE_FONTMAP                 1  /* Enable fontmap support */
#define wxUSE_MIMETYPE                1  /* Enable mime-type support */
#define wxUSE_PROTOCOL                1  /* For wxURL, wxHTTP, wxFTP */
#define wxUSE_PROTOCOL_FILE           1
#define wxUSE_PROTOCOL_FTP            1
#define wxUSE_PROTOCOL_HTTP           1
#define wxUSE_URL                     1
#define wxUSE_URL_NATIVE              0  /* Use native protocol support instead */
#define wxUSE_REGEX                   0  /* Use .NET regex support */
#define wxUSE_SYSTEM_OPTIONS          1  /* System options support */
#define wxUSE_SOUND                   1  /* Enable sound API */
#define wxUSE_MEDIACTRL               1  /* Enable wxMediaCtrl */
#define wxUSE_GSTREAMER               0  /* GStreamer for UNIX */
#define wxUSE_XRC                     1  /* Enable XML resource system */
#define wxUSE_XML                     1

#define wxUSE_CONTROLS                1  /* Enable GUI controls */
#define wxUSE_POPUPWIN                1
#define wxUSE_TIPWINDOW               1
#define wxUSE_BUTTON                  1
#define wxUSE_BMPBUTTON               1
#define wxUSE_CALENDARCTRL            1
#define wxUSE_CHECKBOX                1
#define wxUSE_CHECKLISTBOX            1
#define wxUSE_CHOICE                  1
#define wxUSE_COMBOBOX                1
#define wxUSE_DATEPICKCTRL            1
#define wxUSE_GAUGE                   1
#define wxUSE_LISTBOX                 1
#define wxUSE_LISTCTRL                1
#define wxUSE_RADIOBOX                1
#define wxUSE_RADIOBTN                1
#define wxUSE_SCROLLBAR               1
#define wxUSE_SLIDER                  1
#define wxUSE_SPINBTN                 1
#define wxUSE_SPINCTRL                1
#define wxUSE_STATBOX                 1
#define wxUSE_STATLINE                1
#define wxUSE_STATTEXT                1
#define wxUSE_STATBMP                 1
#define wxUSE_TEXTCTRL                1
#define wxUSE_TOGGLEBTN               1
#define wxUSE_TREECTRL                1
#define wxUSE_STATUSBAR               1
#define wxUSE_NATIVE_STATUSBAR        1
#define wxUSE_TOOLBAR                 1
#define wxUSE_TOOLBAR_NATIVE          1
#define wxUSE_NOTEBOOK                1
#define wxUSE_LISTBOOK                1
#define wxUSE_CHOICEBOOK              1
#define wxUSE_TAB_DIALOG              0
#define wxUSE_GRID                    1
#define wxUSE_MINIFRAME               1

#define wxUSE_ACCEL                   1  /* Menu accelerator support */
#define wxUSE_HOTKEY                  1  /* Hotkey support */
#define wxUSE_CARET                   1  /* Input caret */
#define wxUSE_DISPLAY                 0  /* Enumerate displays on system */
#define wxUSE_GEOMETRY                1  /* Required by canvas */

#define wxUSE_IMAGLIST                1
#define wxUSE_MENUS                   1
#define wxUSE_SASH                    1
#define wxUSE_SPLITTER                1
#define wxUSE_TOOLTIPS                1
#define wxUSE_VALIDATORS              1
#define wxUSE_COMMON_DIALOGS          1
#define wxUSE_BUSYINFO                1
#define wxUSE_CHOICEDLG               1
#define wxUSE_COLOURDLG               1
#define wxUSE_DIRDLG                  1
#define wxUSE_FILEDLG                 1
#define wxUSE_FINDREPLDLG             1
#define wxUSE_FONTDLG                 1
#define wxUSE_MSGDLG                  1
#define wxUSE_PROGRESSDLG             1
#define wxUSE_STARTUP_TIPS            1
#define wxUSE_TEXTDLG                 1
#define wxUSE_NUMBERDLG               1
#define wxUSE_SPLASH                  1
#define wxUSE_WIZARDDLG               1

#define wxUSE_METAFILE                0  /* No WMF support */
#define wxUSE_ENH_METAFILE            0
#define wxUSE_WIN_METAFILES_ALWAYS    0

#define wxUSE_MDI                     1
#define wxUSE_DOC_VIEW_ARCHITECTURE   1
#define wxUSE_MDI_ARCHITECTURE        1
#define wxUSE_PRINTING_ARCHITECTURE   1
#define wxUSE_HTML                    1
#define wxUSE_GLCANVAS                0

#define wxUSE_CLIPBOARD               1  /* Enable clipboard support */
#define wxUSE_DATAOBJ                 1
#define wxUSE_DRAG_AND_DROP           1
#define wxUSE_ACCESSIBILITY           0

#define wxUSE_SNGLINST_CHECKER        1
#define wxUSE_DRAGIMAGE               1
#define wxUSE_IPC                     1
#define wxUSE_HELP                    1
#define wxUSE_MS_HTML_HELP            1
#define wxUSE_WXHTML_HELP             1
#define wxUSE_RESOURCES               0
#define wxUSE_CONSTRAINTS             1
#define wxUSE_SPLINES                 1
#define wxUSE_MOUSEWHEEL              1

#define wxUSE_POSTSCRIPT              0
#define wxUSE_AFM_FOR_POSTSCRIPT      1

#define wxUSE_ODBC                    0
#define wxODBC_FWD_ONLY_CURSORS	     1
#define wxODBC_BACKWARD_COMPATABILITY 0

#define REMOVE_UNUSED_ARG             1
#define wxUSE_IOSTREAMH               1

#define wxUSE_IMAGE                   1
#define wxUSE_LIBPNG                  1
#define wxUSE_LIBJPEG                 1
#define wxUSE_LIBTIFF                 1
#define wxUSE_GIF                     1
#define wxUSE_PNM                     1
#define wxUSE_PCX                     1
#define wxUSE_IFF                     1
#define wxUSE_XPM                     1
#define wxUSE_ICO_CUR                 1
#define wxUSE_PALETTE                 1

#define wxUSE_UNICODE_MSLU            0
#define wxUSE_MFC                     0
#define wxUSE_OLE                     1
#define wxUSE_DC_CACHEING             1
#define wxUSE_DIB_FOR_BITMAP          0
#define wxUSE_WXDIB                   1
#define wxUSE_POSTSCRIPT_ARCHITECTURE_IN_MSW 1
#define wxUSE_RICHEDIT                1
#define wxUSE_RICHEDIT2               1
#define wxUSE_OWNER_DRAWN             1
#define wxUSE_UXTHEME                 1
#define wxUSE_UXTHEME_AUTO            1

#define wxUSE_DATEPICKCTRL_GENERIC    0

#define wxUSE_CRASHREPORT             0  /* Let crashes bubble up */

#endif

