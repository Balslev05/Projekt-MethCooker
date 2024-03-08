using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;

public class Zone : MonoBehaviour
{
    public PlayerMovement morten;
    public TMP_Text WarningMessege;
    public string messege;
    public bool kildeZone;
    public float punishment;
    public Repetation Trust;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (kildeZone && !morten.Kidle && !morten.cutscene)
            {
                Trust.currentTrust -= punishment;
                WarningMessege.text = messege;
            }
            if (!kildeZone && morten.Kidle && !morten.cutscene)
            {
                Trust.currentTrust -= Time.deltaTime;
                WarningMessege.text = messege;
            }
        }
    }
}