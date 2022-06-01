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
        otherRb.AddForce(gameObject.transform.forward * impulsStrength / 3, ForceMode.Impulse);
        Destroy(gameObject);
    }

    public override void Shoot(GameObject player)
    {
        charge = 3;

        //Projektil weiß wer es geschossen hat, check auf friendly fire bei Ontrigger Enter
        PlayerOrigin = player.GetComponent<PlayerConfig>().playerNumber;

        for (int i = 0; i < charge; charge++)
        {
            Instantiate(gameObject, player.transform.position, player.transform.rotation);
            player.GetComponent<PlayerShoot>().HasAmmo = false;
            player.GetComponent<PlayerShoot>().ammoMarker.SetActive(false);

        }
    }
}
