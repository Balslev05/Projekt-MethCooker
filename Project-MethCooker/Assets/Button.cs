using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class Button : MonoBehaviour
{
    // Start is called before the first frame update
    public bool correcanware;
    public Repetation Morten_Trust;
    public GameObject Tavel;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Onclick()
    {
        if (correcanware)
        {
            Tavel.SetActive(false);
        }
         if (!correcanware)
        {
            Morten_Trust.currentTrust -= 3;
            Tavel.SetActive(false);
        }
    }
}
