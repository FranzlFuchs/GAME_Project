using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    public GameObject Projectile;
    public GameObject ammoMarker;
    public float impulsStrength;
    private Rigidbody playerRb;

    public bool HasAmmo;


    private string playerNumber
    {
        get
        {
            return GetComponent<PlayerConfig>().playerNumber;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        ammoMarker.SetActive(false);
        Projectile = null;
        HasAmmo = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire " + playerNumber))
        {
            Shoot();
        }

    }

    public void Shoot()
    {
        if (HasAmmo)
        {
            Projectile.GetComponent<Projectile>().Shoot(gameObject);
        }
    }

    public void Reload(GameObject munition)
    {

        if (!HasAmmo)
        {
            HasAmmo = true;
            gameObject.GetComponent<PlayerShoot>().Projectile = FindObjectOfType<MunitionDictionary>().ProjectilesDictionary[munition.GetComponent<Munition>().bulletType];

            SetAmmoMarkerColor(munition.GetComponent<Munition>().AmmoMarkerColor);

            ammoMarker.SetActive(true);
        }

        munition.GetComponent<Munition>().PickUp();
    }

    void OnTriggerEnter(Collider collider)
    {

        if (collider.gameObject.CompareTag("Munition"))
        {
            collider.gameObject.tag = "Untagged";
            Reload(collider.gameObject);
        }

    }

    void SetAmmoMarkerColor(Color color)
    {
        ammoMarker.gameObject.GetComponent<MeshRenderer>().material.color = color;
    }
}

