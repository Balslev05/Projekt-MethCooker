using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Ingredientshandler : MonoBehaviour
{
    public List<Ingredients> PossibleIngredients;
    public List<GameObject> Items;
    
    // Start is called before the first frame update
    void Start()
    {
        Items = GameObject.FindGameObjectsWithTag("Items").ToList();
        reshuffle(Items);
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    void reshuffle(List<GameObject> Ingredians)
    {
        // Knuth shuffle algorithm :: courtesy of Wikipedia :)
        
        while (PossibleIngredients.Count > 0)
        {
            int Tal;
            Tal = Random.Range(0, PossibleIngredients.Count);
            Items[0].GetComponent<Itemspawner>().Drugs = PossibleIngredients[Tal];
            PossibleIngredients.RemoveAt(Tal);
            Items.RemoveAt(0);
            
            
        } 


        
    }
}
