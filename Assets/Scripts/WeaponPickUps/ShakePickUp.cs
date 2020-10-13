using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakePickUp : MonoBehaviour
{
    [SerializeField] public static bool shakeClicked;
    
    public void OnMouseDown()
    {
       shakeClicked = true;
    }


}
