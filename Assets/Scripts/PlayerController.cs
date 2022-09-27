using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 25;
    private float verticalInput;

    private float maxYpos = 6.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.up * Time.deltaTime * speed * verticalInput);

        if(transform.position.y >= maxYpos)
        {
            transform.position = new Vector3(transform.position.x, maxYpos, transform.position.z);
        };

        if (transform.position.y <= -maxYpos)
        {
            transform.position = new Vector3(transform.position.x, -maxYpos, transform.position.z);
        };
    }
}
