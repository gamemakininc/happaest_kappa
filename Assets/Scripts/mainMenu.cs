using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class mainMenu : MonoBehaviour
{
    //bg scroll variables
    public GameObject playerNameBox;
    public PostProcessVolume ppv;
    public bool effPeak;
    private GlitchShader gs;
    public float effecTimer;
    public bool effGo;
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
    //continue variable
    public bool gameInProgress = false;
    public GameObject continuebtn;
    public bool[] unlocks;

    // Start is called before the first frame update
    void Start()
    {
        ppv.profile.TryGetSettings(out gs);
        unlocks = ObserverScript.Instance.unlocks;
        continueStatus();
        mixMaster.Instance.nTrack = 0;
        mainmenu();
    }

    // Update is called once per frame
    void Update()
    {
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
        //bg scroll effects
        if (effGo == true)
        {
            if (effecTimer <= 1 && effPeak == false)
            {
                effecTimer = 2*Time.deltaTime;
                gs.drift.value = effecTimer;
                gs.jitter.value = effecTimer;
                if (effecTimer >= 1)
                {
                    effPeak = true;
                }
            }
            if (effecTimer >= 0 && effPeak == true)
            {
                effecTimer = -2*Time.deltaTime;
                gs.drift.value = effecTimer;
                gs.jitter.value = effecTimer;
                if (gs.drift <= 0) { effGo = false; effPeak = false; }
            }
        }
    }
    public void continueStatus()
    {
        //check if any ships unlocked
        if (unlocks[28] == true || unlocks[29] == true || unlocks[30] == true || unlocks[31] == true || unlocks[32] == true || unlocks[33] == true || unlocks[34] == true || unlocks[35] == true)
        //allow use of continue btn
        { continuebtn.GetComponent<Button>().enabled = true; }
        //if all ships locked play is impossible so lock continue btn
        else { continuebtn.GetComponent<Button>().enabled = false; }
    }
    public void mainmenu()
    {
        //start bg effect cycle
        effGo = true;
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
        //start bg effect cycle
        effGo = true;
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
        //start bg effect cycle
        effGo = true;
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
        //start bg effect cycle
        effGo = true;
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
        //start bg effect cycle
        effGo = true;
        //move all subscenes out of frame
        menuParents[5].transform.position = menuPoints[4].position;
        menuParents[6].transform.position = menuPoints[4].position;
        menuParents[7].transform.position = menuPoints[4].position;
        menuParents[8].transform.position = menuPoints[4].position;
    }
    public void infoMenu()
    {
        //start bg effect cycle
        effGo = true;
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
        //start bg effect cycle
        effGo = true;

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
        //start bg effect cycle
        effGo = true;

        infswapint1 = 6;
        menuParents[infswapint1].transform.position = menuPoints[3].position;
        //move privious menu
        menuParents[infswapint2].transform.position = menuPoints[4].position;
        //set current menu to swapint2
        infswapint2 = 6;
    }
    public void infoEnemyPage()
    {
        //start bg effect cycle
        effGo = true;

        infswapint1 = 7;
        menuParents[infswapint1].transform.position = menuPoints[3].position;
        //move privious menu
        menuParents[infswapint2].transform.position = menuPoints[4].position;
        //set current menu to swapint2
        infswapint2 = 7;
    }
    public void infoLorePage()
    {
        //start bg effect cycle
        effGo = true;

        infswapint1 = 8;
        menuParents[infswapint1].transform.position = menuPoints[3].position;
        //move privious menu
        menuParents[infswapint2].transform.position = menuPoints[4].position;
        //set current menu to swapint2
        infswapint2 = 8;
    }
}
