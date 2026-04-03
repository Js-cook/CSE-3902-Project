# 3902 Legend of Zelda (NES) Documentation

## Controls
### Movement
- WASD or arrow keys for movement
- Z or N to attack
- E to enter damaged state
- Number keys 1-6 are items as follows
	- 1 is arrow
	- 2 is silver arrow
	- 3 is boomerang
	- 4 is magic boomerang
	- 5 is fireball
	- 6 is bomb
### Enemies
- O or P will cycle which enemy or npc is being shown (O goes to previous enemy and P goes to next enemy sequentially)
### Items
- T will spawn a heart near the player
- R will spawn a rupee near the player
- K will a key near the player
### Environment/Rooms
- Y will change room to the room above
- H will change room to the room below
- G will change room to the room on the left
- J will change room to the room on the right
### Other
- Q will quit the game
- R will reset the game to the initial state

## Bugs and Known Issues
- No collision
- No screen bounds/cycling (things that go off-screen won't go around the other side)
- Inconsistent sprite scaling
- Limited implementation of sound effects (no enemy sounds and bomb explosions not yet implemented)

## Metrics
Metrics calculated using the "Code Metrics" tool

### Baseline (metrics calculated from a newly created Monogame project with no other content)

| Maintainability Index | Cyclomatic Complexity | Depth of Inheritance | Class Coupling | Lines of source code | Lines of executable code |  
| --------------------- | -------------------- | -------------- | -------------------- | ------------------------ | --------------------- |  
| 81                    | 9                    | 2              | 16                   | 50                       | 13                    |    


### Project (current project)

| Date | Maintainability Index | Cyclomatic Complexity | Depth of Inheritance | Class Coupling | Lines of source code | Lines of executable code |  
| ---- | --------------------- | --------------------- | -------------------- | -------------- | -------------------- | ------------------------ |  
| 2/22 | 84                    | 1156                  | 2                    | 158            | 6152                 | 1500                     |  
| 2/28 | 83                    | 1229                  | 2                    | 191            | 6857                 | 1697                     |
| 3/8  | 84                    | 2013                  | 2                    | 255            | 9988                 | 2465                     |
| 3/23 | 83                    | 2151                  | 2                    | 266            | 10588                | 2666                     |
| 3/29 | 83                    | 2165                  | 2                    | 277            | 10853                | 2720                     |

### Areas for refactoring (methods and classes with the worst maintainability index)
| Maintainability Index | Class | Method |
| --------------------- | ----- | ------ |
| 25 -> 27 (as of 3/29)                    | KeyboardController | Update() : void |
| 45 -> 35 (as of 3/29)                   | Environment | GetCollidableTiles() : List\<Tile\> | 
| 47 -> 39 (as of 3/29)                   | LevelFileReader | LoadLevel(string, int, int) : bool |
| 48 -> 49 (as of 3/29)                    | IKeyboard       | |
| 54                    | ProjectileController | Update(GameTime) : void |
| 55                    | Item                 | Item(ItemFactory) |
| 56 -> 48 (as of 3/29)                   | LevelFileReader      | |
| 57                     | CollisionManager | Update(GameTime, List\<ICollidable\>) : void |
| 58                    | AudioController  | PlaySoundEffect(SoundEffect, float, float, float, bool) : SoundEffectInstance |
| 59                    | Boomerang        | Update(GameTime) : void |



 
