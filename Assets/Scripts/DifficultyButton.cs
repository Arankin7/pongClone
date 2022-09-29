using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    private Button button;
    private EnemyController enemySpeed;
    private GameManager gameManager;
    public float difficulty;


    // Start is called before the first frame update
    void Start()
    {
        enemySpeed = GameObject.Find("Enemy").GetComponent<EnemyController>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetDifficulty()
    {
       
        enemySpeed.SetDifficulty(difficulty);

        gameManager.GameReady();

    }
}
