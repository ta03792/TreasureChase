using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthScript : MonoBehaviour
{

    public int health = 10;

    public Text healthText;

    public int HealthProperties
    {
        get => health;
        set
        {
            health = value;

            healthText.text = health.ToString();
        }
    }
}