/*
 This should be placed within the character as a component.
 This script allows for the interaction with other objects as long as they 
 have a function within a script that calls the interact function from this file.

LINK TO SOURCE: https://www.youtube.com/watch?v=K06lVKiY-sY
 */

using UnityEngine;

// testing to see if this is on ali branch

interface IInteractable
{
    public void Interact();
}

public class Interactor : MonoBehaviour
{
    // Variables for the range
    public Transform InteractorSource;
    public float InteractorRange = 1.4f; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray r = new Ray(InteractorSource.position, InteractorSource.forward);
            if(Physics.Raycast(r, out RaycastHit hitInfo, InteractorRange))
            {
                if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
                {
                    interactObj.Interact();
                }
            }
        }
    }
}
