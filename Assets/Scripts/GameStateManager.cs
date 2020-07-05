using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public GameObject pauseMenu;
    private GameObject[] enemies;
    private GameObject[] background;

    private bool isPaused;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                isPaused = true;
                Pause();
            }
            else
            {
                isPaused = false;
                UnPause();
            }
        }
    }

    //Called when pausing the game
    public void Pause()
    {
        enemies = GameObject.FindGameObjectsWithTag("enemy");
        foreach(GameObject enemy in enemies)
        {
            enemy.GetComponent<enemyscript>().currentState = enemyscript.states.paused;
        }

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerScript>().enabled = false;

        background = GameObject.FindGameObjectsWithTag("Background");
        foreach(GameObject element in background)
        {
            element.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }

    //The opposite of pause
    public void UnPause()
    {
        //enemies = GameObject.FindGameObjectsWithTag("enemy");
        foreach (GameObject enemy in enemies)
        {
            enemy.GetComponent<enemyscript>().currentState = enemy.GetComponent<enemyscript>().storedState;
        }

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerScript>().enabled = true;

        foreach (GameObject element in background)
        {
            element.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            element.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
}
