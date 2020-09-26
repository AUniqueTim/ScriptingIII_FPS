using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject burger;
    public GameObject ketchup;
    public GameObject mustard;
    public GameObject shake;

    public GameObject[] weapons;
    public GameObject currentWeapon;
    public float weaponDamage;
    public float health;
    public float lives;
    public float ammo;

    [SerializeField] public static float playerSpeed = 20f;
    [SerializeField] public static float crouchHeight = 5f;
    [SerializeField] public static float jumpHeight = 15f;
    [SerializeField] public static int fallSpeed = 3;



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
    }
}
