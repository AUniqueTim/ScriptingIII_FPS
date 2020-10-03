
using UnityEngine;

public class FiringScript : MonoBehaviour
{
    public Transform player;
    public GameObject ketchupFirePoint;
    private Vector3 currentWeaponDirection;
    public void Awake()
    {
            Vector3 currentWeaponDirection = PlayerManager.instance.currentWeapon.transform.position;

        
    }
    public void Update()
    {
        //transform.rotation = PlayerManager.instance.currentRotation;

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
           
        }
       
        Debug.DrawRay(transform.position, currentWeaponDirection, Color.green);
    }
    void Shoot()
    {
        RaycastHit ketchupHit;
        if (Physics.Raycast(ketchupFirePoint.transform.position, currentWeaponDirection, out ketchupHit, PlayerManager.instance.weaponRange))
        {
            Debug.Log(ketchupHit.transform.name);
            
        }
        Debug.DrawRay(transform.position, currentWeaponDirection, Color.red);
    }
}
