using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTarget : MonoBehaviour
{
    public Transform target;
    public int speed;
    public int i;
    public void Update()
    {
        //transform.LookAt(target);
        //for (int i = 0; i >= 0; i++);
        transform.Translate(Vector3.forward * speed);
    }
}
