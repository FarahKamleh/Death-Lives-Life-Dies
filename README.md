# Death-Lives-Life-Dies
 A two-player game for the CAVE2 in which both players share all 88 screens but do not see the same image. This is achieved by taking advantage of the stereoscopic shader and giving Player #1, Death, a 2D-R configuration and Player #2, Life, a 2D-L configuration.

## Assignment 6
### Additions and their design philosophy
<ul>
    <li>
        Foggy "Rough Terrain" will slow players down if they stand inside of it. An unholy apparition, it slowly creeps toward a target player, navigating the maze to find them, but it can lose interest after a time and switch its focus to another target.
    </li>
    <li>
        Thematically appropriate maze walls, with forested overgrowth for Life and a dingy cornfield for Death (subject to change for cohesion between sides of the map). The ground, as well, shifts in vibrancy from Life to Death's sides of the map.
    </li>
    <li>
        A bow which fires glowing green seeds has been added for Life. It can do damage to Death if struck, but has a slight cooldown so that Death cannot be killed too quickly. This weapon, Life's counterpart to Death's scythe, fits the character's theme well.
    </li>
    <li>
        Additional HUD elements for character-specific powerups has been added. They are colored and identifiable as belonging to each character. The collectable powerup orb, too, has been altered to feature a heavenly light above it, helping to denote its location on the map.
    </li>
    <li>
        There are another two AI elements--an assistant for each character. Each assistant will attack the opposing player if nearby, or will point their respective player in the direction of their target, turning to face either Death or the Newborn depending on their master
    </li>
    <li>
        The newborn now wanders around the maze, avoiding Life and Death at the same time. The newborn spawns at the center of the map. It runs away from Death to avoid getting killed, and it runs away from Life so that Life can't safely guard it.
    </li>
</ul>
Each of these new elements follows intentional design elements of the game, both in their appearance and in their contribution to gameplay. They offer new resources and procedures for each of the players to make use of.

<br>

### AI/Mechanim contributions:
<ul>
    <li>
        Farah
        <ul>
            <li>
                AI: Life and Death's assistants
            </li>
            <li>
                Mechanim: Life's movement
            </li>
        </ul>
    </li>
    <li>
        Sebastian:  
        <ul>
            <li>
                AI: Newborn's movement
            </li>
            <li>
                Mechanim: Life's assistant
            </li>
        </ul>
    </li>
    <li>
        Julian
        <ul>
            <li>
                AI: Rough Terrain pathfinding and player targeting
            </li>
            <li>
                Mechanim: Death's assistant
            </li>
        </ul>
    </li>
</ul>

### Additional contributions:
<ul>
    <li>
        Farah 
        <ul>
            <li>
                Textures: Special item replacement
            </li>
            <li>
                Lights: Spotlight for special item
            </li>
            <li>
                Physics: Finish special item for both players
            </li>
        </ul>
    </li>
    <li>
        Sebastian
        <ul>
            <li>
                Textures: Floor terrain texture
            </li>
            <li>
                Lights: Glowing bullet/arrow from Life's weapon
            </li>
            <li>
                Physics: Life's weapon (bow)
            </li>
        </ul>
    </li>
    <li>
        Julian
        <ul>
            <li>
                Textures: New sprites for maze, UI, and special items
            </li>
            <li>
                Lights: Changing the skybox and uniform lighting
            </li>
            <li>
                Physics: Rough Terrain that slows player movement
            </li>
        </ul>
    </li>
</ul>

## Assignment 7
### UI and Sound Design Updates
<ul>
    <li>
     Farah:
     <ul>
       <li>
        For the UI design updates, CAVE2-related issues have been resolved. For example, gameobjects such as the newborn, skeleton, wolf, and rough terrain exhibited synchronization issues across the cluster; therefore, in order to remedy this, a script titled "CAVE2 Transform Script" had been added as a component to them all. Similarly, a misalignment of Life's health bars in the center of the CAVE2 revealed a glaring issue: the position and rotation of Player #1 unintentionally affected the view of Player #2. This was fixed by adjusting the view-related script. Lastly, the standard CAVE2 project description canvas has been added and updated not only for future demonstrations, but to also instruct the user regarding the controls.
       </li>
      <li>
       For the sounds, to improve upon feedback, when Player #2, Life, shoots using their bow and "arrow", a thwump sound occurs after the release, informing the user of their action. Similarly, when the user triggers an acquired special item, either a stone wall or bush rustle sound effect occurs, matching the material of the raised walls. Lastly, when Death is within proximity of either the newborn or Life, a violin shrieks, alerting the players of their wherabouts and potential dangers.
      </li>
     </ul>
   </li>
  <li>
   Julian:
     <ul>
      <li>
       Breaking the principle of learnability were the skeleton and wolf assistants; previously, it was not clear to the user what their purpose is within the game. Now, with the addition of dynamic speeh bubble icons, context is provided based on their reactions, allowing the player to infer that they will either assist or harm. To improve upon feedback, a small change to the position of the tombstone sprite has been made, placing it in front of the container sprite to inform the user that they have successfully collected a special item to be used when they please. Lastly, after having successfully harmed either the newborn or Death five times, there was no indication that the game had been won. Therefore, a text has been added to either say, "Death lives, Life dies" or "Death dies, Life lives" depending on the outcome.
      </li>
      <li>
      For the newborn, a proximity loop was chosen becayse it is an ethereal drone loop that complements the piritual nature of the newborn. It additionally serves as a hint to players of where it is, as it can be quietly heard through adjacent walls. The special item pickup jingle serves as a piece of ausitory feedback for the players upon picking up a special item. As it appears as a sort of relic, the sound effect evokes a trinket-like jingle, combining with the visual pickup indicator to let the player know that they now possess a new ability. Finally, the ambient wind loop was chosen specifically due to its connection to the game's scenery. The walls are composed partially of green pine trees, and the free audio loop is actually a recording taken in a windy pine forest. This empty feeling also gives the map a feeling of vastness and mystery.
      </li>
     </ul>
    </li>
    <li>
     Sebastian:
     <ul>
      <li>
       Previously, the newborn would get stuck on the edges of the map after running away from both players. Now, the newborn should find its way to the landmark that is farhest from the player that is chasing the newborn. For additional UI updates, two button indicators have been added to improve learnability for the game. The L1 indicator for Life's bow tells the player that they can shoot the bow using the L1 button and the L2 indicator reminds both players that the L2 button triggers a collected special item. To minimize error that occurs as a result of a lack of depth perception in the CAVE2 (left eye only), the hitbox for Death has been increased to increase the chances of Life hitting Death.
      </li>
      <li>
      When Death hits the newborn, a sound effect occurs which adds to the visual feedback of the newborn's dimming light. Similarly, a sound effect occurs when Life hits Death with a seed bullet. This helps inform Life's player that they successfully hit their target. Lastly, when Death hits the tree wall or Life hits the tombstone wall, sound effects occur to provide feedback.
      </li>
     </ul>
    </li>
</ul>
