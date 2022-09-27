using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody ballRb;
    public float speed = 1f;

    public int xDirection;

    // Start is called before the first frame update
    void Start()
    {
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

        float yRange = Random.Range(-5, 5);
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
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            xDirection = -11;
            Move();
        }
    }
}
