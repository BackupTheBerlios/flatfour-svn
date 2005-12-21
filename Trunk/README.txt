Flat Four Engine - .NET Framework for Simulation Development
Version @BUILD@ (@DATE@)

 Copyright (C) 1999-@YEAR@ by Jason Perkins
 All Rights Reserved


ABOUT THIS RELEASE

 The purpose of this initial release is to assemble the scaffolding
 of the project and demonstrate the top level structure. Namely, that
 the framework will be a managed .NET library (Straight8.Framework)
 built on top of a unmanaged platform abstraction library (GameGuts).
 An initial set of NUnit tests have been assembled, along with a
 cross-platform build system using Premake.


LICENSING

 The Flat Four Engine is released under the BSD license. See
 LICENSE.txt for more information on the licensing terms.


BUILDING

  This version of the Engine requires the GameGuts Toolkit v0.0.2. 
  The source code for the Toolkit is included with this package and 
  may be built along with the Engine. If you would rather not mess 
  around with C++ code you can download a prebuilt binary from the 
  Toolkit website at http://gut.sourceforge.net/ and place it in the
  same directory as the Straight8.Framework DLL.
  
  In order to build the Engine you will need a copy of Premake from
  http://premake.sourceforge.net/. This is a small command-line 
  utility that generates solutions, projects, makefiles, etc. for 
  several different toolsets. Using Premake makes it more likely 
  that I can support your favorite tools, saves me a bunch of time, 
  and eliminates a whole class of bugs. Download a binary for your 
  platform and copy it somewhere to your path. 
  
  Premake should be run in the FlatFour directory. The basic form of 
  the command is `premake [options] --target [toolset]`. Here are some
  sample commands to help you get started:
  
    premake --target sd
    
      Set up just the Engine for SharpDevelop.
      
    premake --with-toolkit --target gnu
    
      Set up the Engine and the C++ Toolkit for GNU makefiles
      (use this for Cygwin too). Your toolset must support C++
      in order to build the Toolkit.
      
    premake --with-all --target vs2003
    
      Set up the sample applications, unit tests, C++ toolkit, 
      and engine for Visual Studio 2003.
      
  Additional options and toolsets may be available; run the command
  `premake --help` to see a complete list. After Premake runs, open 
  your toolset of choice and build the newly generated project.
  
  
SUPPORT

  For help with the Engine visit the project website at:
  
    http://flatfour.sourceforge.net/
    
    