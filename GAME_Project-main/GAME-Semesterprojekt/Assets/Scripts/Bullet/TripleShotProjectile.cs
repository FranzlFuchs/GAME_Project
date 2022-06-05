using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleShotProjectile : Projectile
{    
    
    public override void Fly()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    public override void OnHit(GameObject hittedObject)
    {
        Rigidbody otherRb = hittedObject.GetComponent<Rigidbody>();
        otherRb.AddForce(gameObject.transform.forward * impulsStrength, ForceMode.Impulse);
        Destroy(gameObject);
    }

    public override void Shoot(GameObject player)
    {
        //Projektil weiß wer es geschossen hat, check auf friendly fire bei Ontrigger Enter
        PlayerOrigin = player.GetComponent<PlayerConfig>().playerNumber;
        Instantiate(gameObject, player.transform.position, player.transform.rotation);
    }
}
