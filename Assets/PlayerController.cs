using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D body;
    public float hSpeed;
    public float vSpeed;
    private float hMove;
    private float vMove;
    
    void Start()
    {
        body = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        hMove = Input.GetAxis("Horizontal");
        vMove = Input.GetAxis("Vertical");
        if (hMove < 0) gameObject.GetComponent<SpriteRenderer>().flipX = true;
        else if (hMove > 0) gameObject.GetComponent<SpriteRenderer>().flipX = false;
        body.velocity = new Vector2(hMove * hSpeed, body.velocity.y);
        if (vMove < 0) gameObject.GetComponent<SpriteRenderer>().flipY = true;
        else if (vMove > 0) gameObject.GetComponent<SpriteRenderer>().flipY = false;
        body.velocity = new Vector2(body.velocity.x, vMove * vSpeed);
    }
}
