using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

/// <summary>
/// - Attached to StartDialoguePoint gameObject
/// - To display a dynamic text in a dialogue box,
/// after checking the feasibility of the customer (npc) request
/// </summary>
public class DialogueManager : MonoBehaviour
{
    // Use the dialogueCanvas where the Text is contained
    public GameObject dialogueCanvas;
    // Use the TextMeshPro object to display the order
    public TextMeshProUGUI orderText;
    // Use the DataModel class, where the dictionaries are defined (ingredients and potions lists)
    private DataModel data;
    // To use the dictionary values collection as a list of strings
    List<string> ordersList = new List<string>();

    private void Start()
    {
        // Call a zero-argument constructor for Crafting class
        data = new DataModel();
    }

    /// <summary>
    /// Detect collision between an empty gameObject (StartDialoguePoint) and the npc
    /// </summary>
    /// <param name="collision">npc Collision2D component</param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // When the npc gets to the stopping + starting-dialogue point
        if (collision.gameObject.CompareTag("npc"))
        {
            // 1. make the dialogue box visible
            activateDialogueCanvas();
            // 2. check which orders are currently feasible
            checkFeasibileOrders();
            // 3. display one of the feasible order as a text
            displayOrder();
        }
    }

    /// <summary>
    /// Detect when the empty gameObject (StartDialoguePoint) and the npc stops touching
    /// </summary>
    /// <param name="collision">npc Collision2D component</param>
    private void OnCollisionExit2D(Collision2D collision)
    {
        deactivateDialogueCanvas();
    }

    /// <summary>
    /// Set the DialogueCanvas gameObject active
    /// Pre-condition: visibility unchecked in the inspector
    /// </summary>
    void activateDialogueCanvas()
    {
        dialogueCanvas.SetActive(true);
    }

    /// <summary>
    /// Set the DialogueCanvas gameObject not active
    /// Pre-condition: previously activated by collision trigger
    /// </summary>
    void deactivateDialogueCanvas()
    {
        dialogueCanvas.SetActive(false);
    }

    /// <summary>
    /// Remove from the orders list the ones that are not feasible
    /// </summary>
    private void checkFeasibileOrders()
    {
        // Copy all the orders values (string) in the list
        ordersList.AddRange(data.orders.Values);
        foreach (var ingredient in data.ingredients)
        {
            // If an ingredient is not on scene is NOT mixable
            if (GameObject.Find(ingredient.Value) == null)
            {
                foreach (var order in data.orders)
                {
                    // Remove from the values list the ingredients that CAN'T be mixed
                    if (order.Key.Contains(ingredient.Key))
                    {
                        ordersList.Remove(order.Value);
                    }
                }
            }
        }
    }

    /// <summary>
    /// Pick a random order within the feasible one
    /// </summary>
    private void displayOrder()
    {
        // Get a random index
        int randomIndex = Random.Range(0, ordersList.Count());
        // Set the TextMeshPro text input
        orderText.text = ordersList[randomIndex];
    }
}
