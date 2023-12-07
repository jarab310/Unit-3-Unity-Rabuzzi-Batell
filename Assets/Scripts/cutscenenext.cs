using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cutscenenext : MonoBehaviour
{
    public float time =5;
    void Start()
    {
        StartCoroutine(NextScene());
    }
    

    // Start is called before the first frame update
    

    // Update is called once per frame
    private IEnumerator NextScene()
        { 
            yield return new WaitForSeconds(time);
            SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1)%5);
        }
}
