using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody ballRb;
    public float speed = 1f;

    public int xDirection;

    public bool enemyTurn;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        xDirection = -11;
        ballRb = GetComponent<Rigidbody>();

        Move();  
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void Move()
    {
        //Debug.Log(xDirection);

        float yRange = Random.Range(-7, 7);
        Vector3 ballDestination = new Vector3(xDirection, yRange, transform.position.z);

        ballRb.AddForce(ballDestination * speed, ForceMode.Impulse);
    }

    public void OnCollisionEnter(Collision collision)
    {
        speed = 1;

        if (collision.gameObject.CompareTag("Player"))
        {
            xDirection = 11;
            Move();

            enemyTurn = true;
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            xDirection = -11;
            Move();

            enemyTurn = false;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        gameManager.isGameActive = false;

        if (other.gameObject.CompareTag("PlayerGoal"))
        {
            gameManager.GameOver();

            // display new game button
        }

        if (other.gameObject.CompareTag("EnemyGoal"))
        {
            gameManager.UpdateScore();
            gameManager.continueButton.gameObject.SetActive(true);
        }
    }
}
