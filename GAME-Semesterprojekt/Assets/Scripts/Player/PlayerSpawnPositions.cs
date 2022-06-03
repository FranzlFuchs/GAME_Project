using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnPositions : MonoBehaviour
{
    List<int> possibleNumbers = new List<int>() { 1, 2, 3, 4 };
    List<GameObject> playingPlayers;
    public int numberPlayers;
    public GameObject[] Tanks;
    public Vector3[] Pos = new Vector3[]{
        new Vector3(7.2f, 3.5f, -30),
        new Vector3(-12.53f, 3.5f, -30),
        new Vector3(7.2f, 3.5f, -10),
        new Vector3(-12.53f, 3.5f, -10)
    };
    void Start()
    {
        playingPlayers = new List<GameObject>();
    }



    public List<GameObject> SpawnRandom()
    {

        for (int i = 0; i < numberPlayers; i++)
        {


            int randomPlayerNumber = possibleNumbers[Random.Range(0, possibleNumbers.Count)];
            possibleNumbers.Remove(randomPlayerNumber);
            Tanks[i].GetComponent<PlayerConfig>().playerNumber = (randomPlayerNumber).ToString();
            GameObject newPlayer = Instantiate(Tanks[i], Pos[randomPlayerNumber - 1], Tanks[i].transform.rotation);
            playingPlayers.Add(newPlayer);
        }

        return playingPlayers;

    }


    public List<GameObject> SpawnFixed()
    {
        for (int i = 0; i < numberPlayers; i++)
        {
            Tanks[i].GetComponent<PlayerConfig>().playerNumber = (i + 1).ToString();

            GameObject newPlayer = Instantiate(Tanks[i], Pos[i], Tanks[i].transform.rotation);
            playingPlayers.Add(newPlayer);
        }

        return playingPlayers;
    }
}
