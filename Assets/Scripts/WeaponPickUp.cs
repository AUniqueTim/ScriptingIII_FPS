using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickUp : MonoBehaviour
{
    public bool weaponClicked;

    [SerializeField] private enum FoodWeapon { Burger, Ketchup, Mustard, Shake, }

    FoodWeapon foodWeapon;

    public void Awake()
    {
       
        foodWeapon = FoodWeapon.Burger;
    }
    

    //Sorry I tried using enums but didn't quite get it, would love to go over it again.

    public void OnMouseDown()
    {
        if(FoodWeapon.Burger == foodWeapon)
        {
            PlayerManager.instance.burgerHand.gameObject.SetActive(true);
        }
    
    }



}
