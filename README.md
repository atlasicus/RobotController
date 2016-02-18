# RobotController
A solution for controling robots

Build Requirements

The visualization component requires MonoGame 3.4 in order to build.  You can download MonoGame from here: http://www.monogame.net/downloads/
The components required to build are added as a NuGet package on both use and test solutions but it's unclear if you need both the NuGet package and the install in order to build and compile successfully.

Usage:

The project assumes that console output will be read for acceptance testing, and outputs the simulation to console as well as to a render target.

* Input is case insensitive and ignores any invalid commands.
* Output is synchronized to what is happening on screen, it will output at the same rate.

There are two files necessary for the software to run successfully: rules.xml and map.csv 

rules.xml contains the schema for how interactions are mapped to values.  The interaction values are represented as an unsigned 8-bit value.  Names are represented as strings.  

map.csv contains the shape and tile information for a map.  The numbers represented on the CSV are directly correlated to the rules.xml and should be configured accordingly.
***Note: if editing with Excel, Excel will lock the file and RoboController will be unable to read the file.  Please close Excel to read normally.***

Currently RobotController only supports symmetrical maps, only square maps at the moment.  
