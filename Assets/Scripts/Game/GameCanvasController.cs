using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameCanvasController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI popupInfoText = null;

    private readonly string collectString = "Press E to collect the item";

    private void SetPopupInfoText(string value)
    {
        popupInfoText.text = value;
    }
    
    public void ShowHidePopupInfo(bool value)
    {
        popupInfoText.gameObject.SetActive(value);
    }

    public void SetCollectableText()
    {
        SetPopupInfoText(collectString);
    }
    
}
