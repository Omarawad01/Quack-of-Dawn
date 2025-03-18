using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public Transform handTransform;  // Reference to the hand where items are held
    public float pickupRadius = 2f;  // Radius in which items can be picked up
    private GameObject heldItem;     // Stores the currently held item

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (heldItem == null)
            {
                TryPickupItem();
            }
            else
            {
                DropItem();
            }
        }
    }

    void TryPickupItem()
    {
        // Find all colliders in the pickup radius
        Collider[] colliders = Physics.OverlapSphere(transform.position, pickupRadius);
        GameObject closestItem = null;
        float closestDistance = Mathf.Infinity;

        foreach (Collider col in colliders)
        {
            if (col.CompareTag("Pickup")) // Check if the object is a valid pickup
            {
                float distance = Vector3.Distance(transform.position, col.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestItem = col.gameObject;
                }
            }
        }

        if (closestItem != null)
        {
            AttachItem(closestItem);
        }
    }

    void AttachItem(GameObject item)
    {
        heldItem = item;
        item.transform.SetParent(handTransform);
        item.transform.localPosition = Vector3.zero;
        item.transform.localRotation = Quaternion.identity;

        // Disable physics so it doesn't fall
        Rigidbody rb = item.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true;
        }
    }

    void DropItem()
    {
        if (heldItem != null)
        {
            // Re-enable physics and unparent the object
            Rigidbody rb = heldItem.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = false;
            }

            heldItem.transform.SetParent(null);
            heldItem = null;
        }
    }

    // Debugging: Draw the pickup radius in the scene view
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, pickupRadius);
    }
}