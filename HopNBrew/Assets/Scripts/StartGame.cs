using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public GameObject tutorialCanvas;
    public bool canStart;

    private void Awake()
    {
        canStart = false;
    }

    public void exitTutorial()
    {
        tutorialCanvas.SetActive(false);
        canStart = true;
    }
}
