using UnityEngine;

interface IInteractable
{
    void Interact();
}

public class Interactor : MonoBehaviour
{
    public Transform InteractorSource;
    public float InteractorRange = 2f; // Adjust as needed for your range

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray r = new Ray(InteractorSource.position, InteractorSource.forward);
            if (Physics.Raycast(r, out RaycastHit hitInfo, InteractorRange))
            {
                // Check if the hit object has the IInteractable interface and the PickUpItem script
                if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj) &&
                    hitInfo.collider.gameObject.TryGetComponent(out PickupItem pickUpItem))
                {
                    // If both components are found, interact with the item
                    interactObj.Interact();
                }
            }
        }
    }
}
