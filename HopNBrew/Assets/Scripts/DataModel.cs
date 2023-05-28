using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// - To define ingredients and potions dictionaries
/// - Not attached to any game object (not inherited from MonoBehaviour)
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
        {"AD", "sleep potion"},
        {"BC", "love potion"},
        {"CE", "make-me-tall potion"},
        {"EF", "make-me-small potion"}
    };
}

