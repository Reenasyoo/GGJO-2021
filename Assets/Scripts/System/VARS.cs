using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VARS : MonoBehaviour
{
    public static readonly string JUMP_STRING = "Jump";
    public static readonly string HORIZONTAL_STRING = "Horizontal";
    public static readonly string VERTICAL_STRING = "Vertical";
    
    public static readonly int FORWARD_VELOCITY = Animator.StringToHash("ForwardVelocity");
}
