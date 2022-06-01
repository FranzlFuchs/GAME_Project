using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float speed = 40;
    public float impulsStrength;
    public string PlayerOrigin;


    public void Shoot(GameObject player)
    {
        PlayerOrigin = player.GetComponent<PlayerConfig>().playerNumber;
        Instantiate(gameObject, player.transform.position, player.transform.rotation);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }



    public void OnHit(GameObject hittedObject)
    {
        Rigidbody otherRb = hittedObject.GetComponent<Rigidbody>();
        otherRb.AddForce(gameObject.transform.forward * impulsStrength, ForceMode.Impulse);

        Debug.Log("Hit");
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (PlayerOrigin != other.gameObject.GetComponent<PlayerConfig>().playerNumber)
            {
                OnHit(other.gameObject);
            }
        }

        if (other.CompareTag("TableWare"))
        {

            OnHit(other.gameObject);

        }
    }
}
