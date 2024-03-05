using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private bool hit = false;
    public int methOnBody;
    public Ingredients carryitem;

    public GameObject carryingObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && hit == true)
        {
            Destroy(carryingObject);
            methOnBody++;
        }

    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Drug"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                carryitem = other.GetComponent<Item>().Ingredients;
            }
        }
        else if (other.gameObject.CompareTag("Cooker"))
        {
            if (!Input.GetKey(KeyCode.E)) 
            {
                Cooker cookerCollied = other.GetComponent<Cooker>();
                if (cookerCollied.currentingredient.Contains(carryitem) == false)
                {
                    cookerCollied.currentingredient.Add(carryitem);
                    carryitem = null;
                }
                
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Meth"))
        {
            carryingObject = other.gameObject;
            hit = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Meth"))
        {
            hit = false;
        }
    }
}
