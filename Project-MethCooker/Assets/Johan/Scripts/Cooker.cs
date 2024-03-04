using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Cooker : MonoBehaviour
{
    public Ingredients[] Ingredientsneeded = new Ingredients[10];
    public NoteCreater CurrentNote;

    private Ingredients addIngrediant;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateIngrediants();
    }

    public void UpdateIngrediants()
    {
        
        for (int i = 0; i < CurrentNote.NamesOfIngrdients.Length; i++)
        {
            Ingredientsneeded[i] = CurrentNote.NamesOfIngrdients[i];
            addIngrediant = Ingredientsneeded[i];
        }
    }
}
