using System.Collections;
using System.Collections.Generic;
using Systems;
using UnityEngine;

public class CharacterCollisionController : Collidable
{
    #region Properties

    public GameEvent OnHidePopupInfo => onHidePopupInfo;

    public GameObject CurrentCollectable { get; private set; } = null;
    public InteractablePlaceholder CollectablePlace { get; private set; } = null;
    public bool CanPlace { get; private set; } = false;
    public int PlaceToSet { get; private set; } = -1;

    #endregion
    
    #region Fields

    [SerializeField] private CharacterContainer container;
    
    [Header("Events")]
    [SerializeField] private GameEvent onShowPopupInfo = null;
    [SerializeField] private GameEvent onHidePopupInfo = null;
    [SerializeField] private GameEvent onSetCollectableText = null;
    [SerializeField] private GameEvent onSetPlaceText = null;

    #endregion
    
    private void OnTriggerEnter(Collider other)
    {
        if (CheckCollisionType(other) == CollisionType.COLLECTABLE)
        {
            print("entered collectable");
            CurrentCollectable = other.gameObject;

            // Raise events
            onSetCollectableText?.Raise(); 
            onShowPopupInfo?.Raise();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (CheckCollisionType(other) == CollisionType.COLLECTABLE_PLACE)
        {
            var interactablePlaceholder = other.gameObject.GetComponent<InteractablePlaceholder>();
            if (!interactablePlaceholder.IsPlaced())
            {
                var holderIndex = interactablePlaceholder.placeholderIndex;
                if (container.ActionController.CycleInventory(holderIndex))
                {
                    print("got place");
                    CanPlace = true;
                    CollectablePlace = interactablePlaceholder;
                    onSetPlaceText.Raise();
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (CheckCollisionType(other) == CollisionType.COLLECTABLE)
        {
            print("exited collectable");
            if (CurrentCollectable != null)
            {
                CurrentCollectable = null;
                if(onHidePopupInfo != null) onHidePopupInfo.Raise();
            }
        }

        if (CheckCollisionType(other) == CollisionType.COLLECTABLE_PLACE)
        {
            if(onHidePopupInfo != null) onHidePopupInfo.Raise();
        }
    }

    public void RemoveCurrentCollectable()
    {
        CurrentCollectable.SetActive(false);
        CurrentCollectable = null;
        if(onHidePopupInfo != null) onHidePopupInfo.Raise();
    }
}
