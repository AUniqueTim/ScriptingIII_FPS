﻿using System.Collections;
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
    }

   
    public void Update()
    {

       // DestroyFood();
        WeaponSelect();
        
    }
    public void FixedUpdate()
    {
        InstantiateFood();
        
    }
    public void LateUpdate()
    {
        StopBurgering();
        
        
        //if (hasBurgered && weaponAnimator.GetBool("isBurgering")==true) { StopBurgering(); }

        //if (hasBurgered)
        //{
        //    PlayerManager.instance.burgerHand.SetActive(false);
        //}
        //else if (!isBurgering)
        //{
        //    PlayerManager.instance.burgerHand.SetActive(true);
        //} 
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
        }
        else if (noWeaponSelected) { burgerActive = false; ketchupActive = false; mustardActive = false; shakeActive = false; }
    }
    public void InstantiateFood()
    {

        if (Input.GetKeyDown(KeyCode.Mouse1) && burgerActive == true)
        {
            
            AnimateBurger();
            ketchupActive = false;
            mustardActive = false;
            shakeActive = false;
            Rigidbody burgerCloneRB = Instantiate(burger, bulletSpawn.position, bulletSpawn.rotation);
            //burgerCloneRB.transform.Translate(Vector3.forward * fireSpeed, Space.World);
            burgerCloneRB.AddForce(Vector3.forward * fireSpeed);
            PlayerManager.instance.currentWeapon = PlayerManager.instance.burger;
            PlayerManager.instance.burger.SetActive(true);
            burgerCount += 1;
            isBurgering = true;
            isKetchuping = false;
            isMustarding = false;
            isShaking = false;
            
            Debug.Log("Burger instantiated. Total burgers: " + burgerCount);
            
        }
        //else if (!Input.GetKeyDown(KeyCode.Mouse1)) { isBurgering = false; }

        if ( Input.GetKeyDown(KeyCode.Mouse0) && ketchupActive == true)
        {
            
            AnimateKetchup();
            burgerActive = false;
            mustardActive = false;
            shakeActive = false;
            Rigidbody ketchupCloneRB = Instantiate(ketchup, bulletSpawn.position, bulletSpawn.rotation);
            //ketchupCloneRB.transform.Translate(Vector3.forward * fireSpeed, Space.World);
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
        //if (!Input.GetKey(KeyCode.Mouse0)) { isKetchuping = false; }

        if (Input.GetKeyDown(KeyCode.Mouse0) && mustardActive == true)
        {
            
            AnimateMustard();
            burgerActive = false;
            ketchupActive = false;
            shakeActive = false;
            Rigidbody mustardCloneRB = Instantiate(mustard, bulletSpawn.position, bulletSpawn.rotation);
           // mustardCloneRB.transform.Translate(Vector3.forward * fireSpeed, Space.World);
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
        //if (!Input.GetKey(KeyCode.Mouse0)) { isMustarding = false; }

        if (Input.GetKeyDown(KeyCode.Mouse1) && shakeActive == true)
        {
            
            AnimateShake();
            burgerActive = false;
            ketchupActive = false;
            mustardActive = false;
            Rigidbody shakeCloneRB =  Instantiate(shake, bulletSpawn.position, bulletSpawn.rotation);
            //shakeCloneRB.transform.Translate(Vector3.forward * fireSpeed, Space.World);
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
        //if (!Input.GetKey(KeyCode.Mouse0)) { isShaking = false; }

    }

    //public void DestroyFood()
    //{

    //    if (instance.burgerCount >= maxBurgerCount) if (PlayerManager.instance.burger.tag == "Burger") { Destroy(PlayerManager.instance.burger); }
    //    if (instance.ketchupCount >= maxKetchupCount) if (PlayerManager.instance.ketchup.tag == "Ketchup") { Destroy(PlayerManager.instance.ketchup); }
    //    if (instance.mustardCount >= maxMustardCount) if (PlayerManager.instance.mustard.tag == "Mustard") { Destroy(PlayerManager.instance.mustard); }
    //    if (instance.shakeCount >= maxMustardCount) if (PlayerManager.instance.shake.tag == "Shake") { Destroy(PlayerManager.instance.shake); }
    //}

    public void AnimateBurger()

    {
        if (burgerActive && Input.GetKeyDown(KeyCode.Mouse1))
        {
            weaponAnimator.SetBool("isBurgering", true);
            Debug.Log("Burgering.");
        }
        else if (!burgerActive)
        {
            StopBurgering();
        }
        

    }
    
       
    
    public void StopBurgering()
    {

        weaponAnimator.SetBool("isBurgering", false);
        Debug.Log("Stopped burgering");

       
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
