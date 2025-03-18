using System.Collections;
using System.Collections.Generic;  
using UnityEngine;
using UnityEngine.AI;


public class WanderingAI : MonoBehaviour
{
    // Projectile to shoot
    [SerializeField] GameObject fireballPrefab;
    private GameObject fireball;


    public float speed = 3f;
    public float obstacleRange = 5f;

    private bool isAlive;

    public const float _baseSpeed = 3f;

    void OnEnable()
    {
        Messenger<float>.AddListener(GameEvents.SPEED_CHANGED, OnSpeedChanged);
    }

    private void OnDisable()
    {
        Messenger<float>.RemoveListener(GameEvents.SPEED_CHANGED, OnSpeedChanged);
    }
    private void OnSpeedChanged(float value)
    {
        speed = _baseSpeed * value;
    }

    private void Start()
    {
        isAlive = true; 
    }

    void Update()
    {
        //move forward
        if (isAlive) {
            transform.Translate(0, 0, speed * Time.deltaTime);
        }
        //Create a ray in the same direction as the game object's direction of movement
        Ray ray = new Ray(transform.position, transform.forward);

        RaycastHit hit;
        if(Physics.SphereCast(ray, 0.75f, out hit)){
            GameObject hitObject = hit.transform.gameObject;

            if (hitObject.GetComponent<PlayerCharacter>())
            {
                if (fireball == null)
                {
                    fireball = Instantiate(fireballPrefab) as GameObject;
                    fireball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                    fireball.transform.rotation = transform.rotation;
                }else if(hit.distance < obstacleRange){
                    float angle = Random.Range(-110, 110);
                    transform.Rotate(0, angle, 0);
                }
            }

            if(hit.distance < obstacleRange)
            {
                float angle = Random.Range(-110, 110);
                transform.Rotate(0, angle, 0);
            }
        }
    }

    // Returns a random point on the NavMesh within a specified radius.
    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;
        randDirection += origin;
        NavMeshHit navHit;
        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);
        return navHit.position;
    }

    public void SetAlive(bool alive){
        isAlive = alive;
    }

}
