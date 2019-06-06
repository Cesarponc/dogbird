using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colums : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            GameController.instance.DogScored();
        }
    }
   
}
