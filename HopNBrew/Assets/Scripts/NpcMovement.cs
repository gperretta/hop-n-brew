using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// - Attached to the npc prefab element
/// - It will run each time the prefab will be instantiated/cloned
/// - move speed: how fast the prefabs will move (to the left)
/// </summary>
public class NpcMovement : MonoBehaviour
{
    public float moveSpeed = 5;

    void Update()
    {
        // Move to the left:
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

        // Move to the right:
        //transform.position = transform.position + (Vector3.right * moveSpeed) * Time.deltaTime;
    }

    // Stops the npc when it gets close to the shop:
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("stop"))
        {
            moveSpeed = 0;
            Debug.Log("[DEBUG] Collision detected.");
        }
    }
}
