
## FusionX - an open-source Clickteam Fusion runtime built with .NET
This is the official git repository for FusionX.
FusionX is a Clickteam Fusion runtime that is based on the XNA exporter (released back in 2012 and is currently unavailable).

**List of modifications that have been done to it so far:**

 - Runtime has been ported to MonoGame for compatibility with modern Windows version
 - CCN file parser has been heavily modified to work with modern Clickteam Fusion version (up to R294.11)
 - Implemented some of the features that are missing in the XNA exporter (extension loading, multiple a/c/e)
 - Optimized data loading. The runtime is significantly faster than the original XNA Exporter

## Currently known issues

 - The runtime can only play WAVE sound files, MP3, OGG and other formats are not supported
 - Rendering and event loop are pretty slow compared to the classic Clickteam Fusion runtime ("Windows EXE Application")
 - Shaders are not implemented
 - Frame and object transitions are not implemented
 - Some a/c/e's are not implemented
 - The code is really messy, needs a lot of cleanup and requires a lot of effort to understand what is going on
 - The runtime wasn't tested with Clickteam Fusion 2.5+, so it might not work as expected
 - Some of the code was taken from [CTFAK](https://github.com/CTFAK/CTFAK2.0). Image loading might not work as expected
 - The runtime can only run on 64-bit versions of Windows and haven't been tested on Linux, even though it should run normally under Wine
## Licensing
FusionX is licensed under the AGPLv3 license.
FusionX is not sponsored by, affiliated with or endorsed by Clickteam LLC or its affiliates.
"Clickteam Fusion" is a trademark or a registered trademark of Clickteam LLC or its affiliates in the U.S. and elsewhere.