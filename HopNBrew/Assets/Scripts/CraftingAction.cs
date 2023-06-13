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
    private int ingredientCounter; // to track the added/combined ingredients in the slots
    public TextMeshProUGUI counterText;
    private string playerCombination; // to track player's ingredients combination
    public TextMeshProUGUI orderText;
    private bool potionIsRight; 
    public bool customerServed;
    // Display a pop-up with the result of the crafting action
    public GameObject popUpCanvas;
    public TextMeshProUGUI messageText;
    // Handle the reward 
    public GameObject rewardTrigger;
    private RewardSystemHandler rewardScript;
    // Message sample(s)
    private string rightPotion = "\nIt's the right potion, congrats! \nNow you can serve the customer and get an awesome reward.";
    private string wrongPotion = "\nIt seems you've found a potion. \nUnluckly, it's not the right one, let's try again.";
    private string notAPotion = "Sorry, this combination is not quite right, but don't worry, you can always try again!";

    private int npcCounter;

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
        rewardScript = rewardTrigger.GetComponent<RewardSystemHandler>();

        npcCounter = 0;
    }

    /// <summary>
    /// Detect collision between the pot gameObject and the ingredients gameObject
    /// until the slots (=3) are filled, check the crafting result and start again
    /// </summary>
    /// <param name="collision">ingredient Collision2D component</param>
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (ingredientCounter < slotNumber) // When the slots are not filled
        {
            if (collision.gameObject.CompareTag("ingredient"))
            {
                draggedIngredient = collision.gameObject.name;
                addIngredientKeys(draggedIngredient);
                ingredientCounter += 1;
                counterText.text = ingredientCounter.ToString();
            }
        }
        if (ingredientCounter == slotNumber) // After the slots got filled
        {  
            checkResult();
            ingredientCounter = 0; // To start the crafting action again
        }
    }

    /// <summary>
    /// Get the ingredients keys from the dictionary and put them
    /// in the ingredientKeys char array
    /// </summary>
    /// <param name="ingredientName"></param>
    void addIngredientKeys(string ingredientName)
    {
        foreach (var ingredient in data.ingredients)
        {
            if (draggedIngredient.Equals(ingredient.Value))
            {
                ingredientKeys[ingredientCounter] = ingredient.Key;
                Debug.Log("Added: " + ingredient.Value + " (" + ingredient.Key + ")");
            }
        }
    }


    /// <summary>
    /// Check crafting result:
    /// IF the ingredients combination makes in a potion, check against the customer (npc) order
    /// ELSE the ingredients combination doesn't make an existing potion
    /// </summary>
    void checkResult()
    {
        string resultToCheck = new string(getPotion());
        if (!resultToCheck.Equals("-1"))
        {
            checkOrderedPotion();
        }
        else
        {
            StartCoroutine(displayPopUp(notAPotion));
            potionIsRight = false;
        }
    }

    /// <summary>
    /// Get the crafting action result, after combining ingredients,
    /// by comparing the combined ingredients keys with the potion keys
    /// </summary>
    /// <returns>A string with the potion name or -1</returns>
    string getPotion()
    {
        playerCombination = new string(ingredientKeys);
        foreach (var potion in data.potions)
        {
            if (potion.Key.Equals(playerCombination))
            {
                return new string("It's a " + potion.Value + ".");
            }
        }
        return new string("-1");
    }

    /// <summary>
    /// Checking the potion found against the customer(npc)order
    /// </summary>
    void checkOrderedPotion()
    {
        foreach (var order in data.orders)
        {
            // 1. find the entry in the "orders" dictionary
            if (orderText.text.Equals(order.Value))
            {
                // 2. check if its key is equal to the player's crafted potion
                if (order.Key == playerCombination)
                {
                    StartCoroutine(displayPopUp(getPotion() + rightPotion));
                    potionIsRight = true;
                    npcCounter++;
                }
                else
                {
                    StartCoroutine(displayPopUp(getPotion() + wrongPotion));
                    potionIsRight = false;
                }
            }
        }
    }

    /// <summary>
    /// Coroutine for the pop-up appearance (with a 0.3 sec delay)
    /// </summary>
    /// <param name="message">A string to pass to text element</param>
    /// <returns></returns>
    IEnumerator displayPopUp(string message)
    {
        yield return new WaitForSeconds(0.3f);
        popUpCanvas.SetActive(true);
        messageText.text = message;
    }

    /// <summary>
    /// Function called by the button: Exit
    /// IF the potion is not the ordered one, do nothing
    /// ELSE the customer will be served and the player will get a reward
    /// </summary>
    public void exitPopUp()
    {
        popUpCanvas.SetActive(false);
        if (potionIsRight)
        {
            rewardScript.getReward();
            if (npcCounter > 4) // FOR DEMO VERSION
            {
                customerServed = true;
            }
        }
        potionIsRight = false;
        counterText.text = "0";
    }
}
