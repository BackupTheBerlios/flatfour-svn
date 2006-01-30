project.name = "FlatFour_Libs"

project.config["Debug"].bindir = "Bin/Debug"
project.config["Debug"].libdir = "Bin/Debug"

project.config["Release"].bindir = "Bin/Release"
project.config["Release"].libdir = "Bin/Release"

dopackage("wxc")
dopackage("wxwidgets")
