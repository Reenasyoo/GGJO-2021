using UnityEngine;

public interface ICollidable
{
    CollisionType CheckCollisionType(Collider other);
}

