using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// - Not attached to any game object (not inherited from MonoBehaviour)
/// - To define ingredients and potions dictionaries
/// </summary>
public class DataModel
{
    // Key type: char, Value type: string
    public Dictionary<char, string> ingredients = new Dictionary<char, string>()
    {
        {'A', "wicked apple" },
        {'B', "chicken tail" },
        {'C', "catnip" },
        {'D', "dragon tooth" },
        {'E', "rat ear" },
        {'F', "pond leaf" }
    };
    // Key type: string, Value type: string
    public Dictionary<string, string> potions = new Dictionary<string, string>()
    {
        {"ABD", "sleep potion"},
        {"ABC", "love potion"},
        {"ACD", "make-me-tall potion"},
        {"BCD", "make-me-small potion"},
        {"ADE", "creatività finita" }
    };
    //FIXME: review check criteria to make a feasible potion request
    // Key type: string, Value type: string
    public Dictionary<string, string> orders = new Dictionary<string, string>()
    {
        // A, B, C, D
        {"ABD", "my baby cries a lot, help me make him fall asleep pls"},
        {"ABC", "help me make a beautiful fox fall in love with me"},
        {"ACD", "i want to grab the highest apple on the tree"},
        {"BCD", "i wanna live with ants!!"},
        // Adding E
        {"ADE", "questo non deve uscire" }
    };
}

