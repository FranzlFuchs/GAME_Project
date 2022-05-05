using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Munition : MonoBehaviour
{
    // Start is called before the first frame update

    //Time until 
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

    // Update is called once per frame
    void Update()
    {

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

    void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerShootAll>().Reload();
            Destroy(gameObject);
        }
    }
}
