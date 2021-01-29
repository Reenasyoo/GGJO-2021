using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collidable : MonoBehaviour, ICollidable
{
    #region Properties

    public CollisionType Type => type;

    #endregion

    [SerializeField] private CollisionType type = CollisionType.DEFAULT; 
    
    public CollisionType CheckCollisionType(Collider other)
    {
        var collidable = other.gameObject.GetComponent<Collidable>();

        return collidable != null ? collidable.type : CollisionType.DEFAULT;
    }
}


public enum CollisionType
{
    DEFAULT = 0,
    COLLECTABLE = 1,
    INTERACTABLE = 2,
    PLAYER = 3
}