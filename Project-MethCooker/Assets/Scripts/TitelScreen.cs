using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;
using TMPro;
using UnityEngine.UI;

public class TitelScreen : MonoBehaviour
{
    public Image startText; 
    public Image exitText;
    public GameObject bagroundDetails;

    public Vector3 endvalue;

    void Start()
    {
        StartCoroutine(StartTittel());
    }

    public IEnumerator StartTittel()
    {
        bagroundDetails.transform.DOLocalMove( endvalue,2).SetEase(Ease.OutQuart);
        yield return new WaitForSeconds(3);
        print("changecolor");
        startText.DOFade(1, 1).SetEase(Ease.OutExpo);
        exitText.DOFade(1, 1).SetEase(Ease.OutExpo);
    }
}
