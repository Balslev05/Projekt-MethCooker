using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ingredients", menuName = "ingredientsmaker", order = 2)]
public class Ingredients : ScriptableObject
{
    public string name;
    public Sprite sprite;
}
