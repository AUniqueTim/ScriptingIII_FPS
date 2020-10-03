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
    [SerializeField] private Transform magentaRayOrigin;
    [SerializeField] private Transform cyanRayOrigin;
    [SerializeField] private Transform detectionDistanceTransform;

    private Vector3 playerDirection;
    public float detectionDistance;
    public Vector3 detectionRangeVector;
    public Animator lunchLadyAnimator;

    public Ray ray;


    

    void Awake()
    {
        playerDirection = player.position - transform.position;
        lunchLadyAnimator = GetComponent<Animator>();
        
    }
    private void Update()
    {
        
        Vector3 direction = Vector3.Normalize(Vector3.forward);
        float distance = Vector3.Distance(transform.position, detectionDistanceTransform.position);


        Ray ray = new Ray(cyanRayOrigin.position, Vector3.forward * distance);
        Ray r_detectionDistance = new Ray(magentaRayOrigin.position, Vector3.forward *detectionDistance);

        Debug.DrawRay(r_detectionDistance.origin, direction * detectionDistance, Color.magenta);


        RaycastHit playerInRange;
        
        if (Physics.Raycast(r_detectionDistance,out playerInRange, detectionDistance, layerMask))
        {
            Debug.DrawRay(ray.origin, direction * detectionDistance, Color.cyan);
            playerInRange.collider.gameObject.GetComponent<Renderer>().material.color = Color.yellow;
        }
        RaycastHit hitPlayer;
        if (Physics.Raycast(ray, out hitPlayer, detectionDistance, layerMask))
        {
            //hitPlayer.collider.gameObject.CompareTag("Player");
            if (hitPlayer.collider.gameObject.tag == "Player")
            {
                hitPlayer.collider.gameObject.GetComponent<Renderer>().material.color = Color.red;
                Debug.Log("YES");
                
            }
            
        }
        else if (!Physics.Raycast(ray, out hitPlayer, detectionDistance, layerMask))
        { 
            playerGO.GetComponent<Renderer>().material.color = Color.green;
            Debug.Log("NO");
        }
    }


}
