using JetBrains.Annotations;
using UnityEngine;

public class playerSpawner : MonoBehaviour
{
    public GameObject[] playerPrefabs;//used to store playermodel prefabs
    public int[] fitsetup;
    // Start is called before the first frame update
    void Start()
    {
        //update local fitsetup
        fitsetup = ObserverScript.Instance.fitSetup;
        //chose playermodel to spawn
        if (fitsetup[13] == 1) { Instantiate(playerPrefabs[0], transform.position, Quaternion.Euler(0,0,-90)); }
        else if (fitsetup[13] == 2) { Instantiate(playerPrefabs[1], transform.position, Quaternion.Euler(0, 0, -90)); }
        else if (fitsetup[13] == 3) { Instantiate(playerPrefabs[2], transform.position, Quaternion.Euler(0, 0, -90)); }
        else if (fitsetup[13] == 4) { Instantiate(playerPrefabs[3], transform.position, Quaternion.Euler(0, 0, -90)); }
        else if (fitsetup[13] == 5) { Instantiate(playerPrefabs[4], transform.position, Quaternion.Euler(0, 0, -90)); }
        else if (fitsetup[13] == 6) { Instantiate(playerPrefabs[5], transform.position, Quaternion.Euler(0, 0, -90)); }
        else if (fitsetup[13] == 7) { Instantiate(playerPrefabs[6], transform.position, Quaternion.Euler(0, 0, -90)); }
        else if (fitsetup[13] == 8) { Instantiate(playerPrefabs[7], transform.position, Quaternion.Euler(0, 0, -90)); }

        //remove spawner
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
