using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public ParticleSystem particleOnGo;
    public float verticalInput, rotationInput, viewY, viewX;
    // public float horizontalInput;
    public float speed = 10, rotationSpeed = 300;

    //public GameObject projectilePrefab;
    // public GameObject ammoMarker;
    //public float impulsStrength;
    //public bool hasAmmunition;
    private Rigidbody playerRb;
    private string playerOrigin;
    public Vector3 Vforward, Vright;

    private string playerNumber;

    // Start is called before the first frame update
    void Start()
    {
        Vforward = Vector3.forward;
        Vright = Vector3.right;

        playerRb = GetComponent<Rigidbody>();
        playerNumber = GetComponent<PlayerConfig>().playerNumber;

        //hasAmmunition = false;
        //ammoMarker.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.GameIsActive)
        {
            // Get inputs
            //horizontalInput = Input.GetAxis("Horizontal " + playerNumber);
            verticalInput = Input.GetAxis("Vertical " + playerNumber);
            viewX = Input.GetAxis("View X " + playerNumber);
            viewY = Input.GetAxis("View Y " + playerNumber);

            if(verticalInput > 0)
            {
                //particleOnGo.playbackSpeed = 0.2f;
                particleOnGo.Play();
            }
            if(verticalInput == 0)
            {
                //particleOnGo.Stop();
            }
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
        }
    }


 
}

