using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterContainer : MonoBehaviour
{
    #region Properties

    public CharacterLocomotion Locomotion => locomotion;
    public CharacterActionController ActionController => actionController;
    public CharacterCollisionController CollisionController => collisionController;
    public CharacterAnimationController AnimationController => animationController;

    #endregion

    #region Fields
    
    [SerializeField] private CharacterLocomotion locomotion = null;
    [SerializeField] private CharacterActionController actionController = null;
    [SerializeField] private CharacterCollisionController collisionController = null;
    [SerializeField] private CharacterAnimationController animationController = null;
    
    #endregion
}
