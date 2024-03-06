using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveClone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        if (gameObject.name.Contains("(Clone)"))
        {
            gameObject.name = gameObject.name.Remove(gameObject.name.Length - 7);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
