# 2D_Prototype

To do list:
 - New Input System fo Player along with implementing a State Machine
 - Implement Timer class to reuse and thus have a cleaner code
 - Background image(s) with parallax
 - Particles (footstep, attack, etc...)
 - Destroyable props
 - Add new props (chest, resources, doors between rooms)


## Scene and level architecture:

- Technique 1:
   use a scene for each "biome". Each biome can contains multiple levels, which contains their own props, enemies, and other gameobjects. Levels are gameobjects themselves and are deactivated until the player step in them.

- Technique 2:
   use a scene for each levels. Easier to set up but can be quickly difficult to manage for big maps.
