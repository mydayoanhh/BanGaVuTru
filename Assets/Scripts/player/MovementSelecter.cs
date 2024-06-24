using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSelecter : MonoBehaviour
{
    public banphim movementScript1;
    public chuot movementScript2;

    private bool useMovement1 = true; 

    void Start()
    {
        if (useMovement1)
        {
            movementScript1.enabled = true;
            movementScript2.enabled = false;
        }
        else
        {
            movementScript1.enabled = false;
            movementScript2.enabled = true;
        }
    }

    public void SetMovement(int movementType)
    {
        if (movementType == 1)
        {
            useMovement1 = true;
            movementScript1.enabled = true;
            movementScript2.enabled = false;
        }
        else if (movementType == 2)
        {
            useMovement1 = false;
            movementScript1.enabled = false;
            movementScript2.enabled = true;
        }

    }
}