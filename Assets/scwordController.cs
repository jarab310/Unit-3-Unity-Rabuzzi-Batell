using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scwordController : MonoBehaviour
{
    // Start is called before the first frame update
    private float timer;
    void Start()
    {
        timer = 5;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (timer > 0)
        {
            timer--;


        }
        else
        {
            Destroy(gameObject);
        }
    }
}
