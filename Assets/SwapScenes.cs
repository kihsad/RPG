using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwapScenes : MonoBehaviour
{
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "DeathScene")
            SoundManager.Instance.GetComponent<AudioSource>().Pause();
        else SoundManager.Instance.GetComponent<AudioSource>().Play();
    }
}
