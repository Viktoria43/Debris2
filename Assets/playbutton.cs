using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void Quit()
    {
        Application.Quit();
    }
   public void Credentials()
    {
        SceneManager.LoadSceneAsync(2);
    }
   public void esc()
    {
        SceneManager.LoadSceneAsync(0);
    }
}