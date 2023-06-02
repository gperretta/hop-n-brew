using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.Mathematics;
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
    // To track the ingredients on scene 
    private int ingredientsCounter;

    private void Start()
    {
        // Call a zero-argument constructor for Crafting class
        data = new DataModel();
        // Reset counter
        ingredientsCounter = 0;
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
            // 2. display the text dynamically
            displayOrder();
        }
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
    /// Check the ingredients on scene and count them
    /// </summary>
    /// <returns>An int number being the updated ingredientsCounter</returns>
    private int checkIngredients()
    {
        foreach (var ingredient in data.ingredients)
        {
            if (GameObject.Find(ingredient.Value) != null) { ingredientsCounter += 1; }
        }
        return ingredientsCounter;
    }

    /// <summary>
    /// Get a random (string) value from the orders dictionary
    /// </summary>
    /// <param name="dictionary">Dictionary to extract a Value from</param>
    /// <param name="rangeStart">Upper bound of the range (included)</param>
    /// <param name="rangeEnd">Lower bound of the range (not included)</param>
    /// <returns>The extracted string</returns>
    private string getRandomOrder(Dictionary<string, string> dictionary, int rangeStart, int rangeEnd)
    {
        // Convert the collection of the dictionary values into a list
        // NOTE: dictionaries do not support ordered indexing or sorting in C#
        List<string> valuesList = new List<string>(dictionary.Values);
        // Get a random index in a given range
        int randomIndex = Random.Range(rangeStart, rangeEnd + 1);
        return valuesList[randomIndex];
    }

    /// <summary>
    /// Pass the order (picked randomly from a given range) to TextMeshPro object
    /// </summary>
    private void displayOrder()
    {
        int trimIndex = checkIngredients();
        orderText.text = getRandomOrder(data.orders, 0, trimIndex-1);
    }
}
