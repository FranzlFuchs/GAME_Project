using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MunitionSpawner : MonoBehaviour
{

    private float _spawnY;
    private float _spawnRangeXMax;
    private float _spawnRangeXMin;
    private float _spawnRangeZMin;
    private float _spawnRangeZMax;
    private float _spawnIntervalRange;
    private float _spawnOffset;
    public List<GameObject> Munition;
    public GameObject Dictionary;


    void Start()
    {
        _spawnRangeXMin = -14;
        _spawnRangeXMax = 10;
        _spawnRangeZMin = -30;
        _spawnRangeZMax = -10;
        _spawnOffset = 2;
        _spawnY = 3;

        Invoke("SpawnRandomMunition", _spawnOffset);


        Munition = Dictionary.GetComponent<MunitionDictionary>().MunitionList;
    }

    private Vector3 RandomSpawnPosition()
    {
        return new Vector3(Random.Range(_spawnRangeXMin, _spawnRangeXMax), _spawnY, Random.Range(_spawnRangeZMin, _spawnRangeZMax));
    }

    private void SpawnRandomMunition()
    {
        int ranPosMunition = Random.Range(0, Munition.Count);

        //RECURSION!
        if (GameManager.GameIsActive)
        {
            Munition[ranPosMunition].GetComponent<Munition>().Spawn(RandomSpawnPosition());
        }


        //Abbruchbedingung
        Invoke("SpawnRandomMunition", Random.Range(0, Munition[ranPosMunition].GetComponent<Munition>().SpawnIntervalNextMunition));
    }
}
