using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;
public abstract class Munition : MonoBehaviour, IMunition
{
    public BulletType bulletType;
    public float TimeToLive;    
    public float SpawnIntervalNextMunition;
    public Color AmmoMarkerColor;

    protected float _ratioTimeBlink = 0.6f;
    protected float _numBlinks = 5;

    private float _blinkInterval;
    private Renderer _renderer;
    void Start()
    {
       
        _blinkInterval = ((TimeToLive - (TimeToLive * _ratioTimeBlink)) / _numBlinks) / 2;
        _renderer = GetComponent<Renderer>();
        _renderer.enabled = true;
        StartCoroutine(DieAfterTime());
        StartCoroutine(Blink(_blinkInterval));
    }
    public abstract void Spawn(Vector3 spawnPosition);


    public abstract void PickUp();


    private IEnumerator DieAfterTime()
    {
        yield return new WaitForSeconds(TimeToLive);
        Destroy(gameObject);

    }

    public IEnumerator Blink(float seconds)
    {
        yield return new WaitForSeconds(_ratioTimeBlink * TimeToLive);

        while (true)
        {
            _renderer.enabled = !_renderer.enabled;
            yield return new WaitForSeconds(seconds);
        }

    }

    public float GetSpawnIntervalNextMunition()
    {
        return SpawnIntervalNextMunition;
    }
}
