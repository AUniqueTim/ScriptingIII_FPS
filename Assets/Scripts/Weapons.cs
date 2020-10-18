using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Weapons : MonoBehaviour
{
    public static Weapons instance;

    [SerializeField] private int burgerFireSpeed;
    [SerializeField] private int shakeFireSpeed;

    //[SerializeField] private new readonly Camera camera;

    public Weapons weaponsScript;

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
    public bool hasKetchuped;
    public bool hasMustarded;
    public bool hasShaked;

    public Animator weaponAnimator;

    public MeshRenderer burgerMesh;
    public MeshRenderer ketchupMesh;
    public MeshRenderer mustardMesh;
    public MeshRenderer shakeMesh;

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
        burgerMesh = handBurger.GetComponent<MeshRenderer>();
        ketchupMesh = handKetchup.GetComponent<MeshRenderer>();
        mustardMesh = handMustard.GetComponent<MeshRenderer>();
        shakeMesh = handShake.GetComponent<MeshRenderer>();
        spawningAllowed = true;
    }

   
    public void Update()
    {

        DestroyFood();
        WeaponSelect();
        InstantiateFood();


    }
    public void FixedUpdate()
    {


    }

    public void WeaponSelect()
    {
        if (Input.GetKey(KeyCode.Alpha1) || BurgerPickUp.burgerClicked)
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
        else if (Input.GetKey(KeyCode.Alpha2) || KetchupPickUp.ketchupClicked && PlayerManager.instance.ketchupAmmo > 0)
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
        else if (Input.GetKey(KeyCode.Alpha3) || MustardPickUp.mustardClicked && PlayerManager.instance.mustardAmmo > 0)
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
        else if (Input.GetKey(KeyCode.Alpha4) || ShakePickUp.shakeClicked)
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
            //burgerCloneRB.transform.Translate(bulletSpawn.transform.position * burgerFireSpeed,Space.Self);
            //burgerCloneRB.MoveRotation(bulletSpawn.transform.rotation);
            burgerCloneRB.AddForce(bulletSpawn.transform.forward * burgerFireSpeed);
            PlayerManager.instance.currentWeapon = PlayerManager.instance.burgerHand;
            PlayerManager.instance.burger.SetActive(true);
            burgerCount += 1;
            isBurgering = true;
            isKetchuping = false;
            isMustarding = false;
            isShaking = false;
            BurgerPickUp.burgerClicked = false;
            Debug.Log("Burger instantiated. Total burgers: " + burgerCount);
            hasBurgered = true;
            


            if (burgerActive && isBurgering)
            {
                AnimateBurger();
            }
            else if (!burgerActive)
            {
                StopBurgering();
            }

        }
        
        
        
        
        if ( Input.GetKeyDown(KeyCode.Mouse0) && ketchupActive == true)
        {
            
            //AnimateKetchup();
            burgerActive = false;
            mustardActive = false;
            shakeActive = false;
            //Rigidbody ketchupCloneRB = Instantiate(ketchup, bulletSpawn.gameObject.transform.position, bulletSpawn.gameObject.transform.rotation);
            
            //ketchupCloneRB.AddForce(Vector3.forward * fireSpeed);
            PlayerManager.instance.currentWeapon = PlayerManager.instance.ketchup;
            PlayerManager.instance.ketchup.SetActive(true);
            //ketchupCount += 1;
            isKetchuping = true;
            isBurgering = false;
            isMustarding = false;
            isShaking = false;
            KetchupPickUp.ketchupClicked = false;
            Debug.Log("Ketchup instantiated. Total ketchups: " + ketchupCount);
            PlayerManager.instance.ketchupAmmo--;
            hasKetchuped = true;

            if (ketchupActive && isKetchuping)
            {
                AnimateKetchup();
                ketchupCount++;
            }
            else if (!ketchupActive)
            {
                StopKetchuping();
            }
        }
        
        if (Input.GetKeyDown(KeyCode.Mouse0) && mustardActive == true)
        {
            
            //AnimateMustard();
            burgerActive = false;
            ketchupActive = false;
            shakeActive = false;
            //Rigidbody mustardCloneRB = Instantiate(mustard, bulletSpawn.gameObject.transform.position, bulletSpawn.gameObject.transform.rotation);
          
            //mustardCloneRB.AddForce(Vector3.forward * fireSpeed);
            PlayerManager.instance.currentWeapon = PlayerManager.instance.mustard;
            PlayerManager.instance.mustard.SetActive(true);
            //mustardCount += 1;
            isMustarding = true;
            isBurgering = false;
            isKetchuping = false;
            isShaking = false;
            MustardPickUp.mustardClicked = false;
            Debug.Log("Mustard instantiated. Total mustards: " + mustardCount);
            PlayerManager.instance.mustardAmmo--;
            hasMustarded = true;


            if (mustardActive && isMustarding)
            {
                AnimateMustard();
            }
            else if (!mustardActive)
            {
                StopMustarding();
            }
        }
      
        if (Input.GetKeyDown(KeyCode.Mouse1) && shakeActive == true)
        {
            
            //AnimateShake();
            burgerActive = false;
            ketchupActive = false;
            mustardActive = false;
            Rigidbody shakeCloneRB =  Instantiate(shake, bulletSpawn.gameObject.transform.position, bulletSpawn.gameObject.transform.rotation);
      
            shakeCloneRB.AddForce(bulletSpawn.transform.forward * shakeFireSpeed);
            PlayerManager.instance.currentWeapon = PlayerManager.instance.shake;
            PlayerManager.instance.shake.SetActive(true);
            shakeCount += 1;
            isShaking = true;
            isMustarding = false;
            isBurgering = false;
            isKetchuping = false;
            ShakePickUp.shakeClicked = false;
            Debug.Log("Shake instantiated. Total shakes: " + shakeCount);
            hasShaked = true;

            if (shakeActive && isShaking)
            {
                AnimateShake();
            }
            else if (!shakeActive)
            {
                StopShaking();
            }
        }
       

    }

    public void DestroyFood()
    {

        if (burgerCount >= maxBurgerCount) if (PlayerManager.instance.burger.tag == "Burger") { Destroy(PlayerManager.instance.burger.gameObject); }
        if (ketchupCount >= maxKetchupCount) if (PlayerManager.instance.ketchup.tag == "Ketchup") { Destroy(PlayerManager.instance.ketchup.gameObject); }
        if (mustardCount >= maxMustardCount) if (PlayerManager.instance.mustard.tag == "Mustard") { Destroy(PlayerManager.instance.mustard.gameObject); }
        if (shakeCount >= maxShakeCount) if (PlayerManager.instance.shake.tag == "Shake") { Destroy(PlayerManager.instance.shake.gameObject); }
    }

    public void AnimateBurger()
    {
    //weaponAnimator.SetBool("isBurgering", true);
    //hasBurgered = true;
    burgerMesh.gameObject.SetActive(true);
    Debug.Log("Burgering.");
    StopBurgering();
    isBurgering = false;
       
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
    //hasKetchuped = true;
    Debug.Log("Ketchuping.");
        if (hasKetchuped)
        {
            StopKetchuping();
            isKetchuping = false;
        }
    }
    public void StopKetchuping()
    {
        if (hasKetchuped && PlayerManager.instance.ketchupAmmo <= 0)
        {
            weaponAnimator.SetBool("isKetchuping", false);
            ketchupMesh.gameObject.SetActive(false);
        }
        Debug.Log("Stopped ketchuping.");
    }
    public void AnimateMustard()
    {
    weaponAnimator.SetBool("isMustarding", true);
    //hasMustarded = true;
    Debug.Log("Mustarding.");
        if (hasMustarded)
        {
            StopMustarding();
            isMustarding = false;
        }
    }
    public void StopMustarding()
    {
        if (hasMustarded && PlayerManager.instance.mustardAmmo <= 0)
        {
            weaponAnimator.SetBool("isMustarding", false);
            mustardMesh.gameObject.SetActive(false);
        }
        Debug.Log("Stopped mustarding.");
    }
    public void AnimateShake()
    {
    weaponAnimator.SetBool("isShaking", true);
    //hasShaked = true;
    Debug.Log("Shaking.");
        if (hasShaked)
        {
            StopShaking();
            isShaking = false;
        }
    }
    public void StopShaking()
    {
        if (hasShaked)
        {
            weaponAnimator.SetBool("isShaking", false);
            shakeMesh.gameObject.SetActive(false);
        }
        Debug.Log("Stopped shaking.");
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
