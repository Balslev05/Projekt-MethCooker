using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Students : MonoBehaviour
{
    public float Studentsraisehands;
    public float Studentlifetime;
    public bool handisraised;
    public Transform targetpostion;

    // Start is called before the first frame update
    void Start()
    {
        Studentsraisehands = UnityEngine. Random.Range (0, 100);
    }

    // Update is called once per frame
    void Update()
    {
     Studentlifetime += Time.deltaTime;
        if (Studentlifetime > Studentsraisehands)
        {
            Vector3 walkdirection =   targetpostion.position - transform.position;
            walkdirection = walkdirection.normalized;
            transform.position += walkdirection * Time.deltaTime;
        }
       if (transform.position == targetpostion.transform.position)
        {
            handisraised = true;
            Debug.Log("Hej");
            
        }

       
    }
}
