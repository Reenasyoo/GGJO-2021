using System.Collections;
using System.Collections.Generic;
using Systems;
using UnityEngine;

public class CharcterCollisionController : Collidable
{
    #region Fields
    
    [Header("Events")]
    [SerializeField] private GameEvent onShowPopupInfo = null;
    [SerializeField] private GameEvent onHidePopupInfo = null;
    [SerializeField] private GameEvent onSetCollectableText = null;

    #endregion
    
    private void OnTriggerEnter(Collider other)
    {
        if (CheckCollisionType(other) == CollisionType.COLLECTABLE)
        {
            print("entered collectable");
            onSetCollectableText?.Raise(); 
            onShowPopupInfo?.Raise();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        // TODO: 
    }

    private void OnTriggerExit(Collider other)
    {
        if (CheckCollisionType(other) == CollisionType.COLLECTABLE)
        {
            print("exited collectable");
            if(onHidePopupInfo != null) onHidePopupInfo.Raise();
        }
    }
}
