
using UnityEngine;

public class FiringScript : MonoBehaviour
{
    public Transform player;
    public GameObject ketchupFirePoint;
    public GameObject mustardFirePoint;
    private Vector3 currentWeaponDirection;
    [SerializeField] private ParticleSystem ketchupSpray;
    [SerializeField] private ParticleSystem mustardSpray;
    public bool isFiring;
    private void Awake()
    {
        currentWeaponDirection = player.gameObject.transform.position;
    }
    public void Update()
    {
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
                ketchupSpray.gameObject.SetActive(true);
                //mustardSpray.Stop();
                ketchupSpray.Play();
                Debug.Log("Ketchup PE active.");
                
                RaycastHit ketchupHit;
                if (Physics.Raycast(ketchupFirePoint.transform.position,  ketchupFirePoint.transform.forward * PlayerManager.instance.weaponRange, out ketchupHit))
                {
                    Debug.Log(ketchupHit.transform.name);
                    Debug.DrawRay(ketchupFirePoint.transform.position, ketchupFirePoint.transform.forward * PlayerManager.instance.weaponRange, Color.red);
                    if (ketchupHit.collider.tag == "Enemy") { EnemyManager.instance.enemyHealth -= 1; }
                    ketchupHit.collider.GetComponent<MeshRenderer>().material.color = Color.red;
                }
                if (!PlayerManager.instance.ketchupHand.activeInHierarchy) { ketchupSpray.Stop(); ; Debug.Log("Ketchup PE Stopped."); }
            }
        }
        else if (PlayerManager.instance.currentWeapon = PlayerManager.instance.mustard)
        {
            if (isFiring)
            {
                mustardSpray.gameObject.SetActive(true);
                //ketchupSpray.Stop();
                mustardSpray.Play();
                Debug.Log("Mustard PE active.");
                RaycastHit mustardHit;
                if (Physics.Raycast(mustardFirePoint.transform.position, mustardFirePoint.transform.forward * PlayerManager.instance.weaponRange, out mustardHit))
                {
                    Debug.Log(mustardHit.transform.name);
                    //Debug.Log(mustardHit.point, mustardFirePoint);
                    Debug.DrawRay(mustardFirePoint.transform.position, mustardFirePoint.transform.forward * PlayerManager.instance.weaponRange, Color.yellow);
                    if (mustardHit.collider.tag == "Enemy") { EnemyManager.instance.enemyHealth -= 1; }
                    mustardHit.collider.GetComponent<MeshRenderer>().material.color = Color.yellow;


                }
                if (!PlayerManager.instance.mustardHand.activeInHierarchy) { mustardSpray.Stop(); Debug.Log("Mustard PE Stopped."); }
            }
        }
    }
}
