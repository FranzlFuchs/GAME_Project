using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MunitionSpawner : MonoBehaviour
{

    private float _spawnRangeXMax;
    private float _spawnRangeXMin;
    private float _spawnRangeZMin;
    private float _spawnRangeZMax;
    private float _spawnIntervalRange;
    private float _spawnOffset;

    public Munition[] Munition;

    void Start()
    {
        _spawnRangeXMin = -6;
        _spawnRangeXMax = 6;
        _spawnRangeZMin = -10;
        _spawnRangeZMax = 10;
        _spawnOffset = 2;

        Invoke("SpawnRandomMunition", _spawnOffset);
    }


    void Update()
    {

    }


    private Vector3 RandomSpawnPosition()
    {
        return new Vector3(Random.Range(_spawnRangeXMin, _spawnRangeXMax), 0, Random.Range(_spawnRangeZMin, _spawnRangeZMax));
    }

    private void SpawnRandomMunition()
    {

        int ranPosMunition = Random.Range(0, Munition.Length);
        if (GameManager.GameIsActive)
        {
            //RECURSION!
            Instantiate(Munition[ranPosMunition], RandomSpawnPosition(), Munition[ranPosMunition].transform.rotation);
        }

        //Abbruchbedingung
        if (true)
        {
            Invoke("SpawnRandomMunition", Random.Range(0, Munition[ranPosMunition].SpawnIntervalNextMunition));
        }
    }
}
