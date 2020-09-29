using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private Transform player;
    [SerializeField] private GameObject playerGO;
    [SerializeField] private Transform lunchLady;
    [SerializeField] private Transform wayPoint1;
    [SerializeField] private Transform wayPoint2;

    private Vector3 playerDirection;
    public float detectionRange;
    public Vector3 detectionRangeVector;
    

    void Awake()
    {
        playerDirection = player.position - transform.position;
        
    }
    private void Update()
    {
        
        Vector3 direction = Vector3.Normalize(playerDirection);
        float distance = Vector3.Distance(transform.position, player.position);
        

        Ray ray = new Ray(transform.position, direction * detectionRange);
        Ray r_detectionDistance = new Ray(transform.position, player.transform.position);

        Debug.DrawRay(ray.origin, ray.direction * distance, Color.cyan);
        Debug.DrawRay(r_detectionDistance.origin, player.transform.position * detectionRange, Color.magenta);

        RaycastHit playerInRange;
        
        if (Physics.Raycast(r_detectionDistance,out playerInRange, detectionRange, layerMask))
        {
            playerInRange.collider.gameObject.GetComponent<Renderer>().material.color = Color.yellow;
        }
        RaycastHit hitPlayer;
        if (Physics.Raycast(ray, out hitPlayer, detectionRange, layerMask))
        {
            //hitPlayer.collider.gameObject.CompareTag("Player");
            if (hitPlayer.collider.gameObject.tag == "Player")
            {
                hitPlayer.collider.gameObject.GetComponent<Renderer>().material.color = Color.red;
                Debug.Log("YES");
            }
            
        }
        else if (!Physics.Raycast(ray, out hitPlayer, detectionRange, layerMask))
        { 
            playerGO.GetComponent<Renderer>().material.color = Color.green;
            Debug.Log("NO");
        }
    }
    private void FixedUpdate()
    {

    }

}
