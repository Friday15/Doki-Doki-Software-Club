# READ ME REEEEEEEEEEEEEEEEEEEEEE
## How to add dialogue
1. Go to test/Assets and open dialogue.txt
2. Write your dialogue in this format "ACTOR;DIALOGUE;INDEX#;L or R"
    - ACTOR is the character Object you want load
    - DIALOGUE is the string you want the actor to say
    - INDEX# is the index number of the image in it's GameObject
    - L or R means putting the image either on the left or right side of the screen
    - Sample:
      - Yukino;Hello world;0;L
      - This sample uses actor "Yukino", uses her sprite in the 0th index, the text box will say Hello world and her sprite will be spawned at the left side.

## How to add choices
1. Go to test/Assets and open dialogue.txt
2. Write the choices in this format "Player;CHOICE1:line,LINE#;CHOICE2:line,LINE#"
    - CHOICE1 and CHOICE2 is what will be displayed in the buttons for the choices. **Choice doesn't have to be only 2, can have multiple choices.**
    - LINE# is the line number the game will go to if that option is clicked. LINE# count begins with 0 so the first line in dialouge.txt is Line number 0. LINE# will be changed in the future since keeping track of all the line numbers is a problem.
    - The lines "Player" and "line" shouldn't be changed as they tag what kind of command they do
    - Sample:
      - Player;Sader:line,1;Yukino:line,2
      - This sample will display to the player 2 buttons labeled "Sader" and "Yukino". Clicking Sader will jump the game to line 1 in the .txt file while clicking Yukino will jump the game to line 2 in the .txt file. 
      - Note that Yukino's button will appear at the top of Sader's button instead of the other way around. This will again be changed in the future for convinience.
      
## How to change the background
1. Go to test/Assets and open dialogue.txt
2. Write "Player;`background;INDEX#"
    - Player and `background are tags to identify what kind of command is being done
    - INDEX# is the index number of the background you want to load
    - Sample:
      - Player;`background;0
      - This sample loads the picture in index 0 and sets it as the background.
      
## How to convert your images to sprites
1. Click on your project tab
2. Using the project tab find and click on the picture you want to convert to a sprite
3. After finding your picture, check your inspector tab and click "Textture type"
4. Select "Sprite (2D and UI)"
5. Click "Apply" on the bottom of the tab

## How to add a new character to the game
1. Make sure all image that will be used are converted to sprites and the images are in Assets/Pictures
2. Right-click on the "Hierarchy" tab
3. Click "Create Empty"
4. Name the GameObject the name of the character you want it to represent. Note that spelling and capitilization should be the same as the character name in dialogue.txt
5. Click "Add Component" and click "Scripts" then click "Character"
6. On your "Inspector" tab, you should see the character script. Click on "Character Poses" to extend it.
7. On the textfield that says "size", enter the amount of sprites the char you want to add has.
8. After entering a number above 1, it should add more textfields labeled "Element 0", "Element 1" and so on
9. Click on the circle icon on the left of those text fields.
10. Select the image you want to add to that index
11. Repeat 9 and 10 until you add all your sprites
12. Once done adding, click "Add Component" and click "Rendering" and click "Sprite Renderer"

## How to add a new background to the game
1. Make sure all image that will be used are converted to sprites and the images are in Assets/Pictures
2. Click on "Background" on your "Hierarchy" tab
3. On your "Inspector", look for the tab named "Background Script"
4. Click on the "bg" tab to expand it
5. Increase the number on the "size" tab by the number of backgrounds you will be adding
5. Click on the circle on the right of the empty elements and select the image you want to add.
6. Repeat 5 until all images are added
7. Remember that their index number is the same number used to call them in dialogue.txt
