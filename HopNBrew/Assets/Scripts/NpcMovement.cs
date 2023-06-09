using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// - Attached to the npc prefab element
/// - It will run each time the prefab will be instantiated/cloned
/// </summary>
public class NpcMovement : MonoBehaviour
{
    private float moveSpeed = 2;
    private GameObject pot; // use the Pot gameObject 
    private CraftingAction craftingScript; // to get the script component
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
        moveNpc();
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

    /// <summary>
    /// Actual npc movement to go in (left direction) and out (right direction) scene
    /// </summary>
    private void moveNpc()
    {
        // TODO: optimise/clean code block
        if (!craftingScript.customerServed)
        {
            transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
        }
        else
        {
            moveSpeed = 1.5f;
            transform.position = transform.position + (Vector3.right * moveSpeed) * Time.deltaTime;
            checkScreenBoundaries();
        }
    }

    /// <summary>
    /// Destroy npc when off-screen
    /// </summary>
    private void checkScreenBoundaries()
    {
        if (transform.position.x > deathZone)
        {
            craftingScript.customerServed = false;
            Destroy(gameObject);
        }
    }
}
