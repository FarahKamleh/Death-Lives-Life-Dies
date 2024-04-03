# Death-Lives-Life-Dies
 A two-player game for the CAVE2 in which both players share all 88 screens but do not see the same image. This is achieved by taking advantage of the stereoscopic shader and giving Player #1, Death, a 2D-L configuration and Player #2, Life, a 2D-R configuration.

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

