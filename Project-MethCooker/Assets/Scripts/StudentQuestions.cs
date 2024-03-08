using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudentQuestions : MonoBehaviour
{
    public List <DummeSpørgesmål> Questions;
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
            int spørgesmål;
            spørgesmål = Random.Range(0, Questions.Count);
            Elever[0].GetComponent<Students>().ElevensSpørgesmål = Questions[spørgesmål];
            Questions.RemoveAt(spørgesmål);
            Elever.RemoveAt(0);


        }
    }
}
