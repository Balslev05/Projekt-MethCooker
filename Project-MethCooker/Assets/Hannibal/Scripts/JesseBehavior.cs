using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class JesseBehavior : MonoBehaviour
{
    bool hit = false;
    private bool dialogeOpen = false;
    public GameObject dialoge;
    public GameObject sellButton;
    public GameObject newRecipeButton;
    public NoteCreater[] randomRecipe;
    public RecipeController newRecipe;
    public PickUp sellDrugs;
    public int cash = 0;
    
    [SerializeField] public TextMeshProUGUI dialogeText;
    [SerializeField] public TextMeshProUGUI cashText;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (hit == true && Input.GetKeyDown(KeyCode.E)&& dialogeOpen == false)
        {
            dialogeOpen = true;
            dialoge.gameObject.SetActive(true);
            dialogeText.text="Jesse Cyanman: Yo Mr. Mørk";
            newRecipeButton.gameObject.SetActive(true);
            sellButton.gameObject.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.E) && dialogeOpen || dialogeOpen == true && hit == false)
        {
            dialoge.gameObject.SetActive(false);
            dialogeOpen = false;
        }

        cashText.text = "Cash: " + cash;
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Jesse"))
        {
            hit = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Jesse"))
        {
            hit = false;
        }
    }

    public void sellButtonPress()
    {
        newRecipeButton.gameObject.SetActive(false);
        sellButton.gameObject.SetActive(false);
        if (sellDrugs.methOnBody > 0)
        {
            dialogeText.text = "Jesse Cyanman: Thank's Mr. Mørk";
            cash += sellDrugs.methOnBody * 150;
            sellDrugs.methOnBody = 0;

        }
        else if (sellDrugs.LSDOnBody > 0)
        {
            dialogeText.text = "Jesse Cyanman: Thank's Mr. Mørk";
            cash += sellDrugs.LSDOnBody * 200;
            sellDrugs.LSDOnBody = 0;
        }
        else if (sellDrugs.EcstasyOnBody > 0)
        {
            dialogeText.text = "Jesse Cyanman: Thank's Mr. Mørk";
            cash += sellDrugs.EcstasyOnBody * 100;
            sellDrugs.EcstasyOnBody = 0;
        }
        else
        {
            dialogeText.text = "Sorry Mr. Mørk, you don't have any drugs";
        }
    }

    public void NewRecipePress()
    {
        newRecipeButton.gameObject.SetActive(false);
        sellButton.gameObject.SetActive(false);
        dialogeText.text = "Here you go Mr. Mørk";
        int randomNumber = Random.Range(0, randomRecipe.Length);
        newRecipe.currentNote = randomRecipe[randomNumber];
    }
}
