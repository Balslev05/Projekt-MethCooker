using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Ingredients carryitem;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
             
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Drug"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                carryitem = other.GetComponent<Item>().Ingredients;
            }
        }
    }

}
