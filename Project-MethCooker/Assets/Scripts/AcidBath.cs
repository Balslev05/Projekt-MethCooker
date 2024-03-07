using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class AcidBath : MonoBehaviour
{
    public float maximum;
    public float Timer;
    public float current;
    public Image Acid;
    public bool _dissolving = false;
    public GameObject particalsEffect;

    // Start is called before the first frame update
    void Start()
    {
        Acid.GetComponent<Slider>().maxValue = Timer;
        current = Timer;
    }
    void Update()
    {
        if (_dissolving)
        {
            current -= Time.deltaTime;
        }

        if (current <= 0)
        {
            particalsEffect.SetActive(false);
            _dissolving = false;
            current = 60;
        }
        Acid.GetComponent<Slider>().value = current;
    }


    public void Dissolving()
    {
        particalsEffect.SetActive(true);
        _dissolving = true;
        current = 60;
    }
}

