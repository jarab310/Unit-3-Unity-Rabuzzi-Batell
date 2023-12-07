using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HEnemyController : MonoBehaviour
{
    public int speed = 1;
    private float timePassed = 0f;
    private int direction = 1;
    public int damage = 1;
    public int health = 2;
    public GameObject drop;
    // Update is called once per frame
    
    private float movex;
    private float movey;
    public Animator animator;
    
    void Update()
    {
        /* movex = Input.GetAxisRaw("Horizontal");

         movey = Input.GetAxisRaw("Vertical");*/

         Vector2 pos = new Vector2(gameObject.transform.position.x + speed * direction * Time.deltaTime, 
             gameObject.transform.position.y);
         gameObject.transform.position = pos;
         timePassed += Time.deltaTime;
        
        /* animator.SetFloat("Speed", new Vector2(movex, movey).sqrMagnitude);
         animator.SetFloat("Vertical",movey);
         animator.SetFloat("Horizontal", movex);*/

        animator.SetFloat("Horizontal", direction);
        animator.SetFloat("Speed", 1);
        //animator.SetFloat("Horizontal", 0);

        if (timePassed >= 5)
        {
            direction = direction * -1;
            timePassed = 0;
        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "playerAttack")
        {
            if (collision.gameObject.tag == "Player")
            {
                collision.gameObject.GetComponent<PlayerHealth>().health -= damage;
            }
            // Destroy self
            decreaseHealth();
        }
         if (health <= 0){
            if(Random.Range(0f, 3f) <= 1.4f)
            {
                Instantiate(drop, gameObject.transform.position, Quaternion.identity);
            }
            Destroy (gameObject);
        }
    }

    private void decreaseHealth()
    {
        health --;
        if(health <= 0) Destroy (gameObject);
    }

    // private 

}