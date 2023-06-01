using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// - Attached to the pot gameObject
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
    // To check the number of slots filled
    //max = ingredientKeys lenght 
    public int ingredientCounter;
    // To be set with the potion founded as a result for the crafting action
    private string potionToServe;
    private string potionToSave;

    /// <summary>
    /// Init variables; it runs when the game starts.
    /// </summary>
    private void Start()
    {
        // Call a zero-argument constructor for Crafting class
        data = new DataModel();
        // Set lenght (static array)
        ingredientKeys = new char[3];
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
        if (ingredientCounter < ingredientKeys.Length)
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
        if (ingredientCounter == ingredientKeys.Length)
        {
            Debug.Log("Found " + getResult());
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
            if (draggedIngredient == ingredient.Value)
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
        string combinedKeys = new string(ingredientKeys);
        foreach (var potion in data.potions)
        {
            if (potion.Key == combinedKeys)
            {
                result = potion.Value;
            }
        }
        return result;
    }

    //TODO: 4-case scenario for crafting action result
    void checkResult()
    {
        Debug.Log("Result check here...");
        // IF ISNEW AND ISREQUESTED
        // IF !ISNEW AND ISREQUESTED
        // IF ISNEW AND !ISREQUESTED
        // IF !ISNEW AND !ISREQUESTED
    }
}
