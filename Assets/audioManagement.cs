using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManagement : MonoBehaviour
{
    // Start is called before the first frame update

    [Header("          Audio Sources            ")]
    [SerializeField] private AudioSource[] musicSourceArray;
    [SerializeField] private AudioSource sounds;

    [Header("          Audio Clips            ")]
    public AudioClip withIntro;
    public AudioClip noIntro;
    public AudioClip sword;


    private void Start()
    {
        musicSourceArray[0].clip = withIntro;
        musicSourceArray[1].clip = noIntro;
        musicSourceArray[0].loop = false;
        musicSourceArray[1].loop = true;
        musicSourceArray[0].Play();
        musicSourceArray[1].PlayDelayed(musicSourceArray[0].clip.length);
        /*introMusic.clip = withIntro;
        //introMusic.Play();  
        music.clip = noIntro;
        music.loop = true;
        music.PlayScheduled(withIntro.length);*/
    }
    // Update is called once per frame
    public void PlaySound(AudioClip clip)
    {
        sounds.PlayOneShot(clip);
    }
}
