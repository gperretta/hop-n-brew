using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBook : MonoBehaviour
{

    public GameObject popUpBook;
    /// <summary>
    /// Click Action for book opening
    /// </summary>
    /// <returns></returns>
    public void displayBook()
    {
        Debug.Log("Book opened");
        popUpBook.SetActive(true);
    }

    /// <summary>
    /// Function called by the button: Exit 
    /// </summary>
  public void exitBook()
    {
        Debug.Log("EXIT");
        popUpBook.SetActive(false);
         }
 }

