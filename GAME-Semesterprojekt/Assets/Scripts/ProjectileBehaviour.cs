using System.Collections;
using System.Collections.Generic;
//using PlayerShootBe
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed = 40;
    public GameObject player;
    public PlayerShoot script;

    public float impulsStrength;

    void Start()
    {
        script = GetComponent<PlayerShoot>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {           
            Rigidbody otherRb = other.GetComponent<Rigidbody>();

            otherRb.AddForce(gameObject.transform.forward * impulsStrength, ForceMode.Impulse);  

            Debug.Log(gameObject.transform.forward);

            Destroy(gameObject);
        }

    }

    

}
