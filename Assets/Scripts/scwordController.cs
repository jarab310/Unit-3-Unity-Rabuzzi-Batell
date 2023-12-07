using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Windows;

public class scwordController : MonoBehaviour
{
    // Start is called before the first frame update
    public float timer;
    private Rigidbody2D body;
    private Vector2 movementDirection;
    public float moveSpeed;
    public string location;
    audioManagement audioManager;


    void Start()
    {
        //timer = 6;
        body = gameObject.GetComponent<Rigidbody2D>();
        audioManager.PlaySound(audioManager.sword);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (timer > 0)
        {
            timer--;
            movementDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
            body.velocity = new Vector2(movementDirection.x * moveSpeed, movementDirection.y * moveSpeed);

        }
        else
        {
            Destroy(gameObject);
        }
    }

}
