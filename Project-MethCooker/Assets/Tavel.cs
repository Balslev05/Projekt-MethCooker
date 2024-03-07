using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tavel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<SpriteRenderer>().sortingLayerID++;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

        }    
    }
}
