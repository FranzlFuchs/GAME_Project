using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    public AudioClip hitSound;
    public AudioClip shootSound;
    public AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void PlayHit()
    {
        source.PlayOneShot(hitSound, 0.5f);
    }
    // Update is called once per frame
    public void PlayShoot()
    {
        source.PlayOneShot(shootSound, 0.1f);
    }
}
