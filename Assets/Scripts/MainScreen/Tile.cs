using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    // Start is called before the first frame update
    private bool occupied;

    public bool Occupied { get => occupied; set => occupied = value; }
}
