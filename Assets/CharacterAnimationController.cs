using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{

    #region Fields

    [SerializeField] private CharacterContainer container = null;
    [SerializeField] private Animator characterAnimator = null;

    #endregion
    
    public void SetForwardVelocity(float value)
    {
        characterAnimator.SetFloat(VARS.FORWARD_VELOCITY, value);
    }

}
