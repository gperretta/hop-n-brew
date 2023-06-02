using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// - Attached to the Pot gameObject
/// - It will run when an ingredient collides with the pot (when crafting action starts)
/// </summary>
public class CraftingAction : MonoBehaviour
{
    // Use the DataModel class, where the dictionaries are defined (ingredients and potions lists)
    private DataModel data;
    // To be set with the name of the ingredient that collides with the pot
    private string draggedIngredient;
    // Will contain the (dictionary) keys associated to the added ingredients
    private char[] ingredientKeys;
    // Max number of ingredients to be added/combined
    private const int slotNumber = 3;
    // To track the added/combined ingredients in the slots
    public int ingredientCounter;
    // Utility variable to track player's ingredients combination
    private string playerCombination;
    // To check the customer (npc) order vs the crafted potion
    public TextMeshProUGUI orderText;
    // To track the state of the order
    public bool customerServed;

    /// <summary>
    /// Init variables; it runs when the game starts.
    /// </summary>
    private void Start()
    {
        // Call a zero-argument constructor for Crafting class
        data = new DataModel();
        // Set lenght (static array)
        ingredientKeys = new char[slotNumber];
        // Reset counter
        ingredientCounter = 0;
        customerServed = false;
    }

    /// <summary>
    /// Detect collision between the pot gameObject and the ingredients gameObject 
    /// </summary>
    /// <param name="collision">ingredient Collision2D component</param>
    void OnCollisionEnter2D(Collision2D collision)
    {
        // When the slots are not filled
        if (ingredientCounter < slotNumber)
        {
            if (collision.gameObject.CompareTag("ingredient"))
            {
                // Get the name of the gameObject involved in the collision event
                draggedIngredient = collision.gameObject.name;
                // Perform crafting
                addIngredientKeys(draggedIngredient);
                // Increase counter and move on the char array
                ingredientCounter += 1;
            }
        }
        // After the slots got filled
        if (ingredientCounter == slotNumber)
        {
            checkResult();
            // To start the crafting action again
            ingredientCounter = 0;
        }
    }

    /// <summary>
    /// Get the ingredients key from the dictionary and put them in the ingredientKeys array
    /// </summary>
    /// <param name="ingredientName"></param>
    void addIngredientKeys(string ingredientName)
    {
        foreach (var ingredient in data.ingredients)
        {
            // Find the added ingredient in the ingredients dictionary
            if (draggedIngredient.Equals(ingredient.Value))
            {
                // Find the associated key
                ingredientKeys[ingredientCounter] = ingredient.Key;
                Debug.Log("Added: " + ingredient.Value + " (" + ingredient.Key + ")");
            }
        }
    }

    /// <summary>
    /// Get the crafting action result, after combining ingredients 
    /// </summary>
    /// <returns>A string with the potion name or -1</returns>
    string getResult()
    {
        // Sort the char array containing the ingredients keys
        Array.Sort(ingredientKeys);
        // Make the array into a new string for comparison
        playerCombination = new string(ingredientKeys);
        foreach (var potion in data.potions)
        {
            // If the player's combination is an existing potion, then return it
            if (potion.Key.Equals(playerCombination)){ return potion.Value; }
        }
        return new string("-1");
    }

    // TODO: condition-checks on the potion book yet to add
    void checkResult()
    {
        string resultToCheck = new string(getResult());

        // If a potion has been crafted, then check the associated scenario
        if (!resultToCheck.Equals("-1"))
        {
            // The ingredients combination exist as a "potions" dictionary key
            Debug.Log("Found " + getResult());
            // Checking the potion found against the customer (npc) order
            foreach(var order in data.orders)
            {
                // 1. find the entry in the "orders" dictionary
                if (orderText.text.Equals(order.Value))
                {
                    // 2. check if its key is equal to the player's crafted potion
                    if (order.Key == playerCombination)
                    {
                        Debug.Log("IT'S THE RIGHT POTION");
                        // Change the state of the order
                        customerServed = true;
                    } else
                    {
                        Debug.Log("It's not the right potion, try again!");
                    }
                }
            }
        }
        else
        {
            // The ingredients combination doesn't exist as a "potions" dictionary key
            Debug.Log("Potion not found.");
        }
    }
}
