using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Police : MonoBehaviour
{
    public string levelname;
    public PlayerMovement Morten;
    public float policetimer;

    // Start is called before the first frame update
    void Start()
    {
        policetimer = Random.Range(0, 100);
        Invoke(nameof(PolicePatroel),policetimer);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void PolicePatroel()
    {
        if (Morten.jumping == false)
        {
            SceneManager.LoadScene(levelname);
        }
        else
        {
            return;
        }

    }
}
