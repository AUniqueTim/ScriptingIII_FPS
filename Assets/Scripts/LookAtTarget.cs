using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTarget : MonoBehaviour
{
    public Transform target;
    public int speed;
    
    public void Update()
    {
        //transform.LookAt(target);
        
        transform.Translate(Vector3.forward * speed);
    }
}
