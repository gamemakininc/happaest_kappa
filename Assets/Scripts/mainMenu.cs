﻿using UnityEngine;
using UnityEngine.UI;

public class mainMenu : MonoBehaviour
{
    //bg scroll variables
    public Vector3 start;
    public Vector3 end;
    public GameObject playerNameBox;
    public GameObject scroll0;
    public GameObject scroll1;
    public Rigidbody2D rb0;
    public Rigidbody2D rb1;
    public float speed = 0.1f;
    //maim menu location variables
    //movespots 0offscreen, 1enterpoint, 2main onscreen, 3load onscreen
    public Transform[] menuPoints;
    //misc variables
    public GameObject[] menuParents;
    //0main 1load 2settings 3info one
    public bool[] menucurrent = new bool [] { false, false, false, false, false };
    private float menuSpeed = 9f;
    private Rigidbody2D rbswap;
    private Rigidbody2D rbswap2;
    public bool inpoint = false;
    public bool outpoint = false;
    public int swapint1;
    private int swapint2;
    private int infswapint1;
    private int infswapint2;

    // Start is called before the first frame update
    void Start()
    {
        mainmenu();
    }

    // Update is called once per frame
    void Update()
    {
        //bgscroll
        rb0.velocity = new Vector2(0, speed * -1);
        rb1.velocity = new Vector2(0, speed * -1);
        if (inpoint == true)
        {
            //move menu into frame
            rbswap.velocity = new Vector2(rbswap.velocity.x, -menuSpeed);
            //when in point stop
            if (Vector2.Distance(rbswap.transform.position, menuPoints[2].position) < 0.5)
            {
                if (swapint1 == 4) { infoMainPage(); }
                inpoint = false; 
                menucurrent[swapint1] = true;
                rbswap.velocity = new Vector2(rbswap.velocity.x, 0);
            }
        }

        if (outpoint == true)
        {
            //move menu out of frame
            rbswap2.velocity = new Vector2(rbswap2.velocity.x, -menuSpeed);
            //when out of frame stop
            if (Vector2.Distance(rbswap2.transform.position, menuPoints[0].position) < 0.5f)
            { 
                outpoint = false;
                menucurrent[swapint2] = false;
                rbswap2.velocity = new Vector2(rbswap2.velocity.x, 0);
            }
        }
    }
    public void mainmenu()
    {
        //set position to start point
        menuParents[0].transform.position = menuPoints[1].position;
        //get rb of next scene
        rbswap = menuParents[0].GetComponent<Rigidbody2D>();
        //set swapint1
        swapint1 = 0;
        //enable menu movement
        inpoint = true;
        //check privious scene and set clear starting at mainMenu
        if (menucurrent[0] == true) { swapint2 = 0; outpoint = true; rbswap2 = menuParents[0].GetComponent<Rigidbody2D>(); }
        //new game
        else if (menucurrent[1] == true) { swapint2 = 1; outpoint = true; rbswap2 = menuParents[1].GetComponent<Rigidbody2D>(); }
        //load game
        else if (menucurrent[2] == true) { swapint2 = 2; outpoint = true; rbswap2 = menuParents[2].GetComponent<Rigidbody2D>(); }
        //settings
        else if (menucurrent[3] == true) { swapint2 = 3; outpoint = true; rbswap2 = menuParents[3].GetComponent<Rigidbody2D>(); }
        //info
        else if (menucurrent[4] == true) { swapint2 = 4; outpoint = true; rbswap2 = menuParents[4].GetComponent<Rigidbody2D>(); }


    }
    public void newGameMenu()
    {
        //set position to start point
        menuParents[1].transform.position = menuPoints[1].position;
        //get rb of next scene
        rbswap = menuParents[1].GetComponent<Rigidbody2D>();
        swapint1 = 1;
        inpoint = true;
        //check privious scene and set clear starting at mainMenu
        if (menucurrent[0] == true) { swapint2 = 0; outpoint = true; rbswap2 = menuParents[0].GetComponent<Rigidbody2D>(); }
        //new game
        else if (menucurrent[1] == true) { swapint2 = 1; outpoint = true; rbswap2 = menuParents[1].GetComponent<Rigidbody2D>(); }
        //load game
        else if (menucurrent[2] == true) { swapint2 = 2; outpoint = true; rbswap2 = menuParents[2].GetComponent<Rigidbody2D>(); }
        //settings
        else if (menucurrent[3] == true) { swapint2 = 3; outpoint = true; rbswap2 = menuParents[3].GetComponent<Rigidbody2D>(); }
        //info
        else if (menucurrent[4] == true) { swapint2 = 4; outpoint = true; rbswap2 = menuParents[4].GetComponent<Rigidbody2D>(); }
    }
    public void loadGameMenu()
    {
        //set position to start point
        menuParents[2].transform.position = menuPoints[1].position;
        //get rb of next scene
        rbswap = menuParents[2].GetComponent<Rigidbody2D>();
        //set inpoint true
        inpoint = true;
        //set swapint 
        swapint1 = 2;
        //check privious scene and set clear starting at mainMenu
        if (menucurrent[0] == true) { swapint2 = 0; outpoint = true; rbswap2 = menuParents[0].GetComponent<Rigidbody2D>(); }
        //new game
        else if (menucurrent[1] == true) { swapint2 = 1; outpoint = true; rbswap2 = menuParents[1].GetComponent<Rigidbody2D>(); }
        //load game
        else if (menucurrent[2] == true) { swapint2 = 2; outpoint = true; rbswap2 = menuParents[2].GetComponent<Rigidbody2D>(); }
        //settings
        else if (menucurrent[3] == true) { swapint2 = 3; outpoint = true; rbswap2 = menuParents[3].GetComponent<Rigidbody2D>(); }
        //info
        else if (menucurrent[4] == true) { swapint2 = 4; outpoint = true; rbswap2 = menuParents[4].GetComponent<Rigidbody2D>(); }
    }
    public void settingsMenu() 
    {
        //set position to start point
        menuParents[3].transform.position = menuPoints[1].position;
        //get rb of next scene
        rbswap = menuParents[3].GetComponent<Rigidbody2D>();
        swapint1 = 3;
        inpoint = true;
        //check privious scene and set clear starting at mainMenu
        if (menucurrent[0] == true) { swapint2 = 0; outpoint = true; rbswap2 = menuParents[0].GetComponent<Rigidbody2D>(); }
        //new game
        else if (menucurrent[1] == true) { swapint2 = 1; outpoint = true; rbswap2 = menuParents[1].GetComponent<Rigidbody2D>(); }
        //load game
        else if (menucurrent[2] == true) { swapint2 = 2; outpoint = true; rbswap2 = menuParents[2].GetComponent<Rigidbody2D>(); }
        //settings
        else if (menucurrent[3] == true) { swapint2 = 3; outpoint = true; rbswap2 = menuParents[3].GetComponent<Rigidbody2D>(); }
        //info
        else if (menucurrent[4] == true) { swapint2 = 4; outpoint = true; rbswap2 = menuParents[4].GetComponent<Rigidbody2D>(); }
    }
    public void clearInfo() 
    {
        //move all subscenes out of frame
        menuParents[5].transform.position = menuPoints[4].position;
        menuParents[6].transform.position = menuPoints[4].position;
        menuParents[7].transform.position = menuPoints[4].position;
        menuParents[8].transform.position = menuPoints[4].position;
    }
    public void infoMenu()
    {
        //set position to start point
        menuParents[4].transform.position = menuPoints[1].position;
        //get rb of next scene
        rbswap = menuParents[4].GetComponent<Rigidbody2D>();
        swapint1 = 4;
        inpoint = true;
        //check privious scene and set clear starting at mainMenu
        if (menucurrent[0] == true) { swapint2 = 0; outpoint = true; rbswap2 = menuParents[0].GetComponent<Rigidbody2D>(); }
        //new game
        if (menucurrent[1] == true) { swapint2 = 1; outpoint = true; rbswap2 = menuParents[1].GetComponent<Rigidbody2D>(); }
        //load game
        if (menucurrent[2] == true) { swapint2 = 2; outpoint = true; rbswap2 = menuParents[2].GetComponent<Rigidbody2D>(); }
        //settings
        if (menucurrent[3] == true) { swapint2 = 3; outpoint = true; rbswap2 = menuParents[3].GetComponent<Rigidbody2D>(); }
        //info
        if (menucurrent[4] == true) { swapint2 = 4; outpoint = true; rbswap2 = menuParents[4].GetComponent<Rigidbody2D>(); }
    }
    public void infoMainPage() 
    {
        infswapint1 = 5;
        menuParents[infswapint1].transform.position = menuPoints[3].position;
        //move privious menu
        if (infswapint2 > 1 && infswapint2 != 5 )
        {
            menuParents[infswapint2].transform.position = menuPoints[4].position;
        }
        //set current menu to swapint2
        infswapint2 = 5;
    }
    public void infoFittingPage()
    {
        infswapint1 = 6;
        menuParents[infswapint1].transform.position = menuPoints[3].position;
        //move privious menu
        menuParents[infswapint2].transform.position = menuPoints[4].position;
        //set current menu to swapint2
        infswapint2 = 6;
    }
    public void infoEnemyPage()
    {
        infswapint1 = 7;
        menuParents[infswapint1].transform.position = menuPoints[3].position;
        //move privious menu
        menuParents[infswapint2].transform.position = menuPoints[4].position;
        //set current menu to swapint2
        infswapint2 = 7;
    }
    public void infoLorePage()
    {
        infswapint1 = 8;
        menuParents[infswapint1].transform.position = menuPoints[3].position;
        //move privious menu
        menuParents[infswapint2].transform.position = menuPoints[4].position;
        //set current menu to swapint2
        infswapint2 = 8;
    }
    public void changeName() 
    {
        ObserverScript.Instance.playerName = playerNameBox.GetComponent<Text>().text;
    }
}