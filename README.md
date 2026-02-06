# Sprint 2 - Due 2/23

## Rough Plan
### States
- Use the example in 9-GoombaStateExample.cs
- Interface for state with methods that change the state
- Class for whatever it is (player, enemy, etc) has a public field of the state interface type
- Classes for each state with a private field for the actual thing (player, enemy) that implements the interface
### Sprites
- Use the example in 8-EnemySpriteFactorySingletonExample.cs
- Ideally, this handles animation too
- State classes will likely interface with these the most

## Objects and Sprites to implement
Environment (tiles)
- Statues
- Square block
- Push-able block
- Fire
- Blue gap (unwalkable)
- Stairs

Environment (background)
- White brick
- Ladders
- Blue floor
- Blue sand

Environment (other)
- Walls / room border
- Open door
- Bombed wall opening
- Keyhole locked door
- Diamond symbol locked door

Player and "friendly projectiles" (moving and animated)
- Link
- Wooden Sword
- Sword beam
- Arrows
- Boomerang

Items
- Compass
- Map
- Key
- Heart container
- Triforce piece
- Wooden boomerang
- Bow
- Heart
- Rupee
- Arrow
- Bomb
- Fairy
- Clock

Enemies and harmful projectiles (moving and animated)
- Bat (keese)
- Skeleton (stalfos)
- Dog-like monster (goriya)
- Jelly (gel-small)
- Hand (wall master)
- Spike cross (trap)
- Boss/Dragon (aquamentus)
- Boss/Dragon fireballs
- Enemy cloud appearance
- Enemy death explosion

NPCs and neutral projectiles
- Old man
- Flame in old man room
- Link's bombs

## Bugs and Known Issues (yet)
- ...

## Metrics
- idk if we need this but if we do we can put a table here
