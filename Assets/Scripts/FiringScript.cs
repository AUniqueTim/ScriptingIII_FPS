
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
    [SerializeField] private Camera camera;
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
                //Ray ketchupRay = new Ray(ketchupFirePoint.transform.position.normalized, ketchupFirePoint.transform.position);
                RaycastHit ketchupHit;
                if (Physics.Raycast(camera.transform.position,  camera.transform.position, out ketchupHit))
                {
                    Debug.Log(ketchupHit.transform.name);
                    Debug.DrawRay(camera.transform.position,  camera.transform.position, Color.red);
                    if (ketchupHit.collider.tag == "Enemy") { EnemyManager.instance.enemyHealth -= 1; }
                    ketchupHit.collider.GetComponent<MeshRenderer>().material.color = Color.red;
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

                //Ray mustardRay = new Ray(mustardFirePoint.transform.position, camera.transform.position);
                RaycastHit mustardHit;
                if (Physics.Raycast(camera.transform.position, camera.transform.position, out mustardHit))
                {
                    Debug.Log(mustardHit.transform.name);
                    //Debug.Log(mustardHit.point, mustardFirePoint);
                    Debug.DrawRay(camera.transform.position, camera.transform.position, Color.yellow);
                    //Debug.DrawLine(mustardFirePoint.transform.position, -mustardFirePoint.transform.position, Color.yellow);
                    if (mustardHit.collider.tag == "Enemy") { EnemyManager.instance.enemyHealth -= 1; }
                    mustardHit.collider.GetComponent<MeshRenderer>().material.color = Color.yellow;


                }
                if (!PlayerManager.instance.mustardHand.activeInHierarchy) { mustardSpray.Stop(); Debug.Log("Mustard PE Stopped."); }
            }
        }
        
        
    }
}
