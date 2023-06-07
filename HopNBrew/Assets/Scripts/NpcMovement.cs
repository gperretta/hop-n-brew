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
    private float moveSpeed = 2;
    // Use the Pot gameObject to get its script component
    private GameObject pot;
    private CraftingAction craftingScript;
    // FIXME: to track when the npc can be destroyed 
    private int deathZone = 4;

    private void Start()
    {
        // If the gameObject is on scene, get its script
        pot = GameObject.Find("Pot");
        if (pot != null)
        {
            craftingScript = pot.GetComponent<CraftingAction>();
        }
    }

    void Update()
    {
        // TODO: optimise/clean code block
        if (!craftingScript.customerServed)
        {
            // Move to the left to enter on scene
            transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
        } else
        {
            // Move to the right to get out
            moveSpeed = 1.5f;
            transform.position = transform.position + (Vector3.right * moveSpeed) * Time.deltaTime;
            // Destroy off-screen
            if (transform.position.x > deathZone)
            {
                craftingScript.customerServed = false;
                Destroy(gameObject);
            }
        }
    }

    /// <summary>
    /// Detect collision between the npc and the stopNpc-tagged gameObject
    /// to stop the npc movement and make the dialogue box appear
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("stopNpc") && !craftingScript.customerServed)
        {
            // Stop the movement
            moveSpeed = 0;
        }
    }
}
