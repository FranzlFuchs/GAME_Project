using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    public float speed = 10;
    public float rotationSpeed = 300;
    public float rotationInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);

        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * speed * verticalInput * Time.deltaTime);

        rotationInput = Input.GetAxis("Rotate");
        transform.Rotate(Vector3.up, rotationSpeed * rotationInput * Time.deltaTime, Space.World);
        
    }
}
