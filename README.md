# Y1T1_4-001
This Unity project demonstrates an auto target system. The player’s camera automatically cycles through targets sorted by health points (HP).

Assets/Scripts/
PlayerController.cs → Controls the camera, cycles through targets, and checks visibility.
GameManager.cs → Finds all targets, sorts them by HP using bubble sort, and provides the sorted list.
TargetHP.cs → Stores each target’s HP and allows other scripts to read it.

Assets/Scenes/
MainScene.unity → The scene containing targets, obstacles, and the player camera.

How It Works:
GameManager collects all TargetHP objects and sorts them from highest to lowest HP.
PlayerController makes the camera face the first target and cycles to the next visible target when the Space bar is pressed.
Targets blocked by obstacles are skipped automatically.

Key Features:
Sorting using Bubble Sort
Camera control with visibility checking via raycasting
Reusable TargetHP components
Easy-to-modify scene setup
