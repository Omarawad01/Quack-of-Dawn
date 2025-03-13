using UnityEngine;
using System.Collections;


public class SceneController : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;

    private GameObject enemy;

    void Start()
    {
        
    }

    void Update()
    {
        
        if(enemy == null)
        {
            enemy = Instantiate(enemyPrefab) as GameObject;
            enemy.transform.position = new Vector3(84, 43, 95);
            float angle = Random.Range(0, 360);
            enemy.transform.Rotate(0, angle, 0);
        }
    }
}
