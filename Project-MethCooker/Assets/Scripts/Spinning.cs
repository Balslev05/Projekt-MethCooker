using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Spinning : MonoBehaviour
{
    public float timer;
    // Start is called before the first frame update
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.DOLocalRotate(new Vector3(0, 0, 360), timer, RotateMode.FastBeyond360).SetRelative(true).SetEase(Ease.Linear); 
    }
}
