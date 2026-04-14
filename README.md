# 3902 Legend of Zelda (NES) Documentation

## Controls
### Movement
- WASD or arrow keys for movement
- Z for primary item/weapon
- X for secondary item/weapon
- E to enter damaged state
- Number keys 1-6 are items as follows
	- 1 is arrow
	- 2 is silver arrow
	- 3 is boomerang
	- 4 is magic boomerang
	- 5 is fireball
	- 6 is bomb
### Items
- T will spawn a heart near the player
- R will spawn a rupee near the player
- K will a key near the player
- C will spawn a clock power-up near the player
### Environment/Rooms
- Y will change room to the room above
- H will change room to the room below
- G will change room to the room on the left
- J will change room to the room on the right
### Other
- ESC will open the inventory (closed with left control)
- P will pause the game (p again to unpause)

## Bugs and Known Issues

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
| 4/6  | 82                    | 2381                  | 2                    | 292            | 12035                | 2993                     |
| 4/10 | 82                    | 2542                  | 2                    | 296            | 13137                | 3244                     |
| 4/13 | 81                    | 3041	               | 2                    | 326            | 15918                | 4062                     |

### Areas for refactoring (methods and classes with the worst maintainability index)
| Maintainability Index | Class | Method |
| --------------------- | ----- | ------ |
| 25 -> 27 (as of 3/29) -> 72 (as of 4/6)                   | KeyboardController | Update() : void |
| 45 -> 35 (as of 3/29)                   | Environment | GetCollidableTiles() : List\<Tile\> | 
| 47 -> 39 (as of 3/29)                   | LevelFileReader | LoadLevel(string, int, int) : bool |
| 48 -> 49 (as of 3/29) -> 83 (as of 4/6)                    | IKeyboard       | |
| 54                    | ProjectileController | Update(GameTime) : void |
| 55                    | Item                 | Item(ItemFactory) |
| 56 -> 48 (as of 3/29)                   | LevelFileReader      | |
| 57                     | CollisionManager | Update(GameTime, List\<ICollidable\>) : void |
| 58                    | AudioController  | PlaySoundEffect(SoundEffect, float, float, float, bool) : SoundEffectInstance |
| 59                    | Boomerang        | Update(GameTime) : void |

### Areas for refactoring post first major refactoring (strikethrough indicates no longer within list)
| Maintainability Index | Class | Method |
| --------------------- | ----- | ------ |
| 28 -> 27 (as of 4/10) | PlayingState	| ResolveKey(KeyboardState) : void |
| 35 | EnvironmentGetCollidableTiles() : List\<ICollidable\> |
| 39 -> 42 (as of 4/10) | LevelFileReader | LoadLevel(string, int, int, bool) : bool |
| 46 | PlayingState	| LoadContent(ContentManager) : void |
| ~~48~~ | ~~LevelFileReader~~ (as of 4/10) | |
| ~~50~~ | ~~PlayingState~~ (as of 4/10) | ~~ResetState() : void~~ |
| ~~52~~ | ~~EnemyLoader~~ (as of 4/10) | ~~LoadEnemiesFromRoom(XElement) : void~~ |
| 50 | PlayerDoorwayCollisionHandler | HandleCollision(ICollidable, ICollidable, Rectangle) : void |
| 52 | HUD | Draw() : void |
| 53 | HUD | HUD(Rectangle, HUDSpriteFactory, HUDBackgroundSprite, LinkInventory) |
| 54 | CollisionRegistry | RegisterPlayerCollisions(CollisionManager, RoomManager, TileFactory) : void |
