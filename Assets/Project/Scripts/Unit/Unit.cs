using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : GameManager
{
    [Header("Movement")]
        [SerializeField] protected float movementSpeed;

    protected override void LoadComponents()
    {
        loadValues();
    }

    private void loadValues()
    {
        movementSpeed = 3;
    }
}
