using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickUp : MonoBehaviour
{
    [SerializeField] public static bool burgerClicked;
    
    public void OnMouseDown()
    {
       burgerClicked = true;
    }


}
