using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthScript : MonoBehaviour
{

    private int currenthealth;
    public int maxhealth;
    public Text healthtext;

    public int Currenthealth { get => currenthealth; set => currenthealth = value; }

    private void Start()
    {
        Currenthealth = maxhealth;
    }

    void Update()
    {
        healthtext.text = currenthealth.ToString();
    }


}