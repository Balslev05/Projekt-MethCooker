using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "spørgsmål", menuName = "DummeF*ckingSpørgeSmål", order = 3)]
public class DummeSpørgesmål : ScriptableObject
{
    [Header("DumtSpørgemål")]
    [TextArea(10,10)]
    public string Spørgesmål;
    
    [Header("svarMuligheder")] 
    public string[] Svarmuligheder;
}
