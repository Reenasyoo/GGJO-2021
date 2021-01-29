using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableContainer : MonoBehaviour
{
    #region Propeties

    public CollectableCollisionController CollisionController => collisionController;

    #endregion

    #region Fields

    [SerializeField] private CollectableCollisionController collisionController = null;

    #endregion
    
}
