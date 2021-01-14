BigBoxLauncher
==================================
This is a utility program that was developed to solve a simple 
problem with BigBox (part of the LaunchBox front-end used
for custom arcade machines).  If BigBox is running, and you
have configured the host computer to automatically reboot
on a schedule, BigBox will fail to write out the LastPlatform
setting to BigBoxSettings.xml.  This results in BigBox
starting with the wrong platform the next time it is launched.

This program overrides the LastPlatform setting in BigBoxSettings
to reset it to your desired platform.  Simply create a batch file that 
looks like this: 

launchbigbox.cmd
-----------------
BigBoxLauncher.exe
c:\[launchboxfolder]\BigBox.exe

Edit the BigBoxLauncher.exe.config file and update the LastPlatform value and the BigBoxSettings location file with the exact location 
and filename of your BigBoxSettings.xml file, which would normally be in [LaunchBox\Data\BigBoxSettings.xml]

==================================
License
==================================

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.