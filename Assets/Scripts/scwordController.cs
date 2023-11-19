using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scwordController : MonoBehaviour
{
    // Start is called before the first frame update
    private float timer;
    /*private Rigidbody2D body;
    private Vector2 movementDirection;
    public float moveSpeed;*/


    void Start()
    {
        timer = 5;
       // body = gameObject.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (timer > 0)
        {
            timer--;
            //body.velocity = new Vector2(movementDirection.x * moveSpeed, movementDirection.y * moveSpeed);

        }
        else
        {
            Destroy(gameObject);
        }
    }
}
