# sm64-pcport-installer
A GUI tool for compiling the Super Mario 64 port into a Windows executable. Executable download can be found [here](https://github.com/ajohns6/sm64-pcport-GUI-build-utility/releases).
# Introduction
This is a GUI tool which I have developed to aid those who are unfamiliar and/or intimidated by utilzing a terminal-based interface. This simple GUI tool will perform the majority of setup required to retreive build dependencies and repository updates, complete the build itself, and even open up a window directly to the newly compiled executable or create a shortcut folder directly on your desktop (this is currently due to how saves are stored by the executable; if in the future they move saves to single, remote location, the tool will be changed to no longer require the folder).
 
# Prerequisites
While the compiling process itself can be as simple as a single click of a button, there are two requirements priortto utilizing the tool:
1. .NET 4.7.2 Runtime. This can be downloaded at https://dotnet.microsoft.com/download/dotnet-framework/net472.
2. Install and update MSYS2. Download and directions can be found at https://www.msys2.org/.
3. Legally obtain a copy of the US version of Super Mario 64 ROM file. This z64 file should be renamed to baserom.us.z64.

# Features
The build tool in general requires little in way of instructions as if you want to simply play a simple, vanilla port of the original game on PC, all you have to do is place baserom.us.z64 next to the executable and click the compile button at the bottom and the process will start.

However, there are a number of options available to you should you want to control your build process just a bit more.

# Standard Build Options
![Standard Build Illustration](https://i.imgur.com/iBEM32q.png)

In the top left corner, you will have three radio buttons which you can use to select which of the three main repository you would like to pull from: Official, SM64 EX, or SM64 (nightly).

Next there is the checkbox for "Check for repo updates" which is checked by default. If checked, the utility will check for updates to the repository before building the executable. This will ensure a most up-to-date version of the executable, but could wipe out any modifications you may have done, so etiher back them up ahead of time or simply uncheck this box.

Next we have the "Check for MSYS2 dependency updates" box. If checked, the utility will check for updates to dependencies of the build and will update them accordingly. This box comes unchecked by default, but you will want to make sure that you check it the first time you run it as the dependencies will not exist. I hope to a determine a way ensure that the dependencies exist in a future release, but was not able to do so at the time of release.

There is also a check box at the top for "Create Shortcut". This is unchecked by default, but if checked, the utility will create a folder with a shortcut to the executable on your desktop. If unchecked, the utility will simply open the directory where the executable is found after the build.

There is a number selection for "Number of jobs to allocate to build process" which will allow you to select the number of jobs to be allocated to the build process. By default, this is set to your number of cores - 2 (e.x. an eight core processor would be 6), but it can be changed to a wide range of values. If, however, you set the value to 0, it will be interpretted as unlimited. This is not recommended as it will put a lot of strain on your system and may actually perform significantly worse due to that.

Next are three directory fields that allow you to select certain directory locations:
* Backup Directory - In select scenarios, any existing data stored in the expected repository folders will backed up before a new copy is downloaded. In those cases, this is where the data will be stored in a folder named after the source repo and the data/time of the backup. By default, the directory is the same as where the executable is located.
* MSYS2 Directory - This is the root directory of the MSYS2 ecosystem. If you configured MSYS2 as laid out on the website above, this should not need to be changed.
* ROM Directory - This is the directory from where you will pull your local copy of baserom.us.64. By default, this directory will be the same as the executable.

Near the bottom, we have a log field. This can be copied and pasted should an error occur to assist with troubleshooting.

# Advanced Build Options
![Advanced Build Illustration](https://i.imgur.com/cCFWk90.png)
Speaking of troubleshooting, there are troubleshooting options in the new advanced build options panel. The two checkboxes at the bottom are for troubleshooting as well as those who just like to watch what their computer is doing behind the scenes. By default, they are both unchecked, but if you check "Show Terminal" the terminal will be unhidden and you can see information presented that is not visible from the GUI (yet). If you check "Keep Compiling Log Open" (which is disabled if "Show Terminal" is unchecked), the terminal windows will NOT close on their own. You can use this to examine them yourself or to provide in case of troubleshooting errors or other unclear issues.

Also, there are now "Make Options" which are available for use. These options are different between different repositories and will be checked/unchecked and disabled/enabled based on their compatibility.

Version - This allows you to select the region version used for building. This includes changes to the hash check to ensure that the version of your ROM and the version you are attempting to build match. Shindou version is selectable as it is an option for the make process, though it is broken at a repsository level. I was personally never able to get a version to compile with this option, but it may be fixed in the future, so I left it in and simply warn you that it is may be broken.

Render API - This allows you to choose the render API for your compile. The default is OpenGL 2.1, but Direct3D 11 and 12 are also options, along with a legacy option for OpenGL 1.3.

BetterCam - An alternative camera option which gives direct analog control of the camera (there are some programmed exceptions such as the Bowser levels). This places the control of the camera almost entirely on you as there is little scripted camera movement with this version.

No Draw Distance - Turns off the draw distance of objects (i.e. Goombas, coins, Chain Chomp, etc.). This can cause some unusual behavior including continual sound effects due to objects not being removed when out of range.

Texture Fix (smoke fix) - This fixes a known bug in the original game which prevented the smoke texture when Mario is burnt from actually animating.

Extra Options Menu - This allows you to open an additional menu from the pause menu by pressing "R" (as mapped to a N64 controller, not the R key on your keyboard). This includes some changes to the visuals, fullscreen toggle, sounds, keybinds, and camera controls.

Load External Data - Allows for the loading of external data, primarily textures, for post-compile modding purposes. The format for these files must follow a particular structure, but it is fluid, so you will need to check the pertinent repositories for more details regarding the current structures required.

Enable Discord Rich Presence - Allows for Discord to hook into the SM64 executable and share your game status including what level you are currently playing.

Text Saves (Experimental) - A currently experimental option that allows for saves to be handled via a plain text file rather than the existing encoding. This means you can modify a save file by simply changing some clearly labelled values. It is experimental though, so problems may arise if you use it.

# Closing
I hope this tool serves you well and I hope to be able to continue making updates including patch support in time. Thanks!

If you have issues, you can always reach out here of course, but I also frequent all the usual help desk channels at the two main Discord servers as well ([sm64-port](https://discord.gg/7bcNTPK) and [sm64ex](https://discord.gg/ZezK78p). I try and check there pretty frequently during the day (US East Coast), but sometimes I'm working on other things and might not be there. Feel free to call me out specifically with @RadzPrower and that will give me a notification and I'll be more likely to see it...assuming I'm not asleep, of course.

Logo courtesy of SunlitSpace542
