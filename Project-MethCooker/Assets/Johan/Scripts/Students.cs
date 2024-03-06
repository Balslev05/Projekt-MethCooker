    using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Students : MonoBehaviour
{
    [Header("Assignebels")]
    public GameObject udråbstegn;
    public Transform targetpostion;
   
    [Header("stats")]
    public float Studentsraisehands;
    public float Studentlifetime;
    public bool handisraised;

    // Start is called before the first frame update

    private void Awake()
    {
        udråbstegn.SetActive(false);
    }

    void Start()
    {
        Studentsraisehands = UnityEngine. Random.Range (0, 100);
    }

    // Update is called once per frame
    void Update()
    {
     Studentlifetime += Time.deltaTime;
        if (Studentlifetime > Studentsraisehands && !handisraised)
        {
            Vector3 walkdirection =   targetpostion.position - transform.position;
            walkdirection = walkdirection.normalized;
            transform.position += walkdirection * Time.deltaTime;
        }
        if( Vector2.Distance(transform.position,targetpostion.transform.position) < 0.5f)
        {
            handisraised = true;
            udråbstegn.SetActive(true);
        }

       
    }
}
