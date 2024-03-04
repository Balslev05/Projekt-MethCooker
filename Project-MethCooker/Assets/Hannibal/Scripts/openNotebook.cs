using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class openNotebook : MonoBehaviour
{
    public bool NotebookHit = false;
    public bool NotebookOpen = false;
    public GameObject Notebook;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && NotebookOpen == false && NotebookHit == true)
        {
            NotebookOpen = true;
            Notebook.gameObject.SetActive(true);
        }
        else if(Input.GetKeyDown(KeyCode.E) && NotebookOpen == true)
        {
            Notebook.gameObject.SetActive(false);
            NotebookOpen = false;
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("collide" + gameObject.name);
        if (other.gameObject.CompareTag("Notebook"))
        {
            NotebookHit = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Notebook"))
        {
            NotebookHit = false;
        }
    }
}
