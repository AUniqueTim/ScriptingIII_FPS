
using UnityEngine;

public class FiringScript : MonoBehaviour
{
    public Transform player;
    public GameObject ketchupFirePoint;
    public GameObject mustardFirePoint;
    //public Transform weaponDirection;
    private Vector3 currentWeaponDirection;
    [SerializeField] private ParticleSystem ketchupSpray;
    [SerializeField] private ParticleSystem mustardSpray;
    public void Awake()
    {
        //Vector3 currentWeaponDirection = PlayerManager.instance.currentWeapon.transform.position;
        


    }
    public void Update()
    {
        //transform.rotation = PlayerManager.instance.currentRotation;
        
        if (Input.GetButton("Fire1"))
        {
            Shoot();
           
        }
       
        Debug.DrawRay(transform.position, currentWeaponDirection, Color.green);
    }
    public void Shoot()
    {
        if (PlayerManager.instance.currentWeapon = PlayerManager.instance.ketchup)
        {
            Vector3 currentWeaponDirection = ketchupFirePoint.transform.position;
            //Quaternion currentWeaponRotation = ketchupFirePoint.transform.rotation;

            RaycastHit ketchupHit;
            if (Physics.Raycast(ketchupFirePoint.transform.position, currentWeaponDirection, out ketchupHit, PlayerManager.instance.weaponRange))
            {
                Debug.Log(ketchupHit.transform.name);
                Debug.DrawRay(transform.position, currentWeaponDirection, Color.red);
                ketchupSpray.gameObject.SetActive(true);
                //mustardSpray.Stop();
                ketchupSpray.Play();
                Debug.Log("Ketchup PE active.");

            }
            
        }
        if (PlayerManager.instance.currentWeapon = PlayerManager.instance.mustard)
        {
            Vector3 currentWeaponDirection = mustardFirePoint.transform.position;
            //Quaternion currentWeaponRotation = mustardFirePoint.transform.rotation;

            RaycastHit mustardHit;
            if (Physics.Raycast(mustardFirePoint.transform.position, currentWeaponDirection, out mustardHit, PlayerManager.instance.weaponRange))
            {
                Debug.Log(mustardHit.transform.name);
                Debug.DrawRay(transform.position, currentWeaponDirection, Color.yellow);
                mustardSpray.gameObject.SetActive(true);
                //ketchupSpray.Stop();
                mustardSpray.Play();
                Debug.Log("Mustard PE active.");
            }
            
        }
        if (!PlayerManager.instance.mustardHand.activeInHierarchy) { mustardSpray.Stop(); Debug.Log("Mustard PE Stopped"); }
        else if (!PlayerManager.instance.ketchupHand.activeInHierarchy) { ketchupSpray.Stop(); Debug.Log("Ketchup PE Stopped"); }
    }
}
