using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;

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
            //Notebook.gameObject.SetActive(true);
            NotebookOpen = true;
            Notebook.transform.DOLocalMove(new Vector3(0f, -100f, 0f), 1).SetEase(Ease.OutExpo);

        }
        else if(Input.GetKeyDown(KeyCode.E) && NotebookOpen == true || NotebookOpen == true && NotebookHit == false)
        {
            //Notebook.gameObject.SetActive(false);
            NotebookOpen = false;
            Notebook.transform.DOLocalMove(new Vector3(0f, -767f, 0f), 1).SetEase(Ease.OutExpo);
            
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
