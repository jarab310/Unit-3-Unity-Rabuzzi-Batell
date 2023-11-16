using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D body;
    public float moveSpeed;
    //public float vSpeed;
    private float hMove;
    private float vMove;
    public GameObject sword;
    private float swordTimer;
    private Vector2 movementDirection;
    public GameObject childSprite;
    public GameObject attackZone;
    private string direction;
    private string prevDirection;
    private float rotAngle;

    public int health = 2;
    public void decreaseHealth()
    {
        health -= 1;
    }
    

    void Start()
    {
        body = gameObject.GetComponent<Rigidbody2D>();
        swordTimer = 0;
        direction = "r";
        prevDirection = "r";
        rotAngle = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Inputs();
        /*if (hMove < 0) gameObject.GetComponent<SpriteRenderer>().flipX = true;
        else if (hMove > 0) gameObject.GetComponent<SpriteRenderer>().flipX = false;*/
        body.velocity = new Vector2(hMove * moveSpeed, body.velocity.y);
        /*if (vMove < 0) gameObject.GetComponent<SpriteRenderer>().flipY = true;
        else if (vMove > 0) gameObject.GetComponent<SpriteRenderer>().flipY = false;*/
        body.velocity = new Vector2(body.velocity.x, vMove * moveSpeed);

        
    }

    private void FixedUpdate()
    {
        Movement();
        if (swordTimer > 0) { swordTimer--; }
    }

    void Inputs()
    {
        hMove = Input.GetAxisRaw("Horizontal");

        vMove = Input.GetAxisRaw("Vertical");

        movementDirection = new Vector2(hMove, vMove).normalized;//''

        if(direction == "r" && hMove != 1) 
        {
            
            if(vMove < 0) { direction="d";}
            else if (vMove > 0) { direction="u";}
            else if (hMove < 0) { direction = "l"; }
        }
        else if(direction == "l" && hMove != -1) 
        {
            if(vMove > 0) { direction="u";}
            else if(vMove < 0) { direction="d";}
            else if (hMove > 0) { direction = "r"; }
        }
        else if(direction == "u" && vMove != 1)
        {
            if (hMove > 0) { direction = "r";}
            else if(hMove < 0) { direction="l";}
            else if (vMove < 0) { direction = "d";}
            
        }
        else if (direction == "d" && vMove != -1) 
        {
            if(hMove > 0) { direction="r";}
            else if (hMove < 0) { direction="l";}
            else if (vMove > 0) { direction = "u";}
        }
        if(direction == "r") { rotAngle = 0; }
        else if(direction == "l") {  rotAngle = 180; }
        else if(direction == "u") { rotAngle = 90;  }
        else { rotAngle = 270; }

        if (Input.GetAxis("Fire1") > 0 && swordTimer == 0)
        {
            Instantiate(sword, attackZone.transform.position, Quaternion.Euler(0,0,rotAngle));//gameObject.transform.rotation.eulerAngles);//Quaternion.identity);
            swordTimer = 20;
        }
    }

    void Movement()
    {
        body.velocity = new Vector2(movementDirection.x * moveSpeed, movementDirection.y * moveSpeed);
        if(direction != prevDirection)
        {
            if(direction == "r")
            {
                transform.eulerAngles = Vector3.forward * 0;
            }
            else if (direction == "l") 
            {
                transform.eulerAngles = Vector3.forward * 180;
            }
            else if (direction == "d")
            {
                transform.eulerAngles = Vector3.forward * 270;
            }
            else
            {
                transform.eulerAngles = Vector3.forward * 90;
            }
            prevDirection = direction;
        }
    }

       private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "basicEnemy")
        {
            // Destroy self
            decreaseHealth();
        }
         if (health <= 0){
           Destroy (gameObject);
        }
    }
}
