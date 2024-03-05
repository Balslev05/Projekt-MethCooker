using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using Random = Unity.Mathematics.Random;

public class Cooker : MonoBehaviour
{
    public GameObject Meth;
    public GameObject LSD;
    public GameObject Ecstasy;
    public List<Ingredients> Ingredientsneeded = new();
    public List<Ingredients> currentingredient = new();
    public float Cookingtimer;
    public bool Cooking;

    public int CookingCondition;
    
    //public Ingredients[] Ingredientsneeded = new Ingredients[10];
    public NoteCreater CurrentNote;
    private NoteCreater noteLastFrame;
    public RecipeController recipe;
    private Ingredients addIngrediant;
    // Start is called before the first frame update
    void Start()
    {
        UpdateIngrediants();        
    }

     
    // Update is called once per frame
    void Update()
    {
        CurrentNote = recipe.currentNote;
        Cookingtimer = math.clamp(Cookingtimer ,0, 90);
        if(currentingredient.Count == Ingredientsneeded.Count)
        {
            CheckIfIngredientsIsPresent();
        }
        if (Cooking)
        {
            Cookingtimer -= Time.deltaTime;
        }

        if (noteLastFrame != CurrentNote)
        {
            UpdateIngrediants();
        }
        noteLastFrame = CurrentNote;
        if (CurrentNote.NameOfDrug == "Ecstasy")
        {
            Debug.Log("Ecstasy spawned");
        }
    }

    public void UpdateIngrediants()
    {
        Ingredientsneeded.Clear();
        for (int i = 0; i < CurrentNote.NamesOfIngrdients.Length; i++)
        {
            
            Ingredientsneeded.Add(CurrentNote.NamesOfIngrdients[i]);   
        }
    }

    public void CheckIfIngredientsIsPresent()
    {
        for (int i = 0; i < CurrentNote.NamesOfIngrdients.Length; i++)
        {
            if (currentingredient[i] = CurrentNote.NamesOfIngrdients[i])
            {
                CookingCondition++;
            }
        }
        CheckPot();
    }
    public void CheckPot()
    {
        if (CookingCondition == CurrentNote.NamesOfIngrdients.Length)
        {
            Startcooking();
        }
        else
        {
            //BOOOPOOOOOPPOM!!!!!
        }
    }
    public void Startcooking()
    {
       Cooking = true;
    }
}
