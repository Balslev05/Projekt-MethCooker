using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
[ExecuteInEditMode()]
public class Progressbar : MonoBehaviour
{
    public float maximum;
    public float current;
    public Cooker cooker;
    public Image Bar;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        currentfillamount();
    }
    void currentfillamount() 
    {
        //float fillamount = (float)current / (float)maximum;
        if (cooker.Cooking)
            {DOTween.To(() => current, x => current = x, maximum, cooker.Cookingtimer).SetEase(Ease.Linear);}

        Bar.GetComponent<Slider>().value = current;
    }

}
