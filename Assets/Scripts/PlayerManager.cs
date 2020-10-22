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
    public int health;
    public int lives;
    public int ketchupAmmo;
    public int mustardAmmo;

    [SerializeField] public static float playerSpeed = 20f;
    [SerializeField] public static float runSpeed = 40f;
    [SerializeField] public static float crouchHeight = 5f;
    [SerializeField] public static float jumpHeight = 15f;
    [SerializeField] public float jumpSpeed = 3;
    [SerializeField] public float fallSpeed = 3;

    public Quaternion currentRotation;

     public int killCount;
     public int killThreshold;

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
        //ketchupAmmo = 100;
        //mustardAmmo = 100;

    }
    public void Update()
    {
        if (ketchupAmmo < 0) { ketchupAmmo = 0; }
        if (mustardAmmo < 0) { mustardAmmo = 0; }

        if (gameObject.tag == "Burger" && Weapons.instance.burgerCount >= Weapons.instance.maxBurgerCount) { Destroy(Weapons.instance.weaponsScript); }
        if (gameObject.tag == "Ketchup" && Weapons.instance.ketchupCount >= Weapons.instance.maxKetchupCount) { Destroy(Weapons.instance.weaponsScript); }
        if (gameObject.tag == "Mustard" && Weapons.instance.mustardCount >= Weapons.instance.maxMustardCount) { Destroy(Weapons.instance.weaponsScript); }
        if (gameObject.tag == "Shake" && Weapons.instance.shakeCount >= Weapons.instance.maxShakeCount) { Destroy(Weapons.instance.weaponsScript); }

        currentRotation = transform.rotation;

        if (health <= 0)
        {
            GameOver();
        }
    }
    public void GameOver()
    {
        Debug.Log("Game Over.");
        Destroy(gameObject);
    }
}
