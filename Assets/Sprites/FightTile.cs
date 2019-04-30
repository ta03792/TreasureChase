using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fightile : MonoBehaviour
{
    private bool occupied;  // Use this for initialization  
    void Start()
    {

    }
    void Update() // Update is called once per frame 
    {

    }

    public bool Occupied
    {
        get
        {
            return occupied;
        }
        set
        {
            occupied = value;
        }
    }
}       