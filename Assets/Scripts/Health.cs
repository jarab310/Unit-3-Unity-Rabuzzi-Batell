using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
   
    private void OnTriggerEnter2D(Collider2D collision)
        {
        if (collision.gameObject.tag == "Player")
            {
                if (collision.gameObject.GetComponent<PlayerHealth>().health < collision.gameObject.GetComponent<PlayerHealth>().maxHealth)
                {
                    collision.gameObject.GetComponent<PlayerHealth>().health += 1;
                }
                 Destroy (gameObject);
            }
        }      
    }

