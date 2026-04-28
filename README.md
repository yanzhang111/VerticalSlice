# GDIM33 Vertical Slice
## Milestone 1 Devlog
1.I chose to explain the dialogue Visual Scripting Graph in my game. This Graph controls the process when the player talks to an NPC. When the player walks close to the NPC and presses the interact key, the Graph starts showing the current dialogue. It puts the NPC’s line into the text box on the screen. When the player presses the interact key again, it checks if there is another dialogue node after the current one. If there is, it moves to the next node and updates the text. If there is no next node, it closes the dialogue box and lets the player move normally again. This Graph helps the dialogue move forward step by step, instead of showing everything at once. It can also connect to the quest system. For example, after the player finishes talking to the NPC, it can start a new quest or change the quest state.


2.[break-down](https://docs.google.com/drawings/d/19ndeEQ2fwK5_1Ei4o9wf03d8gsiIuWsXk3kHsQobrTg/edit)



In my new break-down, I mainly added the state machine, Scripting Graph, and the Unity systems I chose this time: Tilemap and Animation. My old break-down was mostly about the basic systems in my game, such as player movement, attack, enemies, NPC dialogue, and quests. Now I added these new systems too.  



My state machine is mainly used to control the enemy’s behavior. It separates the enemy’s behavior into different states, such as Idle, Walk, Attack, and Die. The enemy can only be in one state at a time. This means it will not walk and die at the same time, or stay idle and attack at the same time. For example, when the player is far away, the enemy stays in Idle. When the player enters the detection range, the enemy changes to Walk and starts chasing the player. When the player gets close enough, the enemy changes to Attack. If the enemy’s health reaches 0, it changes to Die. This makes the enemy’s behavior clearer. It also makes it easier for me to change or add things later. 



This state machine is also connected to other systems in my game, It works with the enemy animation system. Different states play different animations, such as idle, walking, attacking, and dying. It is also connected to the attack system. When the enemy enters the Attack state, it triggers the attack effect and deals damage to the player. It is also connected to the enemy health system. When the enemy’s health reaches 0, the state machine changes to the Die state， Then it plays the death animation and destroys the enemy.



## Milestone 2 Devlog
Milestone 2 Devlog goes here.
## Milestone 3 Devlog
Milestone 3 Devlog goes here.
## Milestone 4 Devlog
Milestone 4 Devlog goes here.
## Final Devlog
Final Devlog goes here.
## Open-source assets
- Cite any external assets used here!
