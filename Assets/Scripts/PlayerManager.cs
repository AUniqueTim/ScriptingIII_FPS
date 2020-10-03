using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject burger;
    public GameObject ketchup;
    public GameObject mustard;
    public GameObject shake;

    public GameObject burgerHand;
    public GameObject ketchupHand;
    public GameObject mustardHand;
    public GameObject shakeHand;

    public GameObject[] weapons;
    public GameObject currentWeapon;
    public float weaponDamage;
    public float weaponRange;
    public float health;
    public float lives;
    public float ammo;

    [SerializeField] public static float playerSpeed = 20f;
    [SerializeField] public static float runSpeed = 40f;
    [SerializeField] public static float crouchHeight = 5f;
    [SerializeField] public static float jumpHeight = 15f;
    [SerializeField] public float jumpSpeed = 3;
    [SerializeField] public float fallSpeed = 3;

    public Quaternion currentRotation;

   

    public static PlayerManager instance;
    public static PlayerManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<PlayerManager>();
                if (instance == null)
                {
                    GameObject singleton = new GameObject();
                    singleton.AddComponent<PlayerManager>();
                    singleton.name = "(Singleton) PlayerManager";
                }
            }
            return instance;
        }
    }
    private void Awake()
    {
        instance = this;
       
    }
    public void Update()
    {
        if (gameObject.tag == "Burger" && Weapons.instance.burgerCount >= Weapons.instance.maxBurgerCount) { Destroy(Weapons.instance.weaponsScript); }
        if (gameObject.tag == "Ketchup" && Weapons.instance.ketchupCount >= Weapons.instance.maxKetchupCount) { Destroy(Weapons.instance.weaponsScript); }
        if (gameObject.tag == "Mustard" && Weapons.instance.mustardCount >= Weapons.instance.maxMustardCount) { Destroy(Weapons.instance.weaponsScript); }
        if (gameObject.tag == "Shake" && Weapons.instance.shakeCount >= Weapons.instance.maxShakeCount) { Destroy(Weapons.instance.weaponsScript); }

        currentRotation = transform.rotation;
    }
}
