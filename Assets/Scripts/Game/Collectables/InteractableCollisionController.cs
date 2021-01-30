using System;
using System.Collections;
using System.Collections.Generic;
using Systems;
using UnityEngine;

public class InteractableCollisionController : Collidable
{

    private void OnTriggerEnter(Collider other)
    {
        // if (CheckCollisionType(other) == CollisionType.PLAYER)
        // {
        //     
        // }
    }

    private void OnTriggerStay(Collider other)
    {
        // TODO: 
    }

    private void OnTriggerExit(Collider other)
    {
        // TODO:
    }
}
