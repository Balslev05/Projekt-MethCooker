using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class StudentQuestions : MonoBehaviour
{
    public List <DummeSp�rgesm�l> Questions;
    public List<GameObject> Elever;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        while (Questions.Count > 0)
        {
            int Sp�rgsm�l;
            Sp�rgsm�l = Random.Range(0, Questions.Count);
            Elever[0].GetComponent<Students>().ElevensSp�rgesm�l = Questions[Sp�rgsm�l];
            Questions.RemoveAt(Sp�rgsm�l);
            Elever.RemoveAt(0);


        }
    }
}
