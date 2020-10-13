using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   // public Transform player;
    public GameObject player;
    [SerializeField] private float speed;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private GameObject playerGO;
    [SerializeField] private Transform enemyRayOrigin;
    [SerializeField] private Transform enemyDetectionDistanceTransform;
    [SerializeField] private float detectionDistance;
    [SerializeField] private MeshRenderer enemyMeshRenderer;
    [SerializeField] private Camera camera;

    [Header("Waypoints")]

    [SerializeField] private Transform wayPoint1;
    [SerializeField] private Transform wayPoint2;

    [Header("Enemy Health")]
    [SerializeField] int enemyHealth = 3;

    [SerializeField] GameObject[] enemyWeapons = new GameObject[4];

    //Audio
    //public AudioClip death;
    //public AudioSource audiosource;
    //public AudioClip Running;
    //public AudioSource audiosource2;
    //public AudioClip hit;
    //public AudioSource audiosource3;
    [SerializeField] private int killCount;
    [SerializeField] private int killThreshold = 50;

    public void Awake()
    {
        killThreshold = PlayerManager.instance.killThreshold;
        killCount = PlayerManager.instance.killCount;
        enemyHealth = EnemyManager.instance.enemyHealth;
    }
    public void Update()
    {
        //Enemy Raycast

        Vector3 direction = Vector3.forward * speed;
        Vector3 detectionRange = direction * detectionDistance;

        Ray enemyDetectionDistanceRay = new Ray(enemyRayOrigin.position, player.gameObject.transform.position * detectionDistance);
        //Debug.DrawRay(enemyDetectionDistanceRay.origin, player.gameObject.transform.position * detectionDistance, Color.red);
        //Debug.DrawRay(enemyDetectionDistanceRay.origin, detectionRange, Color.green);

        if (Physics.Raycast(enemyDetectionDistanceRay, out RaycastHit enemyHit, detectionDistance))
        {
            if (enemyHit.collider.tag == "Player")
            {
                Debug.Log("Enemy raycast hit player.");
            }
            Debug.DrawRay(enemyDetectionDistanceRay.origin, camera.transform.position * detectionDistance, Color.red);
            Instantiate(enemyWeapons[Random.Range(0, 3)], enemyRayOrigin.transform.position, enemyRayOrigin.transform.rotation);
        }
        //End Enemy Raycast
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
            Debug.Log("Enemy Destroyed.");
            PlayerManager.instance.killCount++;
        }
        if (killCount >= killThreshold)
        {
            PlayerWon();
        }
    }
    public void PlayerWon()
    {
        Debug.Log("Player won.");
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Burger" ||
            collision.gameObject.tag == "Ketchup" ||
            collision.gameObject.tag =="Mustard" ||
            collision.gameObject.tag =="Shake")
        {
            enemyHealth -= 1;
        }
    }
}
