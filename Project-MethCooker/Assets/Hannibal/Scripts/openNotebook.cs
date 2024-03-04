using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openNotebook : MonoBehaviour
{
    public GameObject Notebook;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (gameObject.CompareTag("Notebook") && Input.GetKey(KeyCode.E))
        {
            Notebook.gameObject.SetActive(true);
        }
    }
}
