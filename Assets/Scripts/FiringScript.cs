
using UnityEngine;

public class FiringScript : MonoBehaviour
{
    public Transform player;
    public GameObject ketchupFirePoint;
    private void Update()
    {
        transform.rotation = PlayerManager.instance.currentRotation;

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
           
        }
       
        Debug.DrawRay(ketchupFirePoint.transform.position, Vector3.forward * PlayerManager.instance.weaponRange, Color.red);
    }
    void Shoot()
    {
        RaycastHit ketchupHit;
        if (Physics.Raycast(ketchupFirePoint.transform.position, Vector3.forward * PlayerManager.instance.weaponRange, out ketchupHit, PlayerManager.instance.weaponRange))
        {
            Debug.Log(ketchupHit.transform.name);
            
        }
    }
}
