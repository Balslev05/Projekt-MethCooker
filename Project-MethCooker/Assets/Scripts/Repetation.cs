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
    public bool hasShaken = false;
    void Start()
    {
        slider.maxValue = maxTrust;
        slider.value = maxTrust;
        currentTrust = maxTrust;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = currentTrust;
        if (currentTrust <= 0f && hasShaken == false)
        {
            Debug.Log("Shaking");
            CinemachineShake.Instance.ShakeCamera(1f, 1f);
            hasShaken = true;
        }
    }
}
