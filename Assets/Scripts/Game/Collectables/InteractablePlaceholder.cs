using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractablePlaceholder : MonoBehaviour
{
    [SerializeField] private MeshRenderer meshRenderer = null;
    [SerializeField] private InteractableCollisionController collisionController;

    public int placeholderIndex = 0;

    public Material materialToSwitch = null;

    private bool isPlaced = false;

    public void EnableMesh()
    {
        meshRenderer.material = materialToSwitch;
        isPlaced = true;
    }

    public bool IsPlaced()
    {
        return isPlaced;
    }
}
