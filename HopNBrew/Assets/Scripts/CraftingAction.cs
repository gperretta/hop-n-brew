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
    private string ingredientAdded;
    // Will contain the (dictionary) keys associated to the added ingredients
    private char[] ingredientKeys;
    // To check the number of slots filled
    //FIXME: max = ingredientKeys lenght [TEST]
    public int ingredientCounter;
    // Flag to stop adding ingredients when a potion is found
    //FIXME: [TEST]
    // To be set with name of the potion found 
    private bool isFound;
    private string potionFound;

    /// <summary>
    /// Init variables; it runs when the game starts.
    /// </summary>
    private void Start()
    {
        // Call a zero-argument constructor for Crafting class
        data = new DataModel();
        // Set lenght (static array)
        ingredientKeys = new char[2];
        // Reset counter
        ingredientCounter = 0;

        isFound = false;
    }

    /// <summary>
    /// Detect collision between the pot gameObject and the ingredients gameObject 
    /// </summary>
    /// <param name="collision"></param>
    void OnCollisionEnter2D(Collision2D collision)
    {
        //FIXME: when a potion is found, the crafting actions stops [TEST]
        if (!isFound && (ingredientCounter < ingredientKeys.Length))
        {
            if (collision.gameObject.CompareTag("ingredient"))
            {
                Debug.Log("counter " + ingredientCounter);
                // Get the name of the gameObject involved in the collision event
                ingredientAdded = collision.gameObject.name;
                // Perform crafting
                getIngredientKey(ingredientAdded);
                // Increase counter and move on the char array
                ingredientCounter += 1;
            }
        }
        //TODO: this should be a switch case (and maybe a separate check-result function)
        if (ingredientCounter == ingredientKeys.Length)
        {
            if (getResult() != " ")
            {
                potionFound = getResult();
                Debug.Log("Found " + potionFound);
                //TODO: SOMETHING ELSE HAPPENS
                isFound = true;
            } else
            {
                Debug.Log("No potion found! Try again.");
                //TODO: SOMETHING ELSE HAPPENS
                isFound = false;
                //FIXME: Reset counter to try again [TEST]
                ingredientCounter = 0;
            }
        }
    }

    /// <summary>
    /// Get the ingredients key from the dictionary and put them in the ingredientKeys array
    /// </summary>
    /// <param name="ingredientName"></param>
    void getIngredientKey(string ingredientName)
    {
        Debug.Log("Just added: " + ingredientAdded);
        foreach (var ingredient in data.ingredients)
        {
            // Find the added ingredient in the ingredients dictionary
            if (ingredientAdded == ingredient.Value)
            {
                Debug.Log(ingredient.Value + " is a correct ingredient!");
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

        foreach (var potion in data.potions)
        {
            // Find a potion which key contains ingredients keys in the potions dictionary
            if (potion.Key.Contains(ingredientKeys[0]) && potion.Key.Contains(ingredientKeys[1]))
            {
                result = potion.Value;
            }
        }
        return result;
    }
}
