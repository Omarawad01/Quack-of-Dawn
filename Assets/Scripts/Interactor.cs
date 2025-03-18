// In Interactor.cs
using UnityEngine;

public class Interactor : MonoBehaviour
{
    [SerializeField] private PickupItem pickupItem; // Assign in Inspector

    void Update()
    {
        // Handle pickup (E key)
        if (Input.GetKeyDown(KeyCode.E))
        {
            TryPickup();
        }

        // Handle drop (Q key)
        if (Input.GetKeyDown(KeyCode.Q))
        {
            TryDrop();
        }
    }

    public void TryPickup()
    {
        if (pickupItem != null)
        {
            pickupItem.TryPickupItem();
        }
    }

    public void TryDrop()
    {
        if (pickupItem != null)
        {
            pickupItem.DropItem(); // Call the public DropItem method
        }
    }
}