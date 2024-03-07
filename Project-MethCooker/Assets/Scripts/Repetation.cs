using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class Repetation : MonoBehaviour
{
    [Header("stats")]
    public float maxTrust = 10;
    public float currentTrust;
    [Header("UI")] 
    public Image fillbar;
    public Slider slider;
    public float oldTrust;
    public Image reputationDown;
    [SerializeField] private TextMeshProUGUI Failed;
    public PlayerMovement move;
    void Start()
    {
        move.enabled = true;
        slider.maxValue = maxTrust;
        slider.value = maxTrust;
        currentTrust = maxTrust;
        oldTrust = currentTrust;
    }

    // Update is called once per frame
    void Update()
    {
        
        slider.value = currentTrust;
        if (currentTrust < oldTrust)
        {
            Debug.Log("Shaking");
            CinemachineShake.Instance.ShakeCamera(0.22f, 0.2f);
            oldTrust = currentTrust;
            reputationDown.DOFade(0.5f, 0.1f).SetEase(Ease.OutCirc).SetLoops(2, LoopType.Yoyo);
        }

        if (currentTrust <= 0)
        {
            reputationDown.DOFade(0.5f, 0.1f).SetEase(Ease.OutCirc);
            Failed.text = "You have failed in the art of cooking and teaching";
            Failed.gameObject.SetActive(true);
            move.enabled = false;

        }
    }
}
