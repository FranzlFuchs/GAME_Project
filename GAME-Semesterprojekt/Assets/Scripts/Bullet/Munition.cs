using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;
public class Munition : MonoBehaviour, IMunition
{
    public BulletType bulletType;
    private float _ratioTimeBlink = 0.6f;
    private float _blinkInterval;
    private float _numBlinks = 5;
    private Renderer _renderer;
    public float TimeToLive;
    public float SpawnIntervalNextMunition;

    void Start()
    {
        _blinkInterval = ((TimeToLive - (TimeToLive * _ratioTimeBlink)) / _numBlinks) / 2;
        _renderer = GetComponent<Renderer>();
        StartCoroutine(DieAfterTime());
        StartCoroutine(Blink(_blinkInterval));
    }
    public void Spawn(Vector3 spawnPosition)
    {
        GameObject newMunition = Instantiate(gameObject, spawnPosition, gameObject.transform.rotation);
        newMunition.gameObject.AddComponent<SpinAroundSelf>();
    }


    public void PickUp()
    {
        Destroy(gameObject);
    }


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
