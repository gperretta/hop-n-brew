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
    private CraftingAction craftingScript; 
    private int deathZone = 4;
    private GameObject tutorialObject; // use to Tutorial Object
    private StartGame startGameScript; 

    private void Start()
    {
        // If the gameObject is on scene, get its script
        pot = GameObject.Find("Pot-base");
        if (pot != null)
        {
            craftingScript = pot.GetComponent<CraftingAction>();
        }
        tutorialObject = GameObject.Find("TutorialObject");
        if (tutorialObject != null)
        {
            startGameScript = tutorialObject.GetComponent<StartGame>();
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
            moveSpeed = 0; // Stop the movement
            gameObject.GetComponent<Animator>().speed = 0f; //Stop the animation at the very first frame so the NPC looks still
            gameObject.GetComponent<Animator>().Play(gameObject.GetComponent<Animator>().GetCurrentAnimatorClipInfo(0)[0].clip.name,0,0.0f);
        }
    }

    /// <summary>
    /// Actual npc movement to go in (left direction) and out (right direction) scene
    /// </summary>
    private void moveNpc()
    {
        if (!craftingScript.customerServed && startGameScript.canStart)
        {
            transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
        }
        else
        {
            moveSpeed = 1.5f;
            transform.position = transform.position + (Vector3.right * moveSpeed) * Time.deltaTime;
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            gameObject.GetComponent<Animator>().speed = 1f;
            //gameObject.GetComponent<Animator>().Play(gameObject.GetComponent<Animator>().GetCurrentAnimatorClipInfo(0)[0].clip.name);
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
