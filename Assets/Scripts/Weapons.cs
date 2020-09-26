using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Weapons : MonoBehaviour
{
    public static Weapons instance;
    [SerializeField] private Transform firstPersonWeapon;
    [SerializeField] private Transform foodHolder;
    [SerializeField] private int fireSpeed;
    public Weapons weaponsScript;
    public Transform outsideFoodContainter;

    public int burgerCount, maxBurgerCount;
    public int ketchupCount, maxKetchupCount;
    public int mustardCount, maxMustardCount;
    public int shakeCount, maxShakeCount;

    public Rigidbody burger;
    public Rigidbody ketchup;
    public Rigidbody mustard;
    public Rigidbody shake;

    public Transform bulletSpawn;

    public bool spawningAllowed;
    public static Weapons Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<Weapons>();
                if (instance == null)
                {
                    GameObject singleton = new GameObject();
                    singleton.AddComponent<Weapons>();
                    singleton.name = "(Singleton) Weapons";
                }
            }
            return instance;
        }
    }
    private void Awake()
    {
        instance = this;
        weaponsScript = GetComponent<Weapons>();

    }
    public void Update()
    {
        InstantiateFood();
        DestroyFood();
        


    }   
    public void InstantiateFood()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            { Rigidbody burgerCloneRB = Instantiate(burger, bulletSpawn.position, bulletSpawn.rotation) ;
                
                //burgerCloneRB.transform.Translate(Vector3.forward * fireSpeed, Space.World);
                burgerCloneRB.AddForce(Vector3.forward * fireSpeed);
                PlayerManager.instance.currentWeapon = PlayerManager.instance.burger;
                PlayerManager.instance.burger.SetActive(true);
                burgerCount += 1;
                Debug.Log("Burger instantiated. Total burgers: " + burgerCount); }

        if ( Input.GetKeyDown(KeyCode.Alpha2))
            { Rigidbody ketchupCloneRB = Instantiate(ketchup, bulletSpawn.position, bulletSpawn.rotation);
            
                ketchupCloneRB.transform.Translate(Vector3.forward * fireSpeed, Space.World);
                PlayerManager.instance.currentWeapon = PlayerManager.instance.ketchup;
                PlayerManager.instance.ketchup.SetActive(true);
                ketchupCount += 1;
                Debug.Log("Ketchup instantiated. Total ketchups: " + ketchupCount); }

        if (Input.GetKeyDown(KeyCode.Alpha3))
            { Rigidbody mustardCloneRB = Instantiate(mustard, bulletSpawn.position, bulletSpawn.rotation);
           
                mustardCloneRB.transform.Translate(Vector3.forward * fireSpeed, Space.World);
                PlayerManager.instance.currentWeapon = PlayerManager.instance.mustard;
                PlayerManager.instance.mustard.SetActive(true);
                mustardCount += 1;
                Debug.Log("Mustard instantiated. Total mustards: " + mustardCount); }
        if ( Input.GetKeyDown(KeyCode.Alpha4))
            { Rigidbody shakeCloneRB =  Instantiate(shake, bulletSpawn.position, bulletSpawn.rotation);
           
                shakeCloneRB.transform.Translate(Vector3.forward * fireSpeed, Space.World);
                PlayerManager.instance.currentWeapon = PlayerManager.instance.shake;
                PlayerManager.instance.shake.SetActive(true);
                shakeCount += 1;
                Debug.Log("Shake instantiated. Total shakes: " + shakeCount); }
    }

    public void DestroyFood()
    {
        
        if (instance.burgerCount >= maxBurgerCount) if (gameObject.tag == "Burger") {  Destroy(PlayerManager.instance.burger); }
        if (instance.ketchupCount >= maxKetchupCount) if (gameObject.tag == "Ketchup") { Destroy(PlayerManager.instance.ketchup); }
        if (instance.mustardCount >= maxMustardCount) if (gameObject.tag == "Mustard") { Destroy(PlayerManager.instance.mustard); }
        if (instance.shakeCount >= maxMustardCount) if (gameObject.tag == "Shake") { Destroy(PlayerManager.instance.shake); }
    }
}
