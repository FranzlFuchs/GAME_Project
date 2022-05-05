using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerAll : MonoBehaviour
{
    public float horizontalInput, verticalInput, rotationInput, viewY, viewX;
    //public float shoot;
    public float speed = 10, rotationSpeed = 300;

    //public GameObject projectilePrefab;
    // public GameObject ammoMarker;
    //public float impulsStrength;
    //public bool hasAmmunition;
    private Rigidbody playerRb;
    public Vector3 Vforward, Vright;

    public string playerNumber;

    // Start is called before the first frame update
    void Start()
    {
        Vforward = Vector3.forward;
        Vright = Vector3.right;

        playerRb = GetComponent<Rigidbody>();
        //hasAmmunition = false;
        //ammoMarker.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {


        // convert from world space to local
        // so that player always moves up, when steering up, independent of player rotation
        //Vforward = transform.InverseTransformVector(Vector3.forward);
        // Vright = transform.InverseTransformVector(Vector3.right);



        // Get inputs
        horizontalInput = Input.GetAxis("Horizontal " + playerNumber);
        verticalInput = Input.GetAxis("Vertical " + playerNumber);
        viewX = Input.GetAxis("View X " + playerNumber);
        viewY = Input.GetAxis("View Y " + playerNumber);
        //shoot = Input.GetAxis("Fire " + playerNumber);
        //verticalInput = shoot;

        // change player position
        //transform.Translate(Vright * speed * horizontalInput * Time.deltaTime);
        transform.Translate(Vforward * speed * verticalInput * Time.deltaTime);

        // old rotate
        // transform.Rotate(Vector3.up, rotationSpeed * rotationInput * Time.deltaTime, Space.World); 
        // new rotate
        if (viewX != 0 || viewY != 0)
        {
            transform.forward = new Vector3(viewX, 0, viewY);
        }

        Vector3 SpawnPosition = new Vector3(0, 0, 1);

        // Shoot placeholder
        //if (shoot != 0)
        {
            //Shoot();
        }

    }

    /* public void Shoot()
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

 */

}

