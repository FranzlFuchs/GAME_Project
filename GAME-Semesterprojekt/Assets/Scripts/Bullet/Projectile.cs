using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour, IProjectile
{

    public float speed;
    public float impulsStrength;
    public string PlayerOrigin;
    public int Charge;



    public abstract void Shoot(GameObject player);
    public abstract void Fly();
    public abstract void OnHit(GameObject hittedObject);

   
    void Update()
    {
        Fly();
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            if (PlayerOrigin != other.gameObject.GetComponent<PlayerConfig>().playerNumber)
            {
                
                other.gameObject.GetComponent<PlayerController>().onHitParticles.Play();
                other.gameObject.GetComponent<SoundEffects>().PlayHit();
                other.gameObject.GetComponent<PlayerController>().onHitParticles.transform.position = gameObject.transform.position;
                OnHit(other.gameObject);
            }
        }

        if (other.CompareTag("TableWare"))
        {
            other.gameObject.GetComponent<SoundEffects>().PlayHit();
            OnHit(other.gameObject);

        }
    }
}
