using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MustardPickUp : MonoBehaviour
{
    [SerializeField] public static bool mustardClicked;
    
    public void OnMouseDown()
    {
       mustardClicked = true;
        PlayerManager.instance.mustardAmmo = 10;
    }


}
