using UnityEngine;

public class PickupItem : MonoBehaviour
{
    // Reference to the hand transform (set in the inspector)
    public Transform handTransform;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object is a pickup (by tag, layer, etc.)
        if (other.CompareTag("Pickup"))
        {
            AttachItem(other.gameObject);
        }
    }

    void AttachItem(GameObject item)
    {
        // Parent the item to the hand and reset its local transform
        item.transform.SetParent(handTransform);
        item.transform.localPosition = Vector3.zero;
        item.transform.localRotation = Quaternion.identity;

        // Disable physics so it doesn’t interfere with animation
        Rigidbody rb = item.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true;
        }
    }
}
