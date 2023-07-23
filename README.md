<h1>Hop'n'Brew: Amphibian Alchemy</h1>

Hop'n'Brew is an original potion-crafting game set in a whimsical fantasy world, following the adventure of Froggo and Tod, a pair of charming frog-brothers who have taken up the responsibility of running an alchemy shop in the woods, but as they embark on this magical journey, they could use a bit of help, while still learning how to craft perfect potions.<br>Are you ready to unleash your inner alchemist and brew marvelous potions with them, while having fun along the way? <i>Hop in!</i> 🐸🍵✨
</br></br>
<h3>Table of contents</h3>
<a href="https://github.com/gperretta/hop-n-brew/blob/main/README.md#gameplay">Gameplay</a></br>
<a href="https://github.com/gperretta/hop-n-brew/blob/main/README.md#game-mechanics">Game mechanics</a></br>
<a href="https://github.com/gperretta/hop-n-brew/blob/main/README.md#technologies-and-softwares">Technologies and softwares</a></br>
<a href="https://github.com/gperretta/hop-n-brew/blob/main/README.md#visual-and-audio">Visual and audio</a></br>
<a href="https://github.com/gperretta/hop-n-brew/blob/main/README.md#process-and-contributions">Process and contributions</a></br>
<br/><br/>

<div align="center">
  <img src="https://github.com/gperretta/hop-n-brew/assets/113616815/c8bd521a-c7c7-4c24-9d06-65cd2a8dcc8c" width="640">
</div>

<h2>Gameplay</h2>
In Hop'n'Brew, you'll immerse yourself in the world of potion brewing. The gameplay revolves around the art of mixing various ingredients to create potions. <br>Your ultimate goal is to satisfy the demands of a quirky ensemble of clients who will visit Froggo and Tod's alchemy shop seeking magical help for their specific needs.
<br>The potion-crafting process is both engaging and intuitive. You'll have access to a set of enchanted ingredients. To brew a potion, you'll need to carefully combine the right ingredients in the cauldron, experimenting with your creativity. 
<br>As you progress through the game, you'll need to rely on your wit, memory, and potion-making skills to craft the perfect mix that matches needs of each client. Successfully fulfilling a client's request will earn you rewards, and sometimes, the client may gift you with a new ingredient to add to your inventory.
<br></br>
<h2>Game mechanics</h2>
The game core loop revolves around the potion crafting action: when a client will enter the scene, the Unity dialogue system will display the client's request, which sould be carefully read by the player, who will later proceed with mixing 3 different ingredients to find the correct potion. The user can combine the ingredients by using a simple drag-and-drop gesture to put them in the cauldron. <br>Each time a three-ingredients-combination is achieved, a pop-up will show the result of the crafting:<br>
1. no potion has been found by mixing those ingredients;<br>
2. a potion has been found, but it's not the right one - try not to forget it for later;<br>
3. a potion has been found and it's the right one: now you can serve the client!<br>
In the last case, when the client's request has been satisfied, the user will get a reward: a new ingredient to find new potions!
<br><br>The game has been developed to be ideally endless: the user has unlimited attempts and the clients will be spawned continuously with their request. At the moment, it features a limited set of clients and potion requests, but it can be potentially expanded with as many addition as you want.
<br></br>
<h2>Technologies and softwares</h2>
Hop'n'Brew is developed using Unity and C# scripting, optimized for the last iPhone models. The game was distributed for testing using Apple's TestFlight, with the support of Xcode IDE. <br>The two key elements were the Unity input system to handle user gestures and the Unity collision system which is the main foundation of almost all the game dynamics.
<br></br>
<h2>Visual and audio</h2>
All the settings, characters and other GUI elements are entirely hand-drawn by the illustrators of the team.<br>The soundtrack of the game was an original composition by our game audio designer.
<br></br>
<h2>Process and contributions</h2>
Hop'n'Brew is the product of an ideation, research, development and testing process led by a team of six: two developers, a game audio designer and UX designer, two game artists/illustrators (including one animator), a game designer and copywriter. <br>It was born as the final project for the Apple Developer Academy, hence the choice of developing a game for iPhone only.
<br>As the lead developer, my main tasks and responsabilities have been:<br>
- implementing the clients spawning system with random sprites attached;<br>
- implementing the clients' movement and entrance into the scene as NPCs (non-player characters);<br>
- implementing the dialogue system to display the clients' requests;<br>
- implementing the crafting system by handling ingredients combinations and different cases for the result of the crafting;<br>
- coding C# dictionaries to handle the large number of variables for ingredients, potions and requests;<br>
- implementing the GUI: building the main scene, adding various 2D assets, pop-ups, tutorial and ingredients counter;<br>
- adding the title screen and the play button.
