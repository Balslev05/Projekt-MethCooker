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
    [Header("TavelDialog")] 
    public GameObject tavel;
    public GameObject spørgesmålTitel;
    public GameObject[] SvarUI;
    private Repetation trust;
    
   
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
    }

    // Update is called once per frame
    void Update()
    {
        spørgesmålTitel = GameObject.FindWithTag("Titel");
        SvarUI = GameObject.FindGameObjectsWithTag("Svar");
        Studentlifetime += Time.deltaTime;

        if (Studentlifetime > 30)
        {
            trust.currentTrust -= 1;
            Destroy(gameObject);
        }
        if (Studentlifetime > Studentsraisehands)
        {
            Vector3 walkdirection =   tavel.transform.position - transform.position;
            walkdirection = walkdirection.normalized;
            transform.position += walkdirection * Time.deltaTime;
        }
        
        if( Vector2.Distance(transform.position,tavel.transform.position) < 1.5f)
        {
            handisraised = true;    
            udråbstegn.SetActive(true);
        }
    }

    public void Spøgsmål()
    {
        tavel.transform.localScale = new Vector3(1,1,1);
        
        spørgesmålTitel.GetComponent<TMP_Text>().text = ElevensSpørgesmål.Spørgesmål;
        for (int i = 0; i < ElevensSpørgesmål.Svarmuligheder.Length; i++)
        {
            if (ElevensSpørgesmål.Rigtignummer == i)
            {
                SvarUI[i].GetComponent<TMP_Text>().text= ElevensSpørgesmål.Svarmuligheder[i];
                SvarUI[i].gameObject.GetComponent<Button>().correcanware = true;
            }
            else
            {                
                SvarUI[i].gameObject.GetComponent<Button>().correcanware = false;
                SvarUI[i].GetComponent<TMP_Text>().text= ElevensSpørgesmål.Svarmuligheder[i];
            }
        }
    }


    public void setSetting(Transform Target, Repetation morten)
    {
        print("woaw");
        tavel = Target.gameObject;
        trust = morten;
    }



}
