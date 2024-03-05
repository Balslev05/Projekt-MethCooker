using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Cooker : MonoBehaviour
{
    public List<Ingredients> Ingredientsneeded = new();
    public List<Ingredients> currentingredient = new();
    public float Cookingtimer;
    public bool Cooking;

    public int CookingCondition;
    
    //public Ingredients[] Ingredientsneeded = new Ingredients[10];
    public NoteCreater CurrentNote;

    private Ingredients addIngrediant;
    // Start is called before the first frame update
    void Start()
    {
        UpdateIngrediants();        
    }

    // Update is called once per frame
    void Update()
    {
        Cookingtimer = math.clamp(Cookingtimer ,0, 240);
        if(currentingredient.Count == Ingredientsneeded.Count)
        {
            CheckIfIngredientsIsPresent();
        }
        if (Cooking)
        {
            Cookingtimer -= Time.deltaTime;
        }
    }

    public void UpdateIngrediants()
    {
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
