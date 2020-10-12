
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

    public bool isFiring;
    public void Awake()
    {
        //Vector3 currentWeaponDirection = PlayerManager.instance.currentWeapon.transform.position;
        


    }
    public void Update()
    {
        //transform.rotation = PlayerManager.instance.currentRotation;
        
        if (Input.GetButton("Fire1"))
        {
            isFiring = true;
            Shoot();
        }
        else if (!Input.GetButton("Fire1"))
        {
            isFiring = false;
            ketchupSpray.gameObject.SetActive(false);
            mustardSpray.gameObject.SetActive(false);
        }
      
       
        Debug.DrawRay(transform.position, currentWeaponDirection, Color.green);
    }
    public void Shoot()
    {
        
        if (PlayerManager.instance.currentWeapon = PlayerManager.instance.ketchup)
        {
            if (isFiring)
            {
                //Vector3 currentWeaponDirection = ketchupFirePoint.transform.position;
                //Quaternion currentWeaponRotation = ketchupFirePoint.transform.rotation;

                ketchupSpray.gameObject.SetActive(true);
                //mustardSpray.Stop();
                ketchupSpray.Play();
                Debug.Log("Ketchup PE active.");

                RaycastHit ketchupHit;
                if (Physics.Raycast(ketchupFirePoint.transform.position, ketchupFirePoint.transform.position, out ketchupHit, PlayerManager.instance.weaponRange))
                {
                    Debug.Log(ketchupHit.transform.name);
                    Debug.DrawRay(ketchupFirePoint.transform.position, ketchupFirePoint.transform.position, Color.red);
                    if (ketchupHit.collider.tag == "Enemy") { EnemyManager.instance.enemyHealth -= 1; }
                }
                if (!PlayerManager.instance.ketchupHand.activeInHierarchy) { ketchupSpray.Stop(); ; Debug.Log("Ketchup PE Stopped."); }
            }
        }
        if (PlayerManager.instance.currentWeapon = PlayerManager.instance.mustard)
        {
            if (isFiring)
            {
                //Vector3 currentWeaponDirection = mustardFirePoint.transform.position;
                //Quaternion currentWeaponRotation = mustardFirePoint.transform.rotation;

                mustardSpray.gameObject.SetActive(true);
                //ketchupSpray.Stop();
                mustardSpray.Play();
                Debug.Log("Mustard PE active.");

                Ray mustardRay = new Ray(mustardFirePoint.transform.position, Vector3.forward);
                RaycastHit mustardHit;
                if (Physics.Raycast(mustardFirePoint.transform.position, mustardFirePoint.transform.position, out mustardHit, PlayerManager.instance.weaponRange, 0,0))
                {
                    Debug.Log(mustardHit.transform.name);
                    Debug.Log(mustardHit.point, mustardFirePoint);
                    Debug.DrawRay(mustardFirePoint.transform.position, mustardFirePoint.transform.position, Color.yellow);
                    //Debug.DrawLine(mustardFirePoint.transform.position, -mustardFirePoint.transform.position, Color.yellow);
                    if (mustardHit.collider.tag == "Enemy") { EnemyManager.instance.enemyHealth -= 1; }
                    
                }
                if (!PlayerManager.instance.mustardHand.activeInHierarchy) { mustardSpray.Stop(); Debug.Log("Mustard PE Stopped."); }
            }
        }
        
        
    }
}
