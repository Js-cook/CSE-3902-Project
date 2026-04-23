# Diamond Door Testing Guide

## Overview
Diamond doors are special locked doors that open when specific trigger conditions are met. Unlike key-locked doors, they open automatically based on game events.

## Diamond Door Types and Test Locations

### 1. **DiamondLockedDoor:BlockPushed** - Opens when a pushable block is moved
- **Test Location:** Room (2, 1)
- **Door Position:** Left door
- **Test Steps:**
  1. Start game and navigate to Room (2, 1) using keys: H (down), then J (right)
  2. Observe the left door - it should have a diamond sprite and be locked
  3. Find the pushable block in the middle of the room (row 3, col 5)
  4. Push the block in any direction by walking into it
  5. **Expected Result:** The left diamond door should immediately open (change to open door sprite)
  6. Walk through the left door to verify it's passable
  7. Return to the room - the door should remain open

### 2. **DiamondLockedDoor:AllEnemies** - Opens when all enemies in the room are killed
- **Test Location:** Room (3, 1)
- **Door Position:** Right door
- **Test Steps:**
  1. Navigate to Room (3, 1) using keys: H, H, J
  2. Observe the right door - it should have a diamond sprite and be locked
  3. Room contains 6 Bat enemies
  4. Kill all 6 bats using sword (Z key) or other weapons
  5. **Expected Result:** When the last enemy dies, the right diamond door should open
  6. Walk through the right door to Room (3, 2) to verify it's passable
  7. Return to Room (3, 1) - the door should remain open

### 3. **DiamondLockedDoor:Boss** - Opens when the boss (Aquamentus) is killed
- **Test Location:** Room (1, 3)
- **Door Positions:** Right door AND Bottom door (both have Boss trigger)
- **Test Steps:**
  1. Navigate to Room (1, 3) - the boss room
  2. Observe both the right and bottom doors - they should have diamond sprites and be locked
  3. The room contains Aquamentus (the dragon boss)
  4. Defeat Aquamentus using your weapons
  5. **Expected Result:** When Aquamentus dies, BOTH diamond doors (right and bottom) should open simultaneously
  6. Walk through each door to verify both are passable
  7. Return to the room - both doors should remain open

## Quick Navigation Cheat Sheet
- **Y** = Move up one room
- **H** = Move down one room  
- **G** = Move left one room
- **J** = Move right one room
- **N** = Toggle secret room (row 99, col 99)

Starting room is (5, 2), so from the start:
- Room (2, 1): Press H three times, then G once
- Room (3, 1): Press H twice, then G once  
- Room (1, 3): Press Y four times, then J once

## Common Issues to Check

### Issue 1: Door doesn't open when trigger occurs
**Possible causes:**
- Diamond door trigger type is missing in RoomData.xml (must be format: `DiamondLockedDoor:TriggerType`)
- Event subscription is not working (DiamondDoorManager not subscribed to events)
- Wrong trigger type specified

### Issue 2: Door opens but then re-locks when returning to room
**Possible causes:**
- `roomManager.UnlockDoor()` not being called in `DiamondDoorManager.OpenDiamondDoor()`
- UnlockedDoors HashSet in RoomManager not persisting

### Issue 3: Block push doesn't trigger door
**Possible causes:**
- Block push event not being fired by PushableBlock
- DiamondDoorManager not subscribed to BlockPushed events
- Block push events not being re-subscribed when room changes

### Issue 4: Door opens in wrong room or all rooms
**Possible causes:**
- DiamondDoorManager opening doors in all rooms instead of just current room
- Environment doorways list contains doors from multiple rooms (should be cleared per room)

## Debug Output
When testing, check the Visual Studio Output window for debug messages:
- Look for messages like: `"*** PARSING DIAMOND DOOR: 'DiamondLockedDoor:AllEnemies' at Room (3,1) Direction 1"`
- Check for: `"Doorway created: Type=DiamondLockedDoor, IsLocked=True, IsBombedWall=False, TriggerType=AllEnemies"`

## Fixed Issues in This Update
1. ✅ Room (3,1) diamond door was missing trigger type - now set to `DiamondLockedDoor:AllEnemies`
2. ✅ ResetState() now properly re-initializes DiamondDoorManager and re-subscribes events
3. ✅ Added UnsubscribeFromDiamondDoorEvents() to prevent memory leaks and duplicate event handlers
4. ✅ Room change now properly re-subscribes to block push events via RoomChanged event

## Advanced Testing

### Test Persistence Across Death
1. Open a diamond door using any trigger
2. Die (press E repeatedly or let enemies kill you)
3. After respawn, navigate back to the room with the opened diamond door
4. **Expected Result:** Door should still be open (persistence works)

### Test Multiple Diamond Doors in Same Room
1. Navigate to boss room (1, 3) which has 2 diamond doors with Boss trigger
2. Kill Aquamentus
3. **Expected Result:** Both doors should open at the same time

### Test Diamond Door vs Key Door
1. Room (3, 1) has both a KeyLockedDoor (top) and DiamondLockedDoor (right)
2. The top door requires a key, the right door requires killing all enemies
3. Verify they work independently

## Tips for Debugging
- Use debug keys to navigate quickly between rooms (Y, H, G, J)
- Press T, R, K, C to spawn test items near the player
- Check the Output window for detailed door creation logs
- If a door isn't working, check the RoomData.xml entry for that room
