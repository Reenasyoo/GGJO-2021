using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractablePlaceholder : MonoBehaviour
{
    [SerializeField] private MeshRenderer meshRenderer = null;
    [SerializeField] private InteractableCollisionController collisionController;
    
    public int placeholderIndex = 0;

    public void EnableMesh()
    {
        meshRenderer.enabled = true;
    }
}
