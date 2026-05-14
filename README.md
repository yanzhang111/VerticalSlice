# GDIM33 Vertical Slice
## Milestone 1 Devlog
1.I chose to explain the dialogue Visual Scripting Graph in my game. This Graph controls the process when the player talks to an NPC. When the player walks close to the NPC and presses the interact key, the Graph starts showing the current dialogue. It puts the NPC’s line into the text box on the screen. When the player presses the interact key again, it checks if there is another dialogue node after the current one. If there is, it moves to the next node and updates the text. If there is no next node, it closes the dialogue box and lets the player move normally again. This Graph helps the dialogue move forward step by step, instead of showing everything at once. It can also connect to the quest system. For example, after the player finishes talking to the NPC, it can start a new quest or change the quest state.


2.[break-down](https://docs.google.com/drawings/d/19ndeEQ2fwK5_1Ei4o9wf03d8gsiIuWsXk3kHsQobrTg/edit)



In my new break-down, I mainly added the state machine, Scripting Graph, and the Unity systems I chose this time: Tilemap and Animation. My old break-down was mostly about the basic systems in my game, such as player movement, attack, enemies, NPC dialogue, and quests. Now I added these new systems too.  



My state machine is mainly used to control the enemy’s behavior. It separates the enemy’s behavior into different states, such as Idle, Walk, Attack, and Die. The enemy can only be in one state at a time. This means it will not walk and die at the same time, or stay idle and attack at the same time. For example, when the player is far away, the enemy stays in Idle. When the player enters the detection range, the enemy changes to Walk and starts chasing the player. When the player gets close enough, the enemy changes to Attack. If the enemy’s health reaches 0, it changes to Die. This makes the enemy’s behavior clearer. It also makes it easier for me to change or add things later. 



This state machine is also connected to other systems in my game, It works with the enemy animation system. Different states play different animations, such as idle, walking, attacking, and dying. It is also connected to the attack system. When the enemy enters the Attack state, it triggers the attack effect and deals damage to the player. It is also connected to the enemy health system. When the enemy’s health reaches 0, the state machine changes to the Die state， Then it plays the death animation and destroys the enemy.



## Milestone 2 Devlog
1.This Milestone 2 complicating gameplay feature was originally going to be adding my Boss and giving him a second phase. However, I already wrote about that part during the Week 5 in-class activity, so for this devlog I am choosing another feature. My game is a 2D platformer, so I want to write about creating a more complete platform level design. My game is not only about fighting enemies. The player also needs to move, jump, and explore between different areas. In Milestone 1, the player’s basic movement, jumping, and attacking already worked, but the level itself was still pretty simple. So for this Milestone, I wanted to add more platforming challenges.




### Step 1: Plan the overall platform level design

1.First, I will look at some other 2D platformer games as references and observe how they arrange platforms, traps, enemies, and rewards.

2.I will look at more than one reference, so I can compare different level rhythms and design styles.

3.I will draw a rough level sketch on my iPad or on paper, and plan where the collectible items should be placed and which areas can encourage the player to explore.

4.I will plan the enemy placement, such as where normal enemies should go and which areas should not be too difficult.

5.I will think about the flow of the whole level, including where the player should feel challenged or punished, and where the player should receive rewards, so the level does not feel stressful all the time.

6.After that, I should have a complete level design plan.



### Step 2: Build the basic platform route in Unity

1.Based on the design plan from Step 1, I will use Tilemap in Unity to build the main terrain and platform positions first.

2.I will not add too many decorations at the beginning. The main focus is to make sure the player can move, jump, and pass through this area normally.

3.I will place platforms with different heights and distances based on the sketch, and test whether the player can jump through them smoothly.

4.I will adjust the distance between platforms, so some jumps are not too easy, but also not impossible for the player.

5.I will place the basic collectible items and enemy positions first, and make sure they do not block the player’s main route.

6.I will test the full route from the start of the level to the end, and make sure the player can finish the whole platform area without any bugs.



### Step 3: Add decorations and do a full test

1.Based on the level theme, I will add decorations such as background details, ground details, wall decorations, plants, lighting, or other environment objects, so the level does not look like it is only made of basic blocks.

2.When I add decorations, I need to make sure they do not affect the player’s judgment. Dangerous areas and platforms that the player can stand on should be clear, so the player can tell where they can go and where they might get hurt.

3.Finally, I will test the whole level from start to finish. I need to make sure the player can complete the route, the enemies can create pressure, the rewards can be collected, and the decorations do not block the player or affect the controls.



2.
## Milestone 3 Devlog
Milestone 3 Devlog goes here.
## Milestone 4 Devlog
Milestone 4 Devlog goes here.
## Final Devlog
Final Devlog goes here.



## Open-source assets
1.[Health Bar](https://assetstore.unity.com/packages/tools/game-toolkits/health-system-lite-health-bar-hitbox-248090)



2.[Enemy](https://assetstore.unity.com/packages/2d/characters/2d-monster-cute-chibi-demo-pack-unique-skill-animated-prefab-wit-296969) 



3.[Platfrom](https://assetstore.unity.com/packages/2d/environments/2d-enchanted-forest-tileset-pack-199589)



4.[NPC](https://assetstore.unity.com/packages/2d/characters/cute-2d-girl-wizard-155796)



5.[Player](https://otsoga.itch.io/eleonore)



6.[Boos](https://papoycore.itch.io/fantazy-30)
