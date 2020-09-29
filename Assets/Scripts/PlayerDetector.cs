using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private Transform player;
    [SerializeField] private GameObject playerGO;
    [SerializeField] private Transform lunchLady;
    private Vector3 playerDirection;
    private Vector3 detectionRange;

    public float xDistance;
    public float yDistance;
    public float zDistance;
    void Awake()
    {
        playerDirection = player.position - transform.position;
        detectionRange = playerDirection - new Vector3(xDistance,yDistance,zDistance);
    }
    private void Update()
    {
        Vector3 direction = Vector3.Normalize(playerDirection - detectionRange);
        float distance = Vector3.Distance(transform.position, player.transform.position - detectionRange);
        Debug.Log(distance);

        Ray ray = new Ray(transform.position, direction);

        Debug.DrawRay(ray.origin, ray.direction * distance, Color.cyan, 1f);


        

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, distance, layerMask))
        {
            hit.collider.gameObject.GetComponent<Renderer>().material.color = Color.red;
            Debug.Log("YES");
        }
        else{
            playerGO.GetComponent<Renderer>().material.color = Color.green;

            Debug.Log("NO");
        }
    }
    
}
