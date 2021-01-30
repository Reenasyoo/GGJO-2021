using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionPanelPuzzle : MonoBehaviour
{
    [SerializeField] private InteractableButtonController[] buttons;
    [SerializeField] private MeshRenderer signalLightRenderer = null;

    [SerializeField] private Material[] materials;
}
