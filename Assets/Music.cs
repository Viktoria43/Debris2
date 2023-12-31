using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Music : MonoBehaviour
{
    public Sprite soundOn;
    public Sprite soundOff;
    private bool isPlaying = true;
 
    public AudioSource audioSource; 
    public Button soundButton;

    

    void Start()
    {
        soundOn = soundButton.image.sprite;
    }

    void Update()
    {
        // Your update logic here if needed
    }

    public void ButtonClicked()
    {
        if (isPlaying)
        {
            soundButton.image.sprite = soundOff;
            isPlaying = false;

            audioSource.mute = true;
        }

        
         
           else
            {
                soundButton.image.sprite = soundOn;
                isPlaying = true;
                

                audioSource.mute = false;
            }
           
        }

    private void Awake()
    {
        GameObject[] music = GameObject.FindGameObjectsWithTag("audio");
        DontDestroyOnLoad(this.gameObject);
    }
    }


