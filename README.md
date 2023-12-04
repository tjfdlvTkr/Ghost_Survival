# Mushroom Soup

In a village, a hungry rabbit lived. The rabbit is hunting for mushrooms to make mushroom soup. Let's help the rabbit to solve its hunger!

### Repository
- PlayerController.cs : Control the player object.
- Weapon.cs : Tool for Player hits monster.
- Fireball.cs : Object that player hits enemys.
- Movement2D.cs : Make object to move in 2D.
- EnemyAI.cs : Define Enemy.
- AbstractDungeonGenerator.cs : Abstract about DungeonGenerator.
- BFS.cs : Breadth-First Search Algorithm for Decide monster's path.
- Monster.cs : Monster's information.
- Player.cs : Information about Player.
- Wallgenerator : Generating wall.
- TilemapVisualizer.cs : Make Tile for Visualizer on the map
- etc...

## Using Algorithms
The BFS algorithm is used to find the shortest path from the start position to the target position. This algorithm is an effective method for finding the shortest path by performing breadth-first search in data structures such as graphs or trees.

1. Put the start position (start) in the queue (queue).
2. Add the start position to the dictionary (cameFrom) that checks for visits.
3. Compare the target position (end) by taking out the positions from the queue one by one. If the current position is the same as the target position, stop the search.
4. Check all neighbor positions that can be moved from the current position. Check if it is a tile that can be moved, and if it is a tile that can be moved and has not yet been visited, add it to the queue and set the current position in the visit check dictionary to the neighbor position.
5. Repeat the process from 3 to 4 until the queue is empty.
6. To create a path, trace the dictionary from the target position to the start position and construct the path.

Sort the path in reverse order to get the shortest path. The BFS algorithm is used to search and construct the shortest path from the start position to the target position using a queue and dictionary.

## Results

In-game
![image](https://github.com/tjfdlvTkr/Mushroom_Soup/assets/87065226/d225ad46-a0ec-40ac-bc7c-4c21bb25a580)

End-game
![image](https://github.com/tjfdlvTkr/Mushroom_Soup/assets/87065226/c0dc1a23-0792-4369-877b-8cff7c83bc02)


### Contribute
Modification is possible after fork operation. The main creators of that sources are [Team 2: Soup Studio]: [tjfdlvTkr](https://github.com/tjfdlvTkr), [ParkYeongBin](https://github.com/ParkYeongBin), [yeonjeongchoi](https://github.com/yeonjeonchoi), [minjae23](https://github.com/minjae23)
