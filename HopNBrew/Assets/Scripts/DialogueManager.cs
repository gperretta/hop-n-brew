using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueCanvas;
    public TextMeshProUGUI orderText;
    // Use the DataModel class, where the dictionaries are defined (ingredients and potions lists)
    private DataModel data;
    private int ingredientsCounter;

    private void Start()
    {
        data = new DataModel();
        ingredientsCounter = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("npc"))
        {
            Debug.Log("Start dialogue.");
            activateDialogueCanvas();
            displayOrder();
        }
    }

    /// <summary>
    /// Spawn the dialogueObject prefab
    /// </summary>
    void activateDialogueCanvas()
    {
        dialogueCanvas.SetActive(true);
    }

    private int checkIngredients()
    {
        foreach (var ingredient in data.ingredients)
        {
            if (GameObject.Find(ingredient.Value) != null)
            {
                ingredientsCounter += 1;
            }
        }
        return ingredientsCounter;
    }

    private string getRandomOrder(Dictionary<string, string> dictionary, int rangeStart, int rangeEnd)
    {
        List<string> valuesList = new List<string>(dictionary.Values);
        int randomIndex = Random.Range(rangeStart, rangeEnd + 1);
        return valuesList[randomIndex];
    }

    private void displayOrder()
    {
        int trimIndex = checkIngredients();
        orderText.text = getRandomOrder(data.orders, 0, trimIndex-1);
    }
}
