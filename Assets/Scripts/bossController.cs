using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bossController : MonoBehaviour
{
    // Start is called before the first frame update

    public int speed = 4;
    private int direction = 0; //0 = up, 1 = right, 2 = down, 3 = left
    private int oppDirection = 2;
    public int damage = 1;
    public int health = 15;
    public SpriteRenderer renderer;
    private bool lowHealth = false;
    private float attackTimer = 10;
    private float moveTimer;
    private float turnCounter;
    public GameObject spike;
    public Animator animator;
    public Rigidbody2D body;
    public GameObject[] zones;
           

    void Start()
    {
        animator.SetFloat("Vertical", 1);
        animator.SetFloat("Horizontal", 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /*if (moveTimer > 0)
        {
            moveTimer--;
        }
        else */if (attackTimer > 0)
        {
            attackTimer--;
            if(direction == 0)
            {
                body.velocity = new Vector2(0, speed);
            }
            else if (direction == 1) { body.velocity = new Vector2(speed, 0); }
            else if (direction == 2) { body.velocity = new Vector2(0, -speed); }
            else if (direction == 3) { body.velocity = new Vector2(-speed, 0); }

        }
        else attack();
        if (turnCounter >= 2)
        {
            animator.SetFloat("Attacking", 0);
            int newTurn = Random.Range(0, 4);
            if (newTurn != direction)
            {
                direction = newTurn;
                turnCounter = 0;
                if (direction == 0)
                {
                    oppDirection = 2;
                    animator.SetFloat("Vertical", 1);
                    animator.SetFloat("Horizontal", 0);
                }
                else if (direction == 1)
                {
                    oppDirection = 3;
                    animator.SetFloat("Vertical", 0);
                    animator.SetFloat("Horizontal", 1);
                }
                else if (direction == 2)
                {
                    oppDirection = 0;
                    animator.SetFloat("Vertical", -1);
                    animator.SetFloat("Horizontal", 0);
                }
                else if (direction == 3) 
                { 
                    oppDirection = 1;
                    animator.SetFloat("Vertical", 0);
                    animator.SetFloat("Horizontal", -1);
                }  
            }
        }

    }

    public void attack()
    {
        animator.SetFloat("Attacking", 1);
        if (lowHealth) { 
            for (int i = 0; i < 4; i++)
            {
                if (i != oppDirection) Instantiate(spike, zones[i].transform.position, zones[i].transform.rotation);
            }
        } 
        else {
            Instantiate(spike, zones[direction].transform.position, zones[direction].transform.rotation);
        }

        attackTimer = 75;
        //moveTimer = 75;
        turnCounter++;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.tag == "Player")
            {
                collision.gameObject.GetComponent<PlayerHealth>().health -= damage;
            }
            // Destroy self
            //decreaseHealth();
        }

        if(collision.gameObject.tag == "playerAttack")
        {
            decreaseHealth(1);
        }
        if (health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }
    }

    private void decreaseHealth(int amount)
    {
        health -= amount;
        if(health <= 5)
        {
            lowHealth = true;
            speed = 6;
            damage = 2;
            renderer.material.SetColor("_Color", Color.red);
        }
    }
}
