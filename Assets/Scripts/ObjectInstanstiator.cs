using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInstanstiator : MonoBehaviour
{
    [Header("Game Objects")]
    public GameObject objectInstantiator;   //This game object assigned in Inspector.
    public GameObject[] objects;            //Array of individual objects to be instantiated.
    public GameObject player;               //Player GO.
    private GameObject instantiatedObject;  //Each instance of an individual objects instantiated.

    public Transform firePoint;

    public bool instantiatingAllowed;
    private bool objectInstantiated;         //Returns true immedietly after an individual object is instantiated.
    public bool playerCollision = false;    //Used to detect whether or not player object has collided with this instance of an object.

    [Header("Number of Objects Instantiated")]
    public int objectCount;                 //Current number of objects that have been instantiated.
    [Header("Max Objects Allowed")]
    public int maxObjectCount;              //Maximum number of objects that can be instantiated at once.

    [Header("Fire Speed")]
    public int fireSpeed;

    [Header("Random Distance Range From Player")]
    public float xDistanceFromPlayerMin;
    public float xDistanceFromPlayerMax;
    public float yDistanceFromPlayerMin;
    public float yDistanceFromPlayerMax;
    public float zDistanceFromPlayerMin;
    public float zDistanceFromPlayerMax;



    private void Awake()
    {
        instantiatedObject = null;
    }
    void Start()
    {
        objectInstantiated = false;
        instantiatingAllowed = true;
        
    }
    public void Update()
    {
        if (instantiatingAllowed) { if (playerCollision == true) { InstantiateObject() ; } }
        if (objectCount <= maxObjectCount) { instantiatingAllowed = true; }
        else /*if (objectCount > maxObjectCount)*/ { instantiatingAllowed = false; Destroy(instantiatedObject); }
    }
    
    void InstantiateObject()
    {
        //gameObject.SetActive(true);
        Instantiate(instantiatedObject  = objects[Random.Range(0, 4)], firePoint.position, instantiatedObject.transform.rotation, gameObject.transform);
        instantiatedObject.transform.Translate(Vector3.forward * fireSpeed);
        objectInstantiated = true;
        objectCount += 1;
        if (objectInstantiated) { instantiatedObject.SetActive(true); }
        instantiatedObject.GetComponent<Rigidbody>().AddForce(Vector3.forward * fireSpeed);
        Debug.Log("Instantaited Object" );
        objectInstantiated = false;
        playerCollision = false;
    }
    public void OnTriggerEnter(Collider collision) {if (collision.gameObject.tag == "Player")
        { playerCollision = true; }
    }
    //(Random.Range(xDistanceFromPlayerMin, xDistanceFromPlayerMax),
    //    Random.Range(yDistanceFromPlayerMin, yDistanceFromPlayerMax),
    //    Random.Range(zDistanceFromPlayerMin, zDistanceFromPlayerMax))
}