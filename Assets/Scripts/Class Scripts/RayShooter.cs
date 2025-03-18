using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.EventSystems;
public class RayShooter : MonoBehaviour
{
    private Camera cam;

    private void Start()
    {
        cam = GetComponent<Camera>();

        // hide the crusor
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false; 

    }

    private void OnGUI()
    {
        int size = 24;
        float posX = cam.pixelWidth / 2 - size / 4;
        float posY = cam.pixelHeight / 2 - size - 2;

        GUI.Label(new Rect(posX, posY, size, size), "+");

        if (GUI.Button(new Rect(10,10,180,20), "Click here!"))
        {
            Debug.Log("Button clicked!");
        }
    }

    private IEnumerator SphereIndicator(Vector3 pos)
    {
        // Create a sphere at the specified position.
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        // Move the sphere to the specified position.
        sphere.transform.position = pos;
        // Wait for 1 second.
        yield return new WaitForSeconds(1);
        // Destroy the sphere.
        Destroy(sphere);
    }

    void Update(){
        // When the left mouse button is clicked...
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            // calculates center of the screen
            Vector3 point = new Vector3(cam.pixelWidth / 2, cam.pixelHeight / 2, 0);

            // Create a ray starting at the camera's position, going forward.
            Ray ray = cam.ScreenPointToRay(point);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("Hit: " + hit.point);

                GameObject hitObject = hit.transform.gameObject;
                ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
                if (target != null) {
                    target.ReactToHit();
                    if( target._deathAnim != null) Messenger.Broadcast(GameEvents.ENEMY_HIT);
                    Debug.Log("target hit!");
                }
                else
                {
                    StartCoroutine(SphereIndicator(hit.point));
                }
            }
        }
    }
}
