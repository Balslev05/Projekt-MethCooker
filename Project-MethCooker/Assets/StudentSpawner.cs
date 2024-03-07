using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudentSpawner : MonoBehaviour
{
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
            GameObject studentIns =  Instantiate(student,transform.position,Quaternion.identity);
            studentIns.GetComponent<Students>().setSetting(tavel,morten);
            Spawned = true;
            Invoke(nameof(reset),30);
        }
    }

    public void spawnStudent()
    {
         r = Random.Range (40, 100);
    }

    public void reset()
    {
        Spawned = false;
    }
}
