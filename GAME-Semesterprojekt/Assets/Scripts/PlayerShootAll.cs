using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootAll : MonoBehaviour
{
    public float shoot;
    public GameObject projectilePrefab;
    public GameObject ammoMarker;
    public float impulsStrength;
    public bool hasAmmunition;
    private Rigidbody playerRb;

    public string playerNumber;

    // Start is called before the first frame update
    void Start()
    {

        playerRb = GetComponent<Rigidbody>();
        hasAmmunition = false;
        ammoMarker.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        shoot = Input.GetAxis("Fire " + playerNumber);
        //verticalInput = shoot;
       


        Vector3 SpawnPosition = new Vector3(0, 0, 1);

        // Shoot placeholder
        if (shoot != 0)
        {
            Shoot();
        }

    }

    public void Shoot()
    {
        if (hasAmmunition)
        {
            Instantiate(projectilePrefab, transform.position, playerRb.rotation);
            ammoMarker.SetActive(false);
            hasAmmunition = false;
        }
    }
    public void Reload()
    {
        ammoMarker.SetActive(true);
        hasAmmunition = true;
    }



}

