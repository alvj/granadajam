using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float enemyRate;
    [SerializeField] float radius;
    [SerializeField] float minDistanceToPlayer;

    float timer;
    bool canSpawn = true;

    private void Update()
    {
        if (canSpawn)
        {
            timer += Time.deltaTime;

            if(timer > enemyRate)
            {
                timer = 0;
                SpawnEnemy();
            }
        }
    }

    void SpawnEnemy()
    {
        Vector3 newPosition = Random.insideUnitCircle * radius;

        if(Vector3.Distance(newPosition, this.transform.position) > minDistanceToPlayer)
        {
            GameObject newEnemy = Instantiate(enemyPrefab, newPosition, Quaternion.identity);
        }
        else
        {
            print("Demasiado cerca, intentando de nuevo");
            SpawnEnemy();
        }
    }
}
