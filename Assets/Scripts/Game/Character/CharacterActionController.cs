using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Systems;
using UnityEngine;

public class CharacterActionController : MonoBehaviour
{
    #region Properties

    

    #endregion
    
    #region Feilds
    [SerializeField] private CharacterContainer container = null;

    [Header("Inventory")]
    [SerializeField] private GameObject inventory = null;
    
    [Space]
    [SerializeField] private List<Interactable> collectableList = new List<Interactable>();
    
    
    [Header("Events")]
    [SerializeField] private GameEvent OnCollectablePickup = null;
    
    #endregion
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (container.CollisionController.CurrentCollectable != null)
                PickupCollectable();

            if (container.CollisionController.CanPlace)
            {
                container.CollisionController.CollectablePlace.EnableMesh();
            }
        }
    }
    
    public void PickupCollectable()
    {
        var copy = Instantiate(container.CollisionController.CurrentCollectable, inventory.transform, true);
        copy.AddComponent<Interactable>();
        copy.SetActive(false);
        
        var tempInteractable = copy.GetComponent<Interactable>();
        collectableList.Add(tempInteractable);
        container.CollisionController.RemoveCurrentCollectable();
        OnCollectablePickup?.Raise();
    }

    public bool CycleInventory(int value)
    {
        return collectableList.Any(interactable => interactable.index == value);
    }

    public int ReturnPlace(int value)
    {
        var placeIndex = -1;
        
        foreach (var interactable in collectableList.Where(interactable => value == interactable.index))
        {
            placeIndex = value;
        }

        return placeIndex;
    }

    private void PlaceCollectable()
    {
        foreach (var interactable in collectableList)
        {
            
        }
    }
}
