using DG.Tweening;
using System;
using System.Collections;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class Students : MonoBehaviour
{
    [Header("Assignebels")] 
    public DummeSpørgesmål ElevensSpørgesmål;
    public GameObject udråbstegn;
    public Transform targetpostion;
    [Header("TavelDialog")] 
    public GameObject tavel;
    public TMP_Text spørgesmålTitel;
    public TMP_Text[] SvarUI;
    
   
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
        
        if( Vector2.Distance(transform.position,targetpostion.transform.position) < 1.5f)
        {
            handisraised = true;
            udråbstegn.SetActive(true);
        }
    }

    public void Spøgsmål()
    {
        tavel.SetActive(true);
        spørgesmålTitel.text = ElevensSpørgesmål.Spørgesmål;
        
        for (int i = 0; i < ElevensSpørgesmål.Svarmuligheder.Length; i++)
        {
            print(i);
            if (ElevensSpørgesmål.Rigtignummer == i)
            {
                SvarUI[i].text= ElevensSpørgesmål.Svarmuligheder[i];
                SvarUI[i].gameObject.GetComponent<Button>().correcanware = true;
            }
            else
            {                
                SvarUI[i].gameObject.GetComponent<Button>().correcanware = false;
                SvarUI[i].text= ElevensSpørgesmål.Svarmuligheder[i];
            }
        }


    }



}
