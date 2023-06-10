using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// - Attached to RewardSystem gameObject
/// - To handle the reward system as in getting a new ingredient
/// and showing a pop-up to "notify" the reward to the player
/// </summary>
public class RewardSystemHandler : MonoBehaviour
{
    public GameObject[] ingredients; // array of gameObjects
    List<GameObject> hiddenIngredients = new List<GameObject>(); // array to list to be manipulated
    public GameObject rewardCanvas;
    public TextMeshProUGUI rewardName;
    public GameObject rewardImage;
    private GameObject pot; // use the Pot gameObject 
    private CraftingAction craftingScript; // to get the script component

    void Start()
    {
        foreach (var ingredient in ingredients)
        {
            if (GameObject.Find(ingredient.name) == null) // not active 
            {
                hiddenIngredients.Add(ingredient);
            }
        }
        // If the gameObject is on scene, get its script
        pot = GameObject.Find("Pot");
        if (pot != null)
        {
            craftingScript = pot.GetComponent<CraftingAction>();
        }
    }

    /// <summary>
    /// Get the first gameObject from the list and set it active
    /// then remove it from the list for next iteration
    /// </summary>
    public void getReward()
    {
        if (hiddenIngredients.Count != 0)
        {
            GameObject newIngredient = hiddenIngredients[0];
            newIngredient.SetActive(true);
            displayReward(newIngredient);
            hiddenIngredients.RemoveAt(0); // Remove from the list of ingredients to be activated
        }
    }

    /// <summary>
    /// Display a canvas with: a background panel, a TextMesh, an image panel and a button
    /// </summary>
    /// <param name="newObject">gameObject picked as a reward</param>
    private void displayReward(GameObject newObject)
    {
        rewardName.text = newObject.name;
        rewardImage.GetComponent<Image>().sprite = newObject.GetComponent<SpriteRenderer>().sprite;
        rewardCanvas.SetActive(true);
    }

    /// <summary>
    /// Deactivate canvas and set customerServed to true to make the npc move away 
    /// </summary>
    public void exitButton()
    {
        rewardCanvas.SetActive(false);
        craftingScript.customerServed = true; 
    }
}
