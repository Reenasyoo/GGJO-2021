using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableContainer : MonoBehaviour
{
    #region Propeties

    public InteractableCollisionController CollisionController => collisionController;

    #endregion

    #region Fields

    [SerializeField] private InteractableCollisionController collisionController = null;

    #endregion

    // When collectable picked up destroy object that is in scene
    public void DestroyCollectable()
    {
        Destroy(this.gameObject);
    }
}
