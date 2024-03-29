using System;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;
using TMPro;
public class Police : MonoBehaviour
{
    [Header("Assignebel")] 
    public AudioSource sirens;
    public PlayerMovement Morten;
    public Repetation Morten_trust;
    public TMP_Text warningMessege_UI;
    
    [Header("Stats")]
    public float policetimer;
    public float carSpeed;
    public float punishment;
    public string warningMessege;
    
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
    
    private float sirensMaxSound = 1;
    private bool _scouting;
    private bool _running = false;
    // Start is called before the first frame update
    private void Awake()
    {
       
        StartPos = gameObject.transform.position;
        sirens.volume = 0;
    }

    void Start()
    {
        warningMessege_UI.text = " "; 
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
        //inden den kommer
        caughtTimer = 0;
        _running = true;
        caught = false;
        // sound 
        yield return new WaitForSeconds(timer + carSpeed);
        
        warningMessege_UI.text = warningMessege;
        //kommer frem og holder
        DOTween.To(() => sirens.volume, x => sirens.volume = x, sirensMaxSound, carSpeed).SetEase(Ease.OutExpo);
        gameObject.transform.DOLocalMove(PointA.transform.position, carSpeed).SetEase(Ease.OutExpo);
        _scouting = true;
        yield return new WaitForSeconds(ScoutingTimer + carSpeed);
        
        // kør væk
        caughtTimer = 0;
        _scouting = false;
        warningMessege_UI.text = "";
        gameObject.transform.DOLocalMove(PointB.transform.position, carSpeed).SetEase(Ease.OutExpo);
        DOTween.To(() => sirens.volume, x => sirens.volume = x, 0, carSpeed).SetEase(Ease.OutExpo);
        yield return new WaitForSeconds(1 + carSpeed);
        
        //efter den er kørt
         caughtTimer = 0;
        _running = false;
        Start();
    }


    public void Scouting()
    {
        if (Morten.jumping == false && _scouting && !Morten.cutscene && !Morten.isTeaching)
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