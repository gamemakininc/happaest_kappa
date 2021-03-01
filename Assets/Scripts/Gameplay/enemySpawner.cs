using System.Collections;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    int wingSize;
    int selecter;
    public bool kama;
    public bool streaght;
    public bool weevy;
    public bool diaginal;
    public bool hangar_port;
    public bool spawning;
    public GameObject th1s;

    public GameObject[] shipPrefabs;
    // Start is called before the first frame update
    void Start()
    {
        //if it isnt a persistant launch point spawn and remove
        if (hangar_port == false)
        {
            if (streaght == true)
            {
                //set selector
                selecter = 0;
                //spawn
                spawn();
            }
            else if (weevy == true)
            {
                selecter = 1;
                spawn();
            }
            else if (diaginal == true)
            {
                selecter = 2;
                spawn();
            }
            else if (kama == true)
            {
                selecter = 3;
                spawn();
            }
            Destroy(gameObject);
        }
        //otherwise await orders

    }
    public void spawn() 
    {
        Instantiate(shipPrefabs[selecter], th1s.transform);
    }
    public void hangarPush() 
    {
        //because the auto unparent that is needed for turrets to work fks with scale
        if (transform.localScale != new Vector3(1.5f, 1.5f, 1.5f)) { transform.localScale = new Vector3(1.5f, 1.5f, 1.5f); }
        //retrigger prevention
        if (spawning == false)
        {
            //set retrigger prevention
            spawning = true;
            //set how menny to spawn
            wingSize = Random.Range(2, 5);
            //set selector
            selecter = Random.Range(0,2);
            StartCoroutine(wingSpawn());
        }
        else 
        {
            //do nothing
        }
    }
    IEnumerator wingSpawn() 
    {
        //l00p to spawn
        while (wingSize > 0) 
        {
            //spawn
            spawn();
            //lower amount to spawn
            wingSize--;
            //wait
            //wait variable amount
            yield return 0;
            yield return new WaitForSeconds(0.4f);
        }
        //tell script spawning is clear
        spawning = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
