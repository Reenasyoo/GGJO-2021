using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionPanelPuzzle : MonoBehaviour
{
    #region Properties

    public int PuzzleRightCount  = 0;

    #endregion

    #region Fields

    [SerializeField] private InteractableButtonController[] buttons;
    [SerializeField] private MeshRenderer signalLightRenderer = null;

    [SerializeField] private Material[] materials;
    
    #endregion
    
    public void StartPuzzleOne()
    {
        ResePuzzle();
    }

    private IEnumerator ShowGreen()
    {
        GameManager.Instance.CanPress = false;
        signalLightRenderer.material = materials[1];
        PuzzleRightCount++;
        
        yield return new WaitForSeconds(0.3f);
        GameManager.Instance.CanPress = true;
        signalLightRenderer.material = materials[0];
    }
    
    private IEnumerator ShowRed()
    {
        GameManager.Instance.CanPress = false;
        signalLightRenderer.material = materials[2];
        ResePuzzle();
        yield return new WaitForSeconds(0.3f);
        GameManager.Instance.CanPress = true;
        signalLightRenderer.material = materials[0];
    }

    public void Right()
    {
        print("right");
        StartCoroutine(ShowGreen());
    }

    public void Wrong()
    {
        StartCoroutine(ShowRed());
    }

    private void ResePuzzle()
    {
        PuzzleRightCount = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CameraController.Instance.SetFocus();
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CameraController.Instance.SetPlayerCamera();
        }
    }
}
