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
        {'A', "Shiny Goldenmud" },
        {'B', "Malokio’s Twin Eyes" },
        {'C', "Fresh Firefruit" },
        {'D', "Inronmantis Wing" },
        {'E', "Spiteful Dusk Imp" },
        {'F', "Elfior’s Glade Mushroom" },
        {'G', "Purple Rain Pear" },
        {'H', "Mount Shim Minestone" },
        {'I', "Keman’s Bonsai" }
    };
    // Key type: string, Value type: string
    public Dictionary<string, string> potions = new Dictionary<string, string>()
    {
        {"AAC", "Bubbling Vocaloud"},
        {"ABC", "Luxuriant Gardena"},
        {"BBA", "Sheep Counter's Wisdom"},
        {"CBC", "Crimson Jaw Juice"},
        {"CBA", "Atlas Big Toe"},
        {"BAC", "Smooth Ribbinal"},
        {"CCA", "Horseshoe’s Wish"},
        {"ACD", "Minister's Voice"},
        {"DAA", "Wowgue Parade"},
        {"BCD", "Sweety Deeds Done Sweet"},
        {"BAD", "Forgetful’s Pray"},
        {"CBD", "Monster in Love"}
    };
    // Key type: string, Value type: string
    public Dictionary<string, string> orders = new Dictionary<string, string>()
    {
        {"AAC", "Hi potions master, I need a potion that will make all the little fish in my tank sing. I want them to become a band and play concerts"},
        {"ABC", "I need a potion that will turn my annoying neighbor's weeds into houseplants. Please help me fix that garden!"},
        {"BBA", "Hi, I'm in desperate need of a potion that makes me learn things while I sleep.\nI would study during the day, but there is too much confusion in my house"},
        {"CBC", "Hello, Potions Master! I've been trying to impress my crush, but my attempts keep failing. Can you make a potion that will make me look like the coolest toad she's ever seen in her eyes?"},
        {"CBA", "Greetings, Magic Merchant. I'm tired of being the shortest person in my photos with relatives. Is it possible to get a potion that makes me tall as a tree? I want to blow Uncle Walt speechless at the next family barbecue." },
        {"BAC", "Hey, I have to attend a wedding, and there's one problem that comes up every time at these events: The line dances!\nPlease make me a potion that makes me dance like Toady Croakson!"},
        {"CCA", "Greetings, Potions Master!\nLately a Janara mosquito bit me and since that day I have been cursed with terrible luck. Can you make me a potion that can make me lucky again?"},
        {"ACD", "Dear potion maker, I have a big presentation at work tomorrow, and I'm a little nervous. I could use a confidence boost.\nCan you brew a potion that turns me into a charismatic speaker?"},
        {"DAA", "Hello Magic Expert! I have a huge problem: I don't know how to dress fashionably! and I'm a designer!\nThere are times I wish I could leave the house without clothes.\nCould you create a potion that instantly makes any outfit I wear elegant and stylish?"},
        {"BCD", "Greetings, potion shop wizard! I really love sweets but I hate the calories they give when you eat them.\nCan you make me a potion that allows me to eat whatever I want, without consequences?"},
        {"BAD", "Hello, magical being at the Potion Store! I have a dilemma: I can never remember where I left my stuff. Can you concoct a potion that will make the things i lost magically float in front of me whenever I need them?"},
        {"CBD", "Dear potion shop owner, my mother-in-law doesn't think well of me. I do everything to please her, but in her opinion I'm never enough for her daughter.\nCan you create a potion that makes them believe in\nthat I'm the most extraordinary son-in-law on the planet?"}
    };
}

