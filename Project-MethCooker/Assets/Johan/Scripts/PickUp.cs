using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private bool MethHit = false;
    private bool LSDHit = false;
    private bool EcstasyHit = false;
    public int methOnBody;
    public int LSDOnBody;
    public int EcstasyOnBody;
    public Ingredients carryitem;
    private bool hit = false;
    [SerializeField] private TextMeshProUGUI ColideWith;
    public GameObject colide;
    [SerializeField] private TextMeshProUGUI CurrentlyHolding;
    public Cooker cooker;

    public GameObject carryingObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (carryitem != null)
        {
            CurrentlyHolding.text = "Currently Holding " + carryitem.name;
        }
        else
        {
            CurrentlyHolding.text = "Currently Holding ";
            
        }
        if (Input.GetKeyDown(KeyCode.E) && MethHit == true)
        {
            Destroy(carryingObject);
            methOnBody++;
        }
        if (Input.GetKeyDown(KeyCode.E) && LSDHit == true)
        {
            Destroy(carryingObject);
            LSDOnBody++;
        }
        if (Input.GetKeyDown(KeyCode.E) && EcstasyHit == true)
        {
            Destroy(carryingObject);
            EcstasyOnBody++;
        }

        if (hit == true)
        {
            ColideWith.gameObject.SetActive(true);
            ColideWith.text = colide.name;
        }
        else
        {
            ColideWith.gameObject.SetActive(false);
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
            Cooker cookerCollied = other.GetComponent<Cooker>();
            if (cookerCollied.currentingredient.Contains(carryitem) == false && carryitem != null)
            {
                cookerCollied.currentingredient.Add(carryitem);
                carryitem = null;
            }
        }

        if (other.gameObject.CompareTag("Cooker") && Input.GetKeyDown(KeyCode.E))
        {
            cooker.currentingredient.Clear();
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other)
        {
            hit = true;
            colide = other.gameObject;
        }
        if (other.gameObject.CompareTag("Meth"))
        {
            carryingObject = other.gameObject;
            MethHit = true;
        }
        if (other.gameObject.CompareTag("LSD"))
        {
            carryingObject = other.gameObject;
            LSDHit = true;
        }
        if (other.gameObject.CompareTag("Ecstasy"))
        {
            carryingObject = other.gameObject;
            EcstasyHit = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other)
        {
            hit = false;
        }
        if (other.gameObject.CompareTag("Meth"))
        {
            MethHit = false;
        }
        if (other.gameObject.CompareTag("LSD"))
        {
            LSDHit = false;
        }
        if (other.gameObject.CompareTag("Ecstasy"))
        {
            EcstasyHit = false;
        }
    }
}
