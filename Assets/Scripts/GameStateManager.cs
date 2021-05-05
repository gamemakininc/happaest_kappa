using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public GameObject pauseMenu;
    private GameObject[] enemies;
    private GameObject[] bullets;
    private GameObject[] tiles;
    public GameObject background;
    private float backgroundSpeed;
    private enum states
    {
        play,
        pause,
        intro
    }
    private states currentState = states.intro;
    private states priorState; ///stores state during pause


    float velocity = 0.0f;
    Vector2 bVelocity;

    private void Start()
    {
        backgroundSpeed = Camera.main.GetComponent<BackgroundSpawner>().speedMultiplier;
        bVelocity = new Vector2(-12.0f, 0.0f);
    }

    public void Update()
    {
        #region Intro Animation
        ///Should be using a switch statement here
        if (currentState == states.intro) ///Level start animation
        {
            Camera.main.GetComponent<EnemyWavev2>().enabled = false;
            //background = GameObject.Find("Background");
            GameObject tile = Camera.main.GetComponent<EnemyWavev2>().currentTile;
            tile.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;

            enemies = GameObject.FindGameObjectsWithTag("enemy");
            foreach (GameObject enemy in enemies)
            {
                enemy.GetComponent<enemyscript>().currentState = enemyscript.states.paused;
            }

            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<PlayerScript>().enabled = false;

            Vector2 targetVelocity = background.GetComponent<InstantVelocity>().velocity;
            bVelocity = new Vector2(Mathf.SmoothDamp(bVelocity.x, -1.0f, ref velocity, 1.5f), 0.0f);
            background.GetComponent<Rigidbody2D>().velocity = bVelocity; ///Apply changes
            backgroundSpeed = Mathf.SmoothDamp(bVelocity.x, 1.0f, ref velocity, 1.5f);
            Camera.main.GetComponent<BackgroundSpawner>().speedMultiplier = -backgroundSpeed;
            //print(Camera.main.GetComponent<BackgroundSpawner>().speedMultiplier);

            if (Mathf.Pow(Vector2.Distance(bVelocity, targetVelocity), 2)  <= 0.1f) ///Unfreezes everything at end of intro animation
            {
                UnPause();
                tile.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                tile.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
                background.GetComponent<Rigidbody2D>().velocity = targetVelocity;
                currentState = states.play;
                Camera.main.GetComponent<EnemyWavev2>().enabled = true;
            }
            //print(background.GetComponent<Rigidbody2D>().velocity);
        }
        #endregion

        #region Pause
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (currentState != states.pause)
            {
                priorState = currentState;
                currentState = states.pause;
                Pause();
            }
            else
            {
                currentState = priorState;
                UnPause();
            }
        }
        #endregion
    }

    ///Called when pausing the game
    public void Pause()
    {
        enemies = GameObject.FindGameObjectsWithTag("enemy");
        foreach(GameObject enemy in enemies)
        {
            enemy.GetComponent<enemyscript>().currentState = enemyscript.states.paused;
            enemy.GetComponent<enemyscript>().shootDissabled = true;
        }
        bullets = GameObject.FindGameObjectsWithTag("Bullet");
        foreach(GameObject bullet in bullets) { bullet.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition; }
        tiles = GameObject.FindGameObjectsWithTag("Background");
        foreach(GameObject tile in tiles)
        {
            if (tile.name.ToLower().Substring(0, 4) == "tile") { tile.GetComponent<TileScript>().freeze = true; }
        }

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerScript>().enabled = false;

        background = GameObject.Find("Background");
        background.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        pauseMenu.gameObject.SetActive(true);
    }

    ///The opposite of pause
    public void UnPause()
    {
        //enemies = GameObject.FindGameObjectsWithTag("enemy");
        if (enemies != null) {
            foreach (GameObject enemy in enemies)
            {
                enemy.GetComponent<enemyscript>().currentState = enemy.GetComponent<enemyscript>().storedState;
                enemy.GetComponent<enemyscript>().shootDissabled = false;
            }
        }
        if (bullets != null) {
            foreach (GameObject bullet in bullets)
            {
                bullet.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                float speed = bullet.GetComponent<ebulletscript>().speed;
                bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.up * speed;
            }
        }
        if (tiles != null) {
            foreach (GameObject tile in tiles)
            {
                if (tile.name.ToLower().Substring(0, 4) == "tile") {
                    tile.GetComponent<TileScript>().freeze = false;
                    /*float _velocity = tile.GetComponent<TileScript>().speed;
                    tile.GetComponent<Rigidbody2D>().velocity = new Vector2(backgroundSpeed, 0);*/
                }
            }
        }

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerScript>().enabled = true;

        background = GameObject.Find("Background");
        background.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        background.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        Vector2 velocity = background.GetComponent<InstantVelocity>().velocity;
        background.GetComponent<Rigidbody2D>().velocity = velocity;
        pauseMenu.gameObject.SetActive(true);
    }
}
