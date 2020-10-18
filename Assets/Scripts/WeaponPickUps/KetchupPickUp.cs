using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KetchupPickUp : MonoBehaviour
{
    [SerializeField] public static bool ketchupClicked;
    
    public void OnMouseDown()
    {
       ketchupClicked = true;
       PlayerManager.instance.ketchupAmmo = Random.Range(4,7);
    }


}
