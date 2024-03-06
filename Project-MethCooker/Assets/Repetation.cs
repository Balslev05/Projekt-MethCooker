using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Repetation : MonoBehaviour
{
    [Header("stats")]
    public float maxTrust = 10;
    public float currentTrust;
    [Header("UI")] 
    public Image fillbar;
    public Slider slider;
    void Start()
    {
        slider.maxValue = maxTrust;
        slider.value = maxTrust;
        currentTrust = maxTrust;
    }

    // Update is called once per frame
    void Update()
    {
        currentTrust = slider.value;
    }
}
