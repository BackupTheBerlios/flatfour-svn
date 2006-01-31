This sub-project is used to build the support libraries for the
Flat Four Engine. To start, you will need to download the source
code for each of the libraries and place it in this directory
(see the directions below for more information). Once all of the
sources are in place, run Premake to generate the project files
and then build. 


GameGuts (http://gut.sourceforge.net/)
------------------------------------------------------------------
GameGuts is a collection of low-level services for game and
simulation development. Flat Four uses it to provide platform
abstraction, collision detection, and physics. This version of
the engine requires version 0.1.5.

Unpack to this directory and rename folder to "GameGuts".

This particular library is being developed specifically for
Flat Four and so it changes frequently. Until things settle down
you can also include it in the main engine build; see the 
--with-toolkit flag in the framework build instructions.



wxWidgets (http://www.wxwidgets.org/)
------------------------------------------------------------------
wxWidgets is a cross-platform GUI toolkit, used by the Flat Four 
editor and any other tools that need a native GUI. I've been 
testing against version 2.6.2.

Unpack to this directory and rename folder to "wxWidgets".



wx.NET (http://wxnet.sourceforge.net/)
------------------------------------------------------------------
wx.NET is a .NET binding for wxWidgets, used by the Flat Four
editor and any other tools that need a native GUI. I've been
testing against version 0.7.2.

Unpack to this directory and rename folder to "wx.NET"
