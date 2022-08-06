using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTheme : MonoBehaviour
{
    public AudioSource mySong;
    bool isPlay = true;
    void Start()
    {
        mySong = GetComponent<AudioSource>();
        isPlay = true;
    }


    void Update()
    {
        if (isPlay == true)
            mySong.Play();
    }
}
