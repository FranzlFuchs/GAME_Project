using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public float shoot;
    public GameObject projectilePrefab;
    public GameObject ammoMarker;
    public float impulsStrength;
    public bool hasAmmunition;
    private Rigidbody playerRb;

    private string playerNumber;

    // Start is called before the first frame update
    void Start()
    {

        playerRb = GetComponent<Rigidbody>();
        hasAmmunition = false;
        ammoMarker.SetActive(false);
        playerNumber = GetComponent<PlayerConfig>().playerNumber;

    }

    // Update is called once per frame
    void Update()
    {
        //shoot = Input.GetButtonDown("Fire " + playerNumber);        

        //Vector3 SpawnPosition = new Vector3(0, 0, 1);

        // Shoot placeholder

        if (Input.GetButtonDown("Fire " + playerNumber))
        {
            //Debug.Log("SHOOT" + playerNumber);
            Shoot();
        }


    }

    public void Shoot()
    {
        projectilePrefab.GetComponent<ProjectileBehaviour>().playerOrigin = playerNumber;

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

