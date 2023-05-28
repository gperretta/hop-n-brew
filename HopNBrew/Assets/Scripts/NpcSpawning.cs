using System;
using System.Collections;
using UnityEngine;

///<summary>
/// - Attached to the Spawn Point game object
/// - Make npc prefab spawn in the spawnPoint gameObject position
///</summary>
public class NpcSpawning : MonoBehaviour
{
    public GameObject npcPrefab;

    private void Start()
    {
        // Spawn the first npc:
        spawnNpc();
    }

    /// <summary>
    /// Spawn the npc prefab
    /// </summary>
    void spawnNpc()
    {
        //TODO: adding SpriteRenderer components for different npc(s)

        // Spawning the prefab (npc) in the spawn point (gameObject)
        Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y, 0);
        // To instantiate/clone the prefab
        Instantiate(npcPrefab, spawnPosition, transform.rotation);
        Debug.Log("New Npc prefab spawned.");
    }
}
