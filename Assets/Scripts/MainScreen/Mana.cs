using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mana : MonoBehaviour
{

    private int mana = 10;
    public Text manaText;
    public int ManaProperties { get => mana; set => mana = value; }


    void Update()
    {
        manaText.text = mana.ToString();
    }

}