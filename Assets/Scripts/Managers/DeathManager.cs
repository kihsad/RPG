using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathManager : MonoBehaviour
{
    [SerializeField]
    private Player _player;

    private void Update()
    {
        DeathScreen();
    }
    public void DeathScreen()
    {
        if (_player.GetComponent<Animator>().GetBool("isDead"))
        {
            SceneManager.LoadScene("DeathScene");
        }
    }
}
