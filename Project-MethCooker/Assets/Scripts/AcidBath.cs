using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AcidBath : MonoBehaviour
{
    public float maximum;
    public float Timer;
    public float current;
    public Image Acid;
    public bool endAcid = false;

    // Start is called before the first frame update
    void Start()
    {
        Acid.GetComponent<Slider>().maxValue = Timer;
        current = Timer;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (endAcid == true)
        {
        Debug.Log(current);
        currentfillamount();
        }

        if (current <= 0)
        {
            endAcid = false;
            current = 60;
            Acid.GetComponent<Slider>().value = current;
        }
        
        /*if (current < 1)
        {
        }*/

    }
    void currentfillamount()
    {
        //float fillamount = (float)current / (float)maximum;

       current -= Time.deltaTime;

        Acid.GetComponent<Slider>().value = current;
        
    }
    

}

