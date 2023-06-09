using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardSystemHandler : MonoBehaviour
{
    public GameObject[] ingredients; // array of gameObjects
    List<GameObject> newIngredientsList = new List<GameObject>();

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
    }

    public void getReward()
    {
        if (newIngredientsList.Count != 0)
        {
            newIngredientsList[0].SetActive(true);
            Debug.Log("Activate: " + newIngredientsList[0].name);
            newIngredientsList.RemoveAt(0);
        }
    }
}
