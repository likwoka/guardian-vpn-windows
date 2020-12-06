Why fork
========
As of 2020 Dec 06
The current Mozilla VPN windows app (1.3) does not work correctly with my laptop which has older Nvidia video card.

Specifically, the rendering of the app window is blank (all white). 
However if you move your mouse over the blank canva slowly, you will see the pointer changes when it runs over the buttons. And the buttons are clickable!

Solution without this fix
=========================
A way to fix this is to turn on hardware acceleration. In my Nvidia Control Panel (Nvidia Setting in system tray), go to Manage 3D Settings, then Program Settings tab to set this to use hardware acceleration.

Solution with this fix
======================
Instead of messing around in the video card setting, it would be nice if you can just override the behavior in the application itself.
The intention is to introduce a app setting (in .exe.config) to either use the WPF rendering default (which is hardware acceleration), or manually set to software rendering.
This way, if the default (hardware acceleration) won't work, then the user can manually force a softare rendering to cover all cases.

However, after building this application locally, running it on my windows laptop works anyway with or without this option. 

So that could be because I built with the latest .NET 5 which fix the bug (more likely), or because I built it locally which takes consideration of my video card (less likely).
Hence I can't really verify if this option is useful or not... but 

