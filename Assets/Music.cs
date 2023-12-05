using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Music : MonoBehaviour
{
    public Sprite soundOn;
    public Sprite soundOff;
    private bool isPlaying = true;
    public static Music instance;
    public AudioSource audioSource;  // Changed from public to non-static
    public Button soundButton;

    void Awake()
    {
        // Ensure only one instance of the Music script exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        // Initialize audioSource if not assigned
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();

            if (audioSource == null)
            {
                Debug.LogError("AudioSource not found. Make sure it is attached to the same GameObject as the Music script.");
            }
        }
    }

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

            if (audioSource != null)
            {
                audioSource.mute = true;
            }
            else
            {
                Debug.LogError("AudioSource is null. Make sure it is assigned to the Music script.");
            }
        }
        else
        {
            soundButton.image.sprite = soundOn;
            isPlaying = true;

            if (audioSource != null)
            {
                audioSource.mute = false;
            }
            else
            {
                Debug.LogError("AudioSource is null. Make sure it is assigned to the Music script.");
            }
        }
    }
}