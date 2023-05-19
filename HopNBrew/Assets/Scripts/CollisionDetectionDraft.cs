using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetectionDraft : MonoBehaviour
{
     void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("pot"))
        {
         Debug.Log("Collision detected");
        }
    }
}
