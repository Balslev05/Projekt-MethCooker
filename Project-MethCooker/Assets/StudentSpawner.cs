using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudentSpawner : MonoBehaviour
{
    
    
    public float tMin;
    public float tMax;
    public float studentsraisehands;
    public GameObject student;
    public float r;
    public Repetation morten;
    public Transform tavel;
    public bool Spawned = false;
    void Start()
    {
        spawnStudent();
    }

    // Update is called once per frame
    void Update()
    {
        studentsraisehands += Time.deltaTime;
        if (studentsraisehands > r && !Spawned)
        {
            Spawned = true;
            GameObject studentIns =  Instantiate(student,transform.position,Quaternion.identity);
            studentIns.GetComponent<Students>().setSetting(tavel,morten);
            Invoke(nameof(reset),30);
        }
    }

    public void spawnStudent()
    {
         r = Random.Range (tMin, tMax);
    }

    public void reset()
    {
        Spawned = false;
    }
}
