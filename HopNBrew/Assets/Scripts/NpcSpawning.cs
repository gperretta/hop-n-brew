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
    private GameObject previousNpc;

    private void Start()
    {
        // Spawn the first npc
        spawnNpc();
    }

    private void Update()
    {
        previousNpc = GameObject.FindWithTag("npc");
        // If there's no previous npc on screen
        if (previousNpc == null)
        {
            spawnNpc();
        }
    }

    /// <summary>
    /// Spawn the npc prefab
    /// </summary>
    void spawnNpc()
    {
        //TODO: adding SpriteRenderer components for different npc(s)

        // Spawning the prefab (npc) in the spawn point (gameObject)
        Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y, 0);
        Instantiate(npcPrefab, spawnPosition, transform.rotation);
        Debug.Log("New Npc prefab spawned.");
    }
}
