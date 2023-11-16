using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int speed = 1;
    private float timePassed = 0f;
    private int direction = 1;

    public int health = 2;
    // Update is called once per frame
    public void decreaseHealth()
    {
        health -= 1;
    }
    void Update()
    {
        Vector2 pos = new Vector2(gameObject.transform.position.x, 
            gameObject.transform.position.y+ speed * direction * Time.deltaTime);
        gameObject.transform.position = pos;
        timePassed += Time.deltaTime;

        if(timePassed >= 5)
        {
            direction = direction * -1;
            timePassed = 0;
        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "teehee")
        {
            // Destroy self
            //this.decreaseHealth();
        //}
         //if (this.health <= 0){
            Destroy (gameObject);
        }
    }
        
}