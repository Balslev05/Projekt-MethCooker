using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Itemspawner : MonoBehaviour
{
    public Ingredients Drugs;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = Drugs.sprite;
        gameObject.name = Drugs.name;
    }  
}
