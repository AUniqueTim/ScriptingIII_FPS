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

    public float detectionDistance;
    public Vector3 detectionRangeVector;
    public Animator lunchLadyAnimator;
    public Ray ray;

    void Awake()
    {
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
        
        if (Physics.Raycast(r_detectionDistance,out playerInRange, detectionDistance))
        {
            Debug.DrawRay(ray.origin, direction * detectionDistance, Color.cyan);
           // playerInRange.collider.gameObject.GetComponent<Renderer>().material.color = Color.yellow;
        }
        RaycastHit hitPlayer;
        if (Physics.Raycast(ray, out hitPlayer, detectionDistance))
        {
            if (hitPlayer.collider.gameObject.tag == "Player")
            {
                gameObject.GetComponent<Renderer>().material.color = Color.red;
                Debug.Log("YES");
            }
        }
        else if (!Physics.Raycast(ray, out RaycastHit hitPlayer02, detectionDistance))
        {
            if (hitPlayer02.collider.gameObject) {
                gameObject.GetComponent<Renderer>().material.color = Color.green;
                Debug.Log("NO");
            }
            
        }
    }


}
