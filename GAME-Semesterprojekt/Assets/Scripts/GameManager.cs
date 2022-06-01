using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour

{
    public static bool GameIsActive;
    public Button StartGameRandomButton;
    public Button StartGameFixedButton;
    public Button RestartGameButton;
    public PlayerSpawnPositions PlayerSpawner;
    public TextMeshProUGUI winnerText;
    public TextMeshProUGUI StartgameText;
    public List<GameObject> Players;
    private List<GameObject> PlayersAlive;

    public void SpawnPlayersFixed()
    {
        GetComponent<PlayerSpawnPositions>().SpawnFixed();
        StartGame();
    }

    public void SpawnPlayersRandom()
    {
        GetComponent<PlayerSpawnPositions>().SpawnRandom();
        StartGame();
    }

    public void StartGame()
    {
        PlayersAlive = Players;
        StartGameFixedButton.gameObject.SetActive(false);
        StartGameRandomButton.gameObject.SetActive(false);
        RestartGameButton.gameObject.SetActive(false);
        winnerText.gameObject.SetActive(false);
        StartgameText.gameObject.SetActive(false);
        GameIsActive = true;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void PlayerDied(GameObject playerDead)
    {        
        PlayersAlive.Remove(playerDead);

        if (PlayersAlive.Count == 1)
        {
            GameOver(PlayersAlive[0]);
        }
    }

    public void GameOver(GameObject winner)
    {
        GameIsActive = false;

        winnerText.text = winner.GetComponent<PlayerConfig>().playerName + " won!";
        RestartGameButton.gameObject.SetActive(true);
        winnerText.gameObject.SetActive(true);
    }
}
