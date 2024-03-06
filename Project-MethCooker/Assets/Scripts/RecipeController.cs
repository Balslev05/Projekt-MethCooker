using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class RecipeController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Drug;
    [SerializeField] TextMeshProUGUI[] indgridients;

    public NoteCreater currentNote;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Drug.text = currentNote.NameOfDrug;
        for (int i = 0; i < indgridients.Length; i++)
        {
            indgridients[i].text = "";
        }
        
        for (int i = 0; i < currentNote.NamesOfIngrdients.Length; i++)
        {
            indgridients[i].text = currentNote.NamesOfIngrdients[i].name;
        }
    }
}
