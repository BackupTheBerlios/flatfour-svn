This sub-project is used to build the support libraries for the
Flat Four Engine. To start, you will need to download the source
code for each of the libraries and place it in this directory
(see the directions below for more information). Once all of the
sources are in place, run Premake to generate the project files
and then build. Because these are unmanaged C++ sources you will
need to build both the debug and release configurations.


wxWidgets (http://www.wxwidgets.org/)
------------------------------------------------------------------
wxWidgets is a cross-platform GUI toolkit, used by the Flat Four 
editor and any other tools that need a native GUI. I've been 
testing against version 2.6.2.

Unpack to this directory, and rename folder to "wxWidgets".


wx.NET (http://wxnet.sourceforge.net/)
------------------------------------------------------------------
wx.NET is a .NET binding for wxWidgets, used by the Flat Four
editor and any other tools that need a native GUI. I've been
testing against version 0.7.2.

Unpack to this directory, and rename folder to "wx.NET"
