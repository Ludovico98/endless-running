using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool gameEnded = false;

    public GameObject WinUI;
    public GameObject DeadUI;

    public void Win() //activate Canvas when colliding end target (WIN)
    {
        WinUI.SetActive(true);
    }

    public void Dead() // activate Canvas when colliding with obsicle
    {
        DeadUI.SetActive(true);

    }


    public void EndGame()
    {
        //Player dies
        if (gameEnded == false)
        {
            gameEnded = true;
            Invoke("Restart", 2f);
        }
        // Load menu, restart game / exit game
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
