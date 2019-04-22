using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    private int health = 10;
    
    public Text healthText;

    public int HealthProperties { get => health; set => health = value; }

    void Update()
    {
        healthText.text = health.ToString();
    }
}