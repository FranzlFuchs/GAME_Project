using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeProjectile : Projectile
{
    public override void Fly()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    public override void OnHit(GameObject hittedObject)
    {
        Rigidbody otherRb = hittedObject.GetComponent<Rigidbody>();
        otherRb.constraints = RigidbodyConstraints.FreezeAll;
        //Hier freezen
        StartCoroutine(Countdown());

        otherRb.constraints = RigidbodyConstraints.None;


        Destroy(gameObject);
    }

    IEnumerator Countdown()
    {

        yield return new WaitForSeconds(3);

    }

    public override void Shoot(GameObject player)
    {
        //Projektil weiﬂ wer es geschossen hat, check auf friendly fire bei Ontrigger Enter
        GameObject newProjectile = Instantiate(gameObject, player.transform.position, player.transform.rotation);
        newProjectile.GetComponent<Projectile>().PlayerOrigin = player.GetComponent<PlayerConfig>().playerNumber;
    }
}
