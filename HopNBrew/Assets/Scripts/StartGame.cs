using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public GameObject tutorialCanvas;
    public bool canStart;
    public GameObject counterObject;

    private void Awake()
    {
        canStart = false;
    }

    public void exitTutorial()
    {
        tutorialCanvas.SetActive(false);
        counterObject.SetActive(true);
        canStart = true;
    }
}
