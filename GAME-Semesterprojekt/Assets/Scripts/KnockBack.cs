using System.Collections;
using System.Collections.Generic;
//using PlayerShootBe
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    // Start is called before the first frame update





    private float impulsStrength = 2500;



    private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            Rigidbody otherRb = other.gameObject.GetComponent<Rigidbody>();

            Vector3 direction = (transform.position - other.transform.position).normalized;

            otherRb.AddForce(direction * impulsStrength, ForceMode.Impulse);

        }
    }
}
