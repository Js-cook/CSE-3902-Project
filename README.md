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
- U or I will cycle between which item is being shown (U goes to previous item and I goes to the next item sequentially)
### Environment/Tiles
- T and Y will cycle between which block is being shown (T switches to previous block and Y switches to the next block)
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
| 2/22 (Sprint 2 complete) | 84                    | 1156                  | 2                    | 158            | 6152                 | 1500                     |  