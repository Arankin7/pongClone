using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private GameObject target;
    private Rigidbody enemyRb;

    private float speed = 1.3f;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        target = GameObject.Find("Ball");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 ballPos = target.transform.position;

        Vector3 enemyDestination = new Vector3(transform.position.x, ballPos.y, transform.position.z);
        // Vector3 movementDir = (target.transform.position - transform.position).normalized;

        transform.position = Vector3.Lerp(transform.position, enemyDestination, speed * Time.deltaTime);
    }
}
