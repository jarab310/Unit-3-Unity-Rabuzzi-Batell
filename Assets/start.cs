using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class start : MonoBehaviour
{
    // Start is called before the first frame update
    private bool begin;
    private float timer;
    audioManagement audioManager;
    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("audio").GetComponent<audioManagement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Fire1") != 0 && begin == false)
        {
            begin = true;
            audioManager.PlaySound(audioManager.sword);
            
            //Debug.Log("shmack");
        }
        
    }
    private void FixedUpdate()
    {
        if (begin)
        {
            timer++;
            if (timer >=35)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

            }
        }
    }
}
