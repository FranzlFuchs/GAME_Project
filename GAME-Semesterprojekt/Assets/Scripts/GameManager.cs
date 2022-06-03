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
        PlayersAlive = GetComponent<PlayerSpawnPositions>().SpawnFixed();
        StartGame();
    }

    public void SpawnPlayersRandom()
    {
        PlayersAlive = GetComponent<PlayerSpawnPositions>().SpawnRandom();
        StartGame();
    }

    public void StartGame()
    {        
        StartGameFixedButton.gameObject.SetActive(false);
        StartGameRandomButton.gameObject.SetActive(false);
        RestartGameButton.gameObject.SetActive(true);
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
        Debug.Log("Player " + playerDead.GetComponent<PlayerConfig>().playerName + " died");
        Debug.Log("Players left :  " + PlayersAlive.Count);
        PlayersAlive.Remove(playerDead);

        if (PlayersAlive.Count == 1)
        {
            GameOver(PlayersAlive[0]);

            Debug.Log("GAME OVER, Player" + PlayersAlive[0].GetComponent<PlayerConfig>().playerName + "won!");
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
