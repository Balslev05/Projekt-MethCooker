using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class transision : MonoBehaviour
{
    public Vector3 StartPos;
    public Vector3 EndPos;
    public bool OnAwake;
    public int timer;
    public int Screentimer;
    void Start()
    {
        gameObject.transform.localScale = StartPos;
        if (OnAwake)
        {
            gameObject.transform.DOScale(EndPos,timer).SetEase(Ease.OutExpo);
            Invoke(nameof(SwitcScene),Screentimer);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonPress()
    {
        gameObject.transform.localScale = StartPos;
        gameObject.transform.DOScale(EndPos,timer).SetEase(Ease.OutExpo);
        Invoke(nameof(SwitcScene),Screentimer);
    }

    public void SwitcScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
    
}
