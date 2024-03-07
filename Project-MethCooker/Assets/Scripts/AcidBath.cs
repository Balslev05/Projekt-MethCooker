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

    // Start is called before the first frame update
    void Start()
    {
        Acid.GetComponent<Slider>().maxValue = Timer;
        current = Timer;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(current);
        if (current < 1)
        {
            current = 60;
        }
        currentfillamount();

    }
    void currentfillamount()
    {
        //float fillamount = (float)current / (float)maximum;

       current -= Time.deltaTime;

        Acid.GetComponent<Slider>().value = current;
        
    }
    

}

