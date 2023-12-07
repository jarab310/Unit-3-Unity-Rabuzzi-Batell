using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public int maxHealth;
    public int health;
    public audioManagement audioManager;

    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0) 
        {
            audioManager.PlaySound(audioManager.playerDeath);
            SceneManager.LoadScene(0);
        }
    }
}
