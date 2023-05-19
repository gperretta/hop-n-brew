using System;
using System.Collections;
using UnityEngine;

/// <summary>
/// - Behaviour: handling the NPC spawning in an off-screen position and with different sprites.
/// - Attached to the Spawn Point game object
/// - Make prefabs (npc) spawn in Spawn Point position
/// - spawn rate: time interval between one spawning and the other
/// - spawn timer: it will be increased by adding delta time
/// - spawn timer -> expired when it will be equal to spawn rate (max waiting time)
/// </summary>
public class NpcSpawning : MonoBehaviour
{
    public GameObject npcPrefab;
    public float spawnRate = 2;
    public float spawnTimer = 0;

    private void Start()
    {
        // Spawn the first npc:
        spawnNpc();
    }

    // NOTE: multiple npc(s) spawning game logic yet to define!
    /**
    void Update()
    {
        // Handle prefab spawning/cloning + waiting time
        if (spawnTimer < spawnRate)
        {
            // If timer is running then increase the timer
            // by adding delta time (time interval between frames):
            spawnTimer += Time.deltaTime;
        }
        else
        {
            // If timer expired then spawn the object:
            spawnNpc();
            // Reset the timer:
            spawnTimer = 0;
        }
    }
    **/

    void spawnNpc()
    {
        // MISSING other components -> random sprite render? 

        // Spawning the prefab (npc) in the spawn point (game object):
        Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y, 0);

        // To instantiate/clone the prefab:
        Instantiate(npcPrefab, spawnPosition, transform.rotation);
        Debug.Log("[DEBUG] New prefab spawned");
    }
}
