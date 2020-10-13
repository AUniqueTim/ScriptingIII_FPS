using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerPickUp : MonoBehaviour
{
    [SerializeField] public static bool burgerClicked;
    public static BurgerPickUp instance;
    //START SINGLETON
    public static BurgerPickUp Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<BurgerPickUp>();
                if (instance == null)
                {
                    GameObject singleton = new GameObject();
                    singleton.AddComponent<BurgerPickUp>();
                    singleton.name = "(Singleton) BurgerPickUp";
                }
            }
            return instance;
        }
    }

    //END SINGLETON
    public void OnMouseDown()
    {
       burgerClicked = true;
    }
    public void Update()
    {
        if (burgerClicked) {instance.gameObject.SetActive(false); }
    }

}
