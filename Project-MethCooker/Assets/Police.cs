using System;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class Police : MonoBehaviour
{
    public PlayerMovement Morten;
    public float policetimer;
    public float CarSpeed;

    
    [Header("Timers")]
    public float timer;
    public float min_T,max_T;
    public float ScoutingTimer;
    
    [SerializeField]private float caughtTimer;
    
    [Header("Points")]
    public Transform PointA;
    public Transform PointB;

    [SerializeField] private Vector3 StartPos;
    
    private bool _scouting;
    private bool _running = false;
    // Start is called before the first frame update
    private void Awake()
    {
        StartPos = gameObject.transform.position;
    }

    void Start()
    {
        policetimer = Random.Range(0, 100);
        Invoke(nameof(PolicePatroel),policetimer);
        transform.position = StartPos;
        timer = Random.Range(min_T,max_T);
        if (!_running)
        {
            StartCoroutine(PolicePatroel());
        }
    }

    private void Update()
    {
        Scouting();
    }

    // Update is called once per frame
    IEnumerator PolicePatroel()
    {
        _running = true;
        yield return new WaitForSeconds(timer + CarSpeed);
        gameObject.transform.DOLocalMove(PointA.transform.position, CarSpeed).SetEase(Ease.OutExpo);
        _scouting = true;
        
        yield return new WaitForSeconds(ScoutingTimer + CarSpeed);
        
        gameObject.transform.DOLocalMove(PointB.transform.position, CarSpeed).SetEase(Ease.OutExpo);
        
        yield return new WaitForSeconds(1 + CarSpeed);
        
        _scouting = false;
        caughtTimer = 0;
        _running = false;
        Start();
    }


    public void Scouting()
    {
        if (Morten.jumping == false && _scouting)
        {
            caughtTimer += Time.deltaTime;
        }
        else
        {
            return;
        }

        if (caughtTimer >= 2)
        {
            print("2");
        }
        
        

    }
    
}