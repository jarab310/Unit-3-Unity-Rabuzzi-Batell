using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeController : MonoBehaviour
{
    // Start is called before the first frame update
    private float timer = 75;
    private int damage = 1;
    // Update is called once per frame

    /* private void Start()
     {
         body = gameObject.GetComponent<Rigidbody2D>();

     }*/
    void FixedUpdate()
    {
        timer--;
        if (timer <= 0) Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealth>().health -= damage;
        }
    }
}
