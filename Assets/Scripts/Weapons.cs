using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Weapons : MonoBehaviour
{
    public static Weapons instance;
    //[SerializeField] private Transform firstPersonWeapon;
    //[SerializeField] private Transform foodHolder;
    [SerializeField] private int fireSpeed;
    

    public Weapons weaponsScript;
    //public Transform outsideFoodContainter;

    public int burgerCount, maxBurgerCount;
    public int ketchupCount, maxKetchupCount;
    public int mustardCount, maxMustardCount;
    public int shakeCount, maxShakeCount;

    public Rigidbody burger;
    public Rigidbody ketchup;
    public Rigidbody mustard;
    public Rigidbody shake;

    public GameObject handBurger;
    public GameObject handKetchup;
    public GameObject handMustard;
    public GameObject handShake;

    public Transform bulletSpawn;
    public bool spawningAllowed;
    public bool isBurgering;
    public bool isKetchuping;
    public bool isMustarding;
    public bool isShaking;
    public bool burgerActive;
    public bool ketchupActive;
    public bool mustardActive;
    public bool shakeActive;
    public bool noWeaponSelected;
    public bool hasBurgered;

    public Animator weaponAnimator;

    public MeshRenderer burgerMesh;

    //START SINGLETON
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

    //END SINGLETON
    public void Awake()
    {
        instance = this;
        weaponsScript = GetComponent<Weapons>();
        weaponAnimator = GetComponent<Animator>();
        burgerMesh = PlayerManager.instance.burgerHand.GetComponent<MeshRenderer>();
    }

   
    public void Update()
    {

        DestroyFood();
        WeaponSelect();
        
    }
    public void FixedUpdate()
    {
        InstantiateFood();
        
    }
    public void LateUpdate()
    {

    }


    public void WeaponSelect()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            handBurger.SetActive(true);
            handKetchup.SetActive(false);
            handMustard.SetActive(false);
            handShake.SetActive(false);
            burgerActive = true;
            ketchupActive = false;
            mustardActive = false;
            shakeActive = false;
            PlayerManager.instance.currentWeapon = PlayerManager.instance.burger;
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            handBurger.SetActive(false);
            handKetchup.SetActive(true);
            handMustard.SetActive(false);
            handShake.SetActive(false);
            ketchupActive = true;
            burgerActive = false;
            mustardActive = false;
            shakeActive = false;
            PlayerManager.instance.currentWeapon = PlayerManager.instance.ketchup;
        }
        else if (Input.GetKey(KeyCode.Alpha3))
        {
            handBurger.SetActive(false);
            handKetchup.SetActive(false);
            handMustard.SetActive(true);
            handShake.SetActive(false);
            mustardActive = true;
            burgerActive = false;
            ketchupActive = false;
            shakeActive = false;
            PlayerManager.instance.currentWeapon = PlayerManager.instance.mustard;
        }
        else if (Input.GetKey(KeyCode.Alpha4))
        {
            handBurger.SetActive(false);
            handKetchup.SetActive(false);
            handMustard.SetActive(false);
            handShake.SetActive(true);
            shakeActive = true;
            burgerActive = false;
            ketchupActive = false;
            mustardActive = false;
            PlayerManager.instance.currentWeapon = PlayerManager.instance.shake;
        }
        else if (noWeaponSelected) { burgerActive = false; ketchupActive = false; mustardActive = false; shakeActive = false; }
    }
    public void InstantiateFood()
    {

        if (Input.GetKeyDown(KeyCode.Mouse1) && burgerActive == true)
        {
            ketchupActive = false;
            mustardActive = false;
            shakeActive = false;
            Rigidbody burgerCloneRB = Instantiate(burger, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
            
            burgerCloneRB.AddForce(bulletSpawn.transform.position + Vector3.forward * fireSpeed);
            PlayerManager.instance.currentWeapon = PlayerManager.instance.burgerHand;
            PlayerManager.instance.burger.SetActive(true);
            burgerCount += 1;
            isBurgering = true;
            isKetchuping = false;
            isMustarding = false;
            isShaking = false;
            Debug.Log("Burger instantiated. Total burgers: " + burgerCount);

          
            if (burgerActive && isBurgering)
            {
                AnimateBurger();
            }
            if (!burgerActive)
            {
                StopBurgering();
            } 

        }
        
        
        
        
        if ( Input.GetKeyDown(KeyCode.Mouse0) && ketchupActive == true)
        {
            
            AnimateKetchup();
            burgerActive = false;
            mustardActive = false;
            shakeActive = false;
            Rigidbody ketchupCloneRB = Instantiate(ketchup, bulletSpawn.gameObject.transform.position, bulletSpawn.gameObject.transform.rotation);
            
            ketchupCloneRB.AddForce(Vector3.forward * fireSpeed);
            PlayerManager.instance.currentWeapon = PlayerManager.instance.ketchup;
            PlayerManager.instance.ketchup.SetActive(true);
            ketchupCount += 1;
            isKetchuping = true;
            isBurgering = false;
            isMustarding = false;
            isShaking = false;
            Debug.Log("Ketchup instantiated. Total ketchups: " + ketchupCount);
        }
        
        if (Input.GetKeyDown(KeyCode.Mouse0) && mustardActive == true)
        {
            
            AnimateMustard();
            burgerActive = false;
            ketchupActive = false;
            shakeActive = false;
            Rigidbody mustardCloneRB = Instantiate(mustard, bulletSpawn.gameObject.transform.position, bulletSpawn.gameObject.transform.rotation);
          
            mustardCloneRB.AddForce(Vector3.forward * fireSpeed);
            PlayerManager.instance.currentWeapon = PlayerManager.instance.mustard;
            PlayerManager.instance.mustard.SetActive(true);
            mustardCount += 1;
            isMustarding = true;
            isBurgering = false;
            isKetchuping = false;
            isShaking = false;
            Debug.Log("Mustard instantiated. Total mustards: " + mustardCount);
        }
      
        if (Input.GetKeyDown(KeyCode.Mouse1) && shakeActive == true)
        {
            
            AnimateShake();
            burgerActive = false;
            ketchupActive = false;
            mustardActive = false;
            Rigidbody shakeCloneRB =  Instantiate(shake, bulletSpawn.gameObject.transform.position, bulletSpawn.gameObject.transform.rotation);
      
            shakeCloneRB.AddForce(Vector3.forward * fireSpeed);
            PlayerManager.instance.currentWeapon = PlayerManager.instance.shake;
            PlayerManager.instance.shake.SetActive(true);
            shakeCount += 1;
            isShaking = true;
            isMustarding = false;
            isBurgering = false;
            isKetchuping = false;
            Debug.Log("Shake instantiated. Total shakes: " + shakeCount);
        }
       

    }

    public void DestroyFood()
    {

        if (burgerCount >= maxBurgerCount) if (PlayerManager.instance.burger.tag == "Burger") { Destroy(PlayerManager.instance.burger); }
        if (ketchupCount >= maxKetchupCount) if (PlayerManager.instance.ketchup.tag == "Ketchup") { Destroy(PlayerManager.instance.ketchup); }
        if (mustardCount >= maxMustardCount) if (PlayerManager.instance.mustard.tag == "Mustard") { Destroy(PlayerManager.instance.mustard); }
        if (shakeCount >= maxMustardCount) if (PlayerManager.instance.shake.tag == "Shake") { Destroy(PlayerManager.instance.shake); }
    }

    public void AnimateBurger()
    {
    weaponAnimator.SetBool("isBurgering", true);
    hasBurgered = true;
    Debug.Log("Burgering.");

        if (hasBurgered)
        {
            StopBurgering();
            isBurgering = false;
        }
    }
    
       
    
    public void StopBurgering()
    {
        if (hasBurgered)
        {
            weaponAnimator.SetBool("isBurgering", false);
            burgerMesh.gameObject.SetActive(false);
        }

        
        Debug.Log("Stopped burgering.");
        

       
    }
    public void AnimateKetchup()
    {
        weaponAnimator.SetBool("isKetchuping", true);
    }
    public void StopKetchuping()
    {
        weaponAnimator.SetBool("isKetchuping", false);
    }
    public void AnimateMustard()
    {
        weaponAnimator.SetBool("isMustarding", true);
    }
    public void StopMustarding()
    {
        weaponAnimator.SetBool("isMustarding", false);
    }
    public void AnimateShake()
    {
        weaponAnimator.SetBool("isShaking", true);
    }
    public void StopShaking()
    {
        weaponAnimator.SetBool("isShaking", false);
    }
        
    

    public void ResetWeapon()
    {
        //isBurgering = false;
        //isKetchuping = false;
        //isMustarding = false;
        //isShaking = false;
        StopBurgering();
        StopKetchuping();
        StopMustarding();
        StopShaking();
    }
}
