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
    [Header("Assignebel")]
    public PlayerMovement Morten;
    public Repetation Morten_trust;
    [Header("Stats")]
    public float policetimer;
    public float carSpeed;
    public float punishment;
    
    [Header("Timers")]
    public float timer;
    public float min_T,max_T;
    public float ScoutingTimer;
    
    
    [Header("Points")]
    public Transform PointA;
    public Transform PointB;

    [SerializeField] private Vector3 StartPos;
    [SerializeField] private float caughtTimer;
    [SerializeField] private bool caught;
    
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
        caught = false;
        
        yield return new WaitForSeconds(timer + carSpeed);
        gameObject.transform.DOLocalMove(PointA.transform.position, carSpeed).SetEase(Ease.OutExpo);
        _scouting = true;
        
        yield return new WaitForSeconds(ScoutingTimer + carSpeed);
        
        gameObject.transform.DOLocalMove(PointB.transform.position, carSpeed).SetEase(Ease.OutExpo);
        
        yield return new WaitForSeconds(1 + carSpeed);
        
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

        if (caughtTimer >= 2 && !caught)
        {
            DOTween.To(() => Morten_trust.currentTrust, x => Morten_trust.currentTrust = x, Morten_trust.currentTrust -= punishment,1);
            caught = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Morten_trust.currentTrust = 0;
        }
    }
}