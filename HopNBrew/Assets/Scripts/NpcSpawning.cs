using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

///<summary>
/// - Attached to the Spawn Point game object
/// - Make npc prefab spawn in the spawnPoint gameObject position
///</summary>
public class NpcSpawning : MonoBehaviour
{
    public GameObject npcPrefab;
    private GameObject previousNpc;
    public Sprite[] npcSprites;
    public int spriteRandomResult;

    private void Start()
    {
        spawnNpc(); // Spawn the first npc
    }

    private void Update()
    {
        previousNpc = GameObject.FindWithTag("npc");
        if (previousNpc == null) // If there's no previous npc on screen
        {
            spawnNpc();
        }
    }

    /// <summary>
    /// Spawn the npc prefab in the spawn point (gameObject) and with different sprites
    /// </summary>
    void spawnNpc()
    {

        Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y, 0);
        GameObject newNpc = Instantiate(npcPrefab, spawnPosition, transform.rotation);
        newNpc.GetComponent<SpriteRenderer>().sprite = getRandomSprite();
        newNpc.name = getRandomSprite().name;
        newNpc.GetComponent<Animator>().SetInteger("spriteInt", spriteRandomResult);
        Debug.Log(newNpc.name + " spawned.");
    }

    /// <summary>
    /// Get a random sprite to attach to the newly instantiated npc
    /// </summary>
    /// <returns>a sprite randomly picked from the array</returns>
    Sprite getRandomSprite()
    {
        int randomIndex = Random.Range(0, npcSprites.Length);
        spriteRandomResult = randomIndex;
        return npcSprites[randomIndex];
    }
}
