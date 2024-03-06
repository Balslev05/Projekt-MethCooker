using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    public Progressbar progress;
    public int CookingCondition;
    public GameObject spawnPoint;
    //public Ingredients[] Ingredientsneeded = new Ingredients[10];
    public NoteCreater CurrentNote;
    private NoteCreater noteLastFrame;
    public RecipeController recipe;
    private Ingredients addIngrediant;
    // Start is called before the first frame update
    void Start()
    {
        UpdateIngrediants();
        Cookingtimer = CurrentNote.cookingTimer;
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
            Cookingtimer = CurrentNote.cookingTimer;
        }
        noteLastFrame = CurrentNote;
        if (CurrentNote.NameOfDrug == "Ecstasy" && Cookingtimer <= 0 && Cooking)
        {
            Debug.Log("Ecstasy spawned");
            Instantiate(Ecstasy,spawnPoint.transform.position,Quaternion.identity);
            Invoke(nameof(reset), 0.2f);
        }
        else if (CurrentNote.NameOfDrug == "Meth" && Cookingtimer <= 0 && Cooking)
        {
            Debug.Log("Meth spawned");
            Instantiate(Meth,spawnPoint.transform.position,Quaternion.identity);
            Invoke(nameof(reset),0.2f);
        }
        else if (CurrentNote.NameOfDrug == "LSD" && Cookingtimer <= 0 && Cooking)
        {
            Debug.Log("LSD spawned");
            Instantiate(LSD,spawnPoint.transform.position,Quaternion.identity);
            Invoke(nameof(reset),0.2f);
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

    private void reset()
    {
        Cookingtimer = CurrentNote.cookingTimer;
        Cooking = false;
        currentingredient.Clear();
        
        progress.current = 0;
        Debug.Log("progress = 0");
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
