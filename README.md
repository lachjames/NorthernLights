# Northern Lights

The Northern Lights Project (a placeholder name) is a full reimplementation of the Aurora/Odyssey engine, targeting the two Knights of the Old Republic games (KotOR 1 and TSL). It is made of two elements:
 - A full re-reimplementation of the Odyssey engine
 - A level editor with similar (but extended) capabilities to the Aurora toolset, originally designed for Neverwinter Nights.

## What Works
 - Model loading and animations (thanks in no small part to the work of rwc4301, whose work in turn seems to be partially based on the Xoreos project) 
 - NCS scripts run natively, although performance needs to be improved
 - Many of the engine routines have been implemented, along with the corresponding systems
 - I've got a rudimentary UI system working, but how exactly I want to handle this is still an open question
 - Enemy combat AI is working (but is very simple; for now, I'm overriding the k_ai_master script and writing the AI logic myself).
 - The action system has been implemented, but many of the actions require implementation
 - Movie playback works (although it works by first converting all the movies to MP4, and then playing them). Eventually, using Xoreos as a reference, I'd like to read the movies directly from .bik format, but that's a lower priority.
 
## What doesn't work
 - Many of the systems currently use reflection to (very significantly) improve the ability of 
 - The save-load system
 - The effect system (as in, effects on characters, such as heal, damage, ...) is not yet implemented
 - TSL support is still an ongoing issue, as TSL's game files are more complex than those for K1. However, I anticipate the majority of the issues here will be resolved shortly.
 
## Installation
Please follow the following steps:
 1. Download the repository, either by cloning it using git or just downloading it as a .zip file
 2. Unzip the resulting folder somewhere on your computer
 3. Open the folder in Unity as a project
 4. Open the "KotOR" scene, in the "scenes" folder
 5. Open Systems>Loading System in the inspector, and change the kotorDir variable to point to the base directory of your KotOR 1 installation (TSL support is coming as a VERY high priority and is, theoretically, almost complete)
 6. Set the "Level Name" variable in the same inspector window as (5) to whichever module you want to load
 7. Press the play button at the top-middle of the screen

## Who to thank
 - Almost all of the code for loading models, GFF, LYT, RIM, MOD, ERF, ... files is either directly from, or derived from, the KotOR-Unity repo (https://github.com/rwc4301/KotOR-Unity). This project wouldn't have gotten off the ground without the amazing work of rwc4301.
 - JC on the DeadlyStream Discord has been invaluable and this project would not exist without his knowledge of the game engine
 - Thor110 for his help and support, tmonahan23, VicariousVeteran, and many, many others
 - DrMcCoy and the Xoreos team for the Xoreos project (xoreos-tools is used in this project for a few things, and xoreos itself is a great reference)
 - The Reone project, which
 - KotOR.js, another project similar to this, whose public source code has been helpful when trying to crack a couple of difficult nuts
 - MDLOps, whose source code I have relied on heavily when trying to understand the MDL/MDX format
 - The NWN NSS/NCS Skywing documentation
 - So, so much more... I need to finish this section
