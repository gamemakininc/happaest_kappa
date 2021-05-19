using UnityEngine;

public class autoclear : MonoBehaviour
{
    public float timer;
    public float killTime;
    public GameStateManager gStat;
    public bool jumpIn;
    // Start is called before the first frame update
    void Start()
    {
        gStat = FindObjectOfType<GameStateManager>();
        //check to remove the normal intro animation if defence mission.
        if (jumpIn == true && ObserverScript.Instance.defenceMission == true) 
        {
            //remove self
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gStat.paused == false)
        {
            timer += 1 * Time.deltaTime;
        }
        if (timer >= killTime) 
        {
            //remove self
            kill();
        }
    }
    public void kill() { Destroy(gameObject); }
}
