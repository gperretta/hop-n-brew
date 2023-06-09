using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RewardSystemHandler : MonoBehaviour
{
    public GameObject[] ingredients; // array of gameObjects
    List<GameObject> newIngredientsList = new List<GameObject>(); // array to list to be manipulated
    public GameObject rewardCanvas;
    public TextMeshProUGUI rewardName;
    public GameObject rewardImage;
    private GameObject pot; // use the Pot gameObject 
    private CraftingAction craftingScript; // to get the script component

    // Start is called before the first frame update
    void Start()
    {
        foreach (var ingredient in ingredients)
        {
            if (GameObject.Find(ingredient.name) == null)
            {
                newIngredientsList.Add(ingredient);
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
        if (newIngredientsList.Count != 0)
        {
            GameObject newIngredient = newIngredientsList[0];
            newIngredient.SetActive(true);
            displayReward(newIngredient);
            newIngredientsList.RemoveAt(0);
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

    public void exitButton()
    {
        rewardCanvas.SetActive(false);
        craftingScript.customerServed = true;
    }
}
