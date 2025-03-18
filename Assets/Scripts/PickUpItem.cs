using UnityEngine;

public class PickupItem : MonoBehaviour
{
    [Header("References")]
    public Transform handTransform;
    public float pickupRadius = 2f;
    public Vector3 holdPositionOffset = Vector3.zero;
    public Vector3 holdRotationOffset = Vector3.zero;

    private GameObject heldItem;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) TryPickupItem();
        if (Input.GetKeyDown(KeyCode.Q)) DropItem();
    }

    public void TryPickupItem()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, pickupRadius);
        GameObject closestItem = null;
        float closestDistance = Mathf.Infinity;

        foreach (Collider col in colliders)
        {
            if (col.CompareTag("Pickup"))
            {
                float distance = Vector3.Distance(transform.position, col.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestItem = col.gameObject;
                }
            }
        }

        if (closestItem != null) AttachItem(closestItem);
    }

    void AttachItem(GameObject item)
    {
        heldItem = item;

        Rigidbody rb = item.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true;
            // Kinematic bodies ignore velocity, so no need to set linear/angularVelocity
        }

        foreach (Collider c in item.GetComponents<Collider>())
        {
            c.enabled = false;
        }

        item.transform.SetParent(handTransform);
        item.transform.localPosition = holdPositionOffset;
        item.transform.localRotation = Quaternion.Euler(holdRotationOffset);
    }

    public void DropItem()
    {
        if (heldItem == null) return;

        Rigidbody rb = heldItem.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = false;
            rb.AddForce(transform.forward * 3f, ForceMode.Impulse); // Valid for non-kinematic bodies
        }

        foreach (Collider c in heldItem.GetComponents<Collider>())
        {
            c.enabled = true;
        }

        heldItem.transform.SetParent(null);
        heldItem = null;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, pickupRadius);
    }
}