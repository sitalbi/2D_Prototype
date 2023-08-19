# 2D_Prototype

## To do list:
 - New Input System fo Player along with implementing a State Machine -> (Implment the action input (open a chest, read a sign, etc...)
 - Implement Timer class to reuse and thus have a cleaner code
 - Background image(s) with parallax
 - Particles (footstep, attack, etc...)
 - Destroyable props
 - Add new props (chest, resources, doors between rooms)
 - new ennemies


## Scene and level architecture:

Use a scene for each "biome". Each biome can contains multiple levels, which contains their own props, enemies, and other gameobjects. Levels are gameobjects themselves and are deactivated until the player step in them.

A level gameobject should contain: 
       - a child gameobject with a collider and script to manage the level change (onCollisionEnter).
       - a script initializing an object of the class Level. The class Level contains everything related to the level (spawn position of the player, etc...)
