using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// - Attached to the npc prefab element
/// - It will run each time the prefab will be instantiated/cloned
/// </summary>
public class NpcMovement : MonoBehaviour
{
    // To set how fast the prefabs will move
    public float moveSpeed = 5;
    // Calling the dialogueObject prefab to be spawned
    public GameObject dialogueObject;

    void Update()
    {
        // Move to the left
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
        // Move to the right
        //transform.position = transform.position + (Vector3.right * moveSpeed) * Time.deltaTime;
    }

    /// <summary>
    /// Detect collision between the npc and the stopNpc-tagged gameObject
    /// to stop the npc movement and make the dialogue box appear
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("stopNpc"))
        {
            // Stop the movement
            moveSpeed = 0;
            Debug.Log("Collision detected: Npc has stopped.");
            spawnBox();
        }
    }

    /// <summary>
    /// Spawn the dialogueObject prefab
    /// </summary>
    void spawnBox()
    {
        // Spawning the prefab in the assigned position (check prefab inspector)
        Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y, 0);
        // To instantiate/clone the prefab
        Instantiate(dialogueObject, spawnPosition, transform.rotation);
    }
}
