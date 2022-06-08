using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeProjectile : Projectile
{

    private float freezeCountdown;
    private GameObject frozenObject;

    void Start()
    {
        freezeCountdown = 1.0f;
    }

    public override void Fly()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    public override void OnHit(GameObject hittedObject)
    {
        if (hittedObject.CompareTag("Player"))
        {
            frozenObject = hittedObject;
            hittedObject.GetComponent<PlayerController>().Freeze(freezeCountdown);
            Destroy(gameObject);
        }
    }


    public override void Shoot(GameObject player)
    {
        //Projektil wei� wer es geschossen hat, check auf friendly fire bei Ontrigger Enter
        GameObject newProjectile = Instantiate(gameObject, player.transform.position, player.transform.rotation);
        newProjectile.GetComponent<Projectile>().PlayerOrigin = player.GetComponent<PlayerConfig>().playerNumber;
    }
}
