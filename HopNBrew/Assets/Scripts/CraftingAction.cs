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
    private const int slotNumber = 3;
    public int ingredientCounter;
    // To be set with the potion founded as a result for the crafting action
    private string potionToServe;
    private string potionToSave;
    private string combinedKeys;
    public TextMeshProUGUI orderText;

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
    }

    /// <summary>
    /// Detect collision between the pot gameObject and the ingredients gameObject 
    /// </summary>
    /// <param name="collision">Collision2D gameObject component</param>
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
        Debug.Log("Just added: " + draggedIngredient);
        foreach (var ingredient in data.ingredients)
        {
            // Find the added ingredient in the ingredients dictionary
            if (draggedIngredient.Equals(ingredient.Value))
            {
                // Find the associated key
                ingredientKeys[ingredientCounter] = ingredient.Key;
                Debug.Log(ingredient.Value + " has key: " + ingredientKeys[ingredientCounter]);
            }
        }
    }

    /// <summary>
    /// Get the crafting action result, after combining ingredients
    /// </summary>
    /// <returns>a string with the potion name or a void string</returns>
    string getResult()
    {
        string result = " ";
        // Sort the char array containing the ingredients keys
        Array.Sort(ingredientKeys);
        // Make the array into a new string for comparison
        combinedKeys = new string(ingredientKeys);
        foreach (var potion in data.potions)
        {
            if (potion.Key.Equals(combinedKeys))
            {
                result = potion.Value;
            }
        }
        return result;
    }

    //TODO: 4-case scenario for crafting action result
    void checkResult()
    {
        string result = new string(getResult());
        Debug.Log("Result check here...");
        if (!result.Equals(" "))
        {
            // The ingredients combination exist as a "potions" dictionary key
            Debug.Log("Found " + getResult());
            // Checking the potion found against the customer (npc) order
            foreach(var order in data.orders)
            {
                // 1. find the entry in the "orders" dictionary
                if (orderText.text.Equals(order.Value))
                {
                    foreach(var potion in data.potions)
                    {
                        // 2. find the entry in the "potions" dictionary 
                        if (result.Equals(potion.Value))
                        {
                            // 3.1. if their keys are equal the right potion has been found
                            if (order.Key == potion.Key)
                            {
                                Debug.Log("IT'S THE RIGHT POTION");
                            }
                            // 3.2. else a potion has been found, but it's not the right one
                            else
                            {
                                Debug.Log("Wrong potion, try again!");
                            }
                        }
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
