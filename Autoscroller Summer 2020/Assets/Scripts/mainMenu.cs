using UnityEngine;

public class mainMenu : MonoBehaviour
{
    //bg scroll variables
    public Vector3 start;
    public Vector3 end;
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
    private bool[] menucurrent = new bool [] { false, false, false, false };
    private float menuSpeed = 9f;
    private Rigidbody2D rbswap;
    private Rigidbody2D rbswap2;
    public bool inpoint = false;
    public bool outpoint = false;
    private int swapint1;
    private int swapint2;


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
            if (Vector2.Distance(rbswap.transform.position, menuPoints[2].position) < 1)
            { 
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
            if (Vector2.Distance(rbswap2.transform.position, menuPoints[0].position) < 1f)
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
        //check if a menu needs cleared
        if (menucurrent[1] == true) { swapint2 =1; outpoint = true; rbswap2 = menuParents[1].GetComponent<Rigidbody2D>(); }
        else if (menucurrent[2] == true) { swapint2 = 2; outpoint = true; rbswap2 = menuParents[2].GetComponent<Rigidbody2D>(); }
        else if (menucurrent[3] == true) { swapint2 = 3; outpoint = true; rbswap2 = menuParents[3].GetComponent<Rigidbody2D>(); }

        
    }
    public void loadGameMenu()
    {
        //set position to start point
        menuParents[1].transform.position = menuPoints[1].position;
        //get rb of next scene
        rbswap = menuParents[1].GetComponent<Rigidbody2D>();
        //set inpoint true
        inpoint = true;
        //set swapint 
        swapint1 = 1;
        //check if menu exists
        if (menucurrent[0] == true) { swapint2 = 0; outpoint = true; rbswap2 = menuParents[0].GetComponent<Rigidbody2D>(); }
        else if (menucurrent[2] == true) { swapint2 = 2; outpoint = true; rbswap2 = menuParents[2].GetComponent<Rigidbody2D>(); }
        else if (menucurrent[3] == true) { swapint2 = 3; outpoint = true; rbswap2 = menuParents[3].GetComponent<Rigidbody2D>(); }
    }
    public void settingsMenu() 
    {
        //set position to start point
        menuParents[2].transform.position = menuPoints[1].position;
        //get rb of next scene
        rbswap = menuParents[2].GetComponent<Rigidbody2D>();
        swapint1 = 2;
        inpoint = true;
        menuParents[2].transform.position = menuPoints[1].position;
        if (menucurrent[0] == true) { swapint2 = 0; outpoint = true; rbswap2 = menuParents[0].GetComponent<Rigidbody2D>(); }
        else if (menucurrent[1] == true) { swapint2 = 1; outpoint = true; rbswap2 = menuParents[1].GetComponent<Rigidbody2D>(); }
        else if (menucurrent[3] == true) { swapint2 = 3; outpoint = true; rbswap2 = menuParents[3].GetComponent<Rigidbody2D>(); }
    }
    public void infoMenu()
    {
        //set position to start point
        menuParents[3].transform.position = menuPoints[1].position;
        //get rb of next scene
        rbswap = menuParents[3].GetComponent<Rigidbody2D>();
        swapint1 = 3;
        inpoint = true;
        menuParents[3].transform.position = menuPoints[1].position;
        if (menucurrent[0] == true) { swapint2 = 0; outpoint = true; rbswap2 = menuParents[0].GetComponent<Rigidbody2D>(); }
        else if (menucurrent[1] == true) { swapint2 = 1; outpoint = true; rbswap2 = menuParents[1].GetComponent<Rigidbody2D>(); }
        else if (menucurrent[2] == true) { swapint2 = 2; outpoint = true; rbswap2 = menuParents[2].GetComponent<Rigidbody2D>(); }
    }
}
