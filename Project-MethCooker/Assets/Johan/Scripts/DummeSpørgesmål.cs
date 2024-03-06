using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "spørgsmål", menuName = "DummeF*ckingSpørgeSmål", order = 3)]
public class DummeSpørgesmål : MonoBehaviour
{
    [Header("DumtSpørgemål")]
    [TextArea(10,10)]
    public string Spørgesmål;

    [Header("SvarMuligheder")] public string Svarmuligheder1, Svarmuligheder2, Svarmuligheder3, Svarmuligheder4;
}
