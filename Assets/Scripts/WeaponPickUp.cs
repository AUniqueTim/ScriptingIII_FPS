using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickUp : MonoBehaviour
{
    public bool weaponClicked;

    public enum FoodWeapon { Burger = 1, Ketchup = 2, Mustard = 3, Shake = 4, }

    FoodWeapon foodWeapon;

    //public void Update()
    //{
    //    if (foodWeapon == FoodWeapon.Burger)
    //    {
    //        Weapons.instance.burgerActive = true;
    //    }
    //    else if (foodWeapon == FoodWeapon.Ketchup)
    //    {
    //        Weapons.instance.ketchupActive = true;
    //    }
    //    else if (foodWeapon == FoodWeapon.Mustard)
    //    {
    //        Weapons.instance.mustardActive = true;
    //    }
    //    else if (foodWeapon == FoodWeapon.Shake)
    //    {
    //        Weapons.instance.shakeActive = true;
    //    }
    //}

    //Sorry I tried using enums but didn't quite get it, would love to go over it again.
    private void Awake()
    {
        if (gameObject.tag == "Burger")
        {
            foodWeapon = FoodWeapon.Burger;
        }
        else if (gameObject.tag == "Ketchup")
        {
            foodWeapon = FoodWeapon.Ketchup;
        }
        else if (gameObject.tag == "Mustard")
        {
            foodWeapon = FoodWeapon.Mustard;
        }
        else if (gameObject.tag == "Shake")
        {
            foodWeapon = FoodWeapon.Shake;
        }
    }
    public void OnMouseDown()
    {
        if(FoodWeapon.Burger == foodWeapon)
        {
            Weapons.instance.burgerActive = true;
        }
        else if (FoodWeapon.Ketchup == foodWeapon)
        {
            Weapons.instance.ketchupActive = true;
        }
        else if (FoodWeapon.Mustard == foodWeapon)
        {
            Weapons.instance.mustardActive = true;
        }
        else if(FoodWeapon.Shake == foodWeapon)
        {
            Weapons.instance.shakeActive = true;
        }

    }



}
