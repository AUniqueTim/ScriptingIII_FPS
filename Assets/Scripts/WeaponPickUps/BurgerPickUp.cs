using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerPickUp : MonoBehaviour
{
    [SerializeField] public static bool burgerClicked;
    public static BurgerPickUp instance;
    //START SINGLETON

    public void Awake()
    {
        instance = this;
    }
    //public static BurgerPickUp Instance
    //{
    //    get
    //    {
    //        if (instance == null)
    //        {
    //            instance = GameObject.FindObjectOfType<BurgerPickUp>();
    //            if (instance == null)
    //            {
    //                GameObject singleton = new GameObject();
    //                singleton.AddComponent<BurgerPickUp>();
    //                singleton.name = "(Singleton) BurgerPickUp";
    //            }
    //        }
    //        return instance;
    //    }
    //}

    //END SINGLETON
    public void OnMouseDown()
    {
       //Weapons.instance.burgerActive = true;
       burgerClicked = true;
        
       
    }
    public void OnMouseUp()
    {
        instance.gameObject.SetActive(false);
        burgerClicked = false;
    }
    public void Update()
    {
        //if (Weapons.instance.burgerActive) { Weapons.instance.burger.gameObject.SetActive(false); }
    }

}
