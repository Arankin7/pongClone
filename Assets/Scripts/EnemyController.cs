using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private GameObject target;
    private Rigidbody enemyRb;

    public float speed;
    private float maxYpos = 6.5f;

    private GameManager gameManager;
    private BallController ballController;
    private DifficultyButton difficultyButton;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        
    }

    public void SetDifficulty(float difficulty)
    {
        speed = difficulty;
    }

    // Update is called once per frame
    void Update()
    {
        target = GameObject.FindGameObjectWithTag("PongBall");

        if (gameManager.isGameActive == true)
        {
            ballController = GameObject.FindGameObjectWithTag("PongBall").GetComponent<BallController>();

            if (ballController.enemyTurn == true)
            {
                Vector3 ballPos = target.transform.position;

                Vector3 enemyDestination = new Vector3(transform.position.x, ballPos.y, transform.position.z);
                // Vector3 movementDir = (target.transform.position - transform.position).normalized;

                transform.position = Vector3.Lerp(transform.position, enemyDestination, speed * Time.deltaTime);
            }
            
        }

        if (transform.position.y >= maxYpos)
        {
            transform.position = new Vector3(transform.position.x, maxYpos, transform.position.z);
        };

        if (transform.position.y <= -maxYpos)
        {
            transform.position = new Vector3(transform.position.x, -maxYpos, transform.position.z);
        };
    }
}
