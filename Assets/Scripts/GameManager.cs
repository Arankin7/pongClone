using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public bool isGameActive;

    public Button startButton;
    public Button restartButton;
    public Button continueButton;

    public GameObject pongBall;

    public GameObject player;
    public Vector3 playerStartPos;

    public GameObject enemy;
    public Vector3 enemyStartPos;

    public TextMeshProUGUI gameOverText;

    // Start is called before the first frame update
    void Start()
    {
        playerStartPos = player.transform.position;
        enemyStartPos = enemy.transform.position;

        startButton.onClick.AddListener(StartGame);
        restartButton.onClick.AddListener(RestartGame);
        continueButton.onClick.AddListener(StartGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        isGameActive = true;
        startButton.gameObject.SetActive(false);
        continueButton.gameObject.SetActive(false);

        ResetPosition();

        Instantiate(pongBall);
 
    }

    public void UpdateScore()
    {
        Debug.Log("Add to score");
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;

        restartButton.gameObject.SetActive(true);
    }

    public void ResetPosition()
    {
        player.transform.position = playerStartPos;
        enemy.transform.position = enemyStartPos;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
