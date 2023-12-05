using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackController : MonoBehaviour
{
    // Start is called before the first frame update
    private float hMove;
    private float vMove;
    public GameObject sword;
    private float swordTimer;
    public GameObject attackZone;
    private string direction;
    private string prevDirection;
    private float rotAngle;
    private bool swordAttack;
    void Start()
    {
        swordTimer = 0;
        direction = "d";
        prevDirection = "d";
        rotAngle = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Inputs();
    }

    private void FixedUpdate()
    {
        Movement();
        if (swordTimer > 0) { swordTimer--; }
        if (swordTimer == 0 && swordAttack == true)
        {
            Instantiate(sword, attackZone.transform.position, Quaternion.Euler(0, 0, rotAngle -90));//gameObject.transform.rotation.eulerAngles);//Quaternion.identity);
            swordTimer = 20;
        }
        swordAttack = false;
    }

    void Inputs()
    {

        hMove = Input.GetAxisRaw("Horizontal");

        vMove = Input.GetAxisRaw("Vertical");

       // movementDirection = new Vector2(hMove, vMove).normalized;

        if (direction == "r" && hMove != 1)
        {

            if (vMove < 0) { direction = "d"; }
            else if (vMove > 0) { direction = "u"; }
            else if (hMove < 0) { direction = "l"; }
        }
        else if (direction == "l" && hMove != -1)
        {
            if (vMove > 0) { direction = "u"; }
            else if (vMove < 0) { direction = "d"; }
            else if (hMove > 0) { direction = "r"; }
        }
        else if (direction == "u" && vMove != 1)
        {
            if (hMove > 0) { direction = "r"; }
            else if (hMove < 0) { direction = "l"; }
            else if (vMove < 0) { direction = "d"; }

        }
        else if (direction == "d" && vMove != -1)
        {
            if (hMove < 0) { direction = "l"; }//if(hMove > 0) { direction="r";}
            else if (hMove > 0) { direction = "r"; } //(hMove < 0) { direction="l";}
            else if (vMove > 0) { direction = "u"; }
        }
        if (direction == "r") { rotAngle = 90; }
        else if (direction == "l") { rotAngle = 270; }
        else if (direction == "u") { rotAngle = 180; }
        else { rotAngle = 0; }

        if (Input.GetAxisRaw("Fire1") != 0)
        {
            swordAttack = true;
            //Debug.Log("shmack");
        }
        //Debug.Log(Input.GetAxisRaw("Fire1"));

    }


    void Movement()
    {
      //  body.velocity = new Vector2(movementDirection.x * moveSpeed, movementDirection.y * moveSpeed);
        if (direction != prevDirection)
        {
            if (direction == "r")
            {
                transform.eulerAngles = Vector3.forward * rotAngle;
            }
            else if (direction == "l")
            {
                transform.eulerAngles = Vector3.forward * rotAngle;
            }
            else if (direction == "d")
            {
                transform.eulerAngles = Vector3.forward * rotAngle;
            }
            else
            {
                transform.eulerAngles = Vector3.forward * rotAngle;
            }
            prevDirection = direction;
        }
    }
}
