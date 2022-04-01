using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//INHERITANCE
public class Rifle : Weapon
{
    // Start is called before the first frame update
    void Start()
    {
        base.FireDelay = 0.15f;
    }

}
