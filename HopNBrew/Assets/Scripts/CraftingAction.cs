using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

/// <summary>
/// - Attached to the Pot gameObject
/// - It will run when an ingredient collides with the pot (when crafting action starts)
/// </summary>
public class CraftingAction : MonoBehaviour
{
    private DataModel data;
    private string draggedIngredient; // for ingredients that collided with the pot
    private char[] ingredientKeys; // (dictionary) keys associated to the added ingredients
    private const int slotNumber = 3;
    public int ingredientCounter; // to track the added/combined ingredients in the slots
    private string playerCombination; // to track player's ingredients combination
    public TextMeshProUGUI orderText;
    public bool potionIsRight; 
    public bool customerServed;
    // Display a pop-up with the result of the crafting action
    public GameObject popUpCanvas;
    public TextMeshProUGUI messageText;
    private string rightPotion = "\nIt's the right one, now you can serve the customer!";
    private string wrongPotion = "\nIt's not the right one, but you can try again!";
    private string notAPotion = "Something went wrong, this combination is not a potion, but let's try again!";

    private void Start()
    {
        // Call a zero-argument constructor for Crafting class
        data = new DataModel();
        // Set lenght (static array)
        ingredientKeys = new char[slotNumber];
        // Reset counter
        ingredientCounter = 0;
        customerServed = false;
        potionIsRight = false;
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
            if (potion.Key.Equals(playerCombination))
            {
                return new string("It's a " + potion.Value + "! ");
            }
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
            // Checking the potion found against the customer (npc) order
            foreach (var order in data.orders)
            {
                // 1. find the entry in the "orders" dictionary
                if (orderText.text.Equals(order.Value))
                {
                    // 2. check if its key is equal to the player's crafted potion
                    if (order.Key == playerCombination)
                    {
                        StartCoroutine(displayPopUp(getResult() + rightPotion));
                        potionIsRight = true;
                    } else
                    {
                        StartCoroutine(displayPopUp(getResult() + wrongPotion));

                    }
                }
            }
        }
        else
        {
            // The ingredients combination doesn't exist as a "potions" dictionary key
            StartCoroutine(displayPopUp(notAPotion));
            
        }
    }

    /// <summary>
    /// Coroutine for the pop-up appearance (with a 0.3 sec delay)
    /// </summary>
    /// <param name="message">A string to pass to text element</param>
    /// <returns></returns>
    IEnumerator displayPopUp(string message)
    {
        Debug.Log("POPUP");
        yield return new WaitForSeconds(0.3f);
        popUpCanvas.SetActive(true);
        messageText.text = message;
    }

    /// <summary>
    /// Function called by the button: Exit 
    /// </summary>
    public void exitPopUp()
    {
        Debug.Log("EXIT");
        popUpCanvas.SetActive(false);
        // Change the state of the order
        if (potionIsRight)
        {
            customerServed = true;
        }
    }
}
