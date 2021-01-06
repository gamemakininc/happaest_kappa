using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public bool kama;
    public bool streaght;
    public bool weevy;
    public bool diaginal;
    public bool hangar_port;

    public GameObject[] shipPrefabs;
    // Start is called before the first frame update
    void Start()
    {
        //if it isnt a persistant launch point spawn and remove
        if (hangar_port == false)
        {
            if (streaght == true)
            {
                spawn(0);
            }
            else if (weevy == true)
            {
                spawn(1);
            }
            else if (diaginal == true)
            {
                spawn(2);
            }
            else if (kama == true)
            {
                spawn(3);
            }
            Destroy(gameObject);
        }
        //otherwise await orders

    }
    public void spawn(int type) 
    {
        Instantiate(shipPrefabs[type]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
