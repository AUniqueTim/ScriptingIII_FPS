using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroyer : MonoBehaviour
{
    public GameObject enemyPrefab;
    [SerializeField] private Transform enemyPrefabParent;
    [SerializeField] public Transform[] spawnLocations;

    

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Instantiate(enemyPrefab, spawnLocations[Random.Range(0, spawnLocations.Length)].transform.position, enemyPrefab.transform.rotation, enemyPrefabParent);
            
            EnemyManager.instance.nBEnemies++;
        }
        if(EnemyManager.instance.nBEnemies <= 0)
        {
            Instantiate(enemyPrefab, enemyPrefabParent.transform.position, enemyPrefab.transform.rotation);
            EnemyManager.instance.nBEnemies++;
        }
       
        
    }
}
