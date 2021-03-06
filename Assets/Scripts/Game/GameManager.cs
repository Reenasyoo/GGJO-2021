using System;
using System.Collections;
using System.Collections.Generic;
using Systems;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region Properties
    public static GameManager Instance { get; private set; } = null;

    [SerializeField] private InteractionPanelPuzzle puzzleOne = null;

    public bool CanPress = true;
    public int PuzzleButtonPressed = -1;

    #endregion

    #region Fields

    [SerializeField] private GameCanvasController gameCanvasController = null;
    
    [SerializeField] private GameEvent OnPuzzleOneInitiatedEvent = null;
    [SerializeField] private GameEvent OnPuzzleOneEndedEvent = null;
    
    public bool locked = false;
    
    #endregion

    #region Init
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        PuzzleButtonPressed = -1;
    }

    private void Start()
    {
        StartCoroutine(ShowFirstText());
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (PuzzleButtonPressed == 0)
        {
            OnPuzzleOneInitiatedEvent.Raise();
        }

        if (puzzleOne.PuzzleRightCount == 4)
        {
            OnPuzzleOneEndedEvent.Raise();
        }
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (locked == false)
            {
                Debug.Log("locked");
                Cursor.lockState = CursorLockMode.Locked;
                locked = true;
            }
            else
            {
                Debug.Log("Unlocked");
                Cursor.lockState = CursorLockMode.None;
                locked = false;
            }
        }
    }

    public void CheckPressedButton()
    {
        TrueOrFalse(puzzleOne.PuzzleRightCount);
    }

    private void TrueOrFalse(int value)
    {
        if (PuzzleButtonPressed == value)
        {
            puzzleOne.Right();
        }
        else
        {
            puzzleOne.Wrong();
        }
    }

    private IEnumerator ShowFirstText()
    {
        gameCanvasController.PopupInfoText.text = " Find four missing parts to your ship";
        gameCanvasController.PopupInfoText.gameObject.SetActive(true);
        yield return new WaitForSeconds(5f);
        gameCanvasController.PopupInfoText.gameObject.SetActive(false);
    }

    #endregion


}
