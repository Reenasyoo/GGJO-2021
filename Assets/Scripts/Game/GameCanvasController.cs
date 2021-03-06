using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameCanvasController : MonoBehaviour
{
    public TextMeshProUGUI PopupInfoText => popupInfoText;
    
    
    [SerializeField] private TextMeshProUGUI popupInfoText = null;

    private const string CollectString = "Press E to collect the item";
    private const string PlaceString = "Press E to place object";

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
        SetPopupInfoText(CollectString);
    }

    public void ShowPlaceText()
    {
        ShowHidePopupInfo(true);
        SetPopupInfoText(PlaceString);
    }
    
}
