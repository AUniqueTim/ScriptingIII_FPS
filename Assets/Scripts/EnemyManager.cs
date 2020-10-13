using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;
    public static EnemyManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<EnemyManager>();
                if (instance == null)
                {
                    GameObject singleton = new GameObject();
                    singleton.AddComponent<PlayerManager>();
                    singleton.name = "(Singleton) PlayerManager";
                }
            }
            return instance;
        }
    }
    private void Awake()
    {
        instance = this;

    }
    [SerializeField] public int enemyHealth;
    [SerializeField] public int nBEnemies;
    [SerializeField] public int maxEnemies;
    [SerializeField] private Transform enemySpawn1;
    [SerializeField] private Transform enemySpawn2;
    [SerializeField] private Transform enemySpawn3;
    [SerializeField] private GameObject enemy1;
    [SerializeField] private GameObject enemy2;
    [SerializeField] private GameObject enemy3;

    public int[] enemies = new int[3];


}
