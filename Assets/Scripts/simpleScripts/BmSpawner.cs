using UnityEngine;

public class BmSpawner : MonoBehaviour
{
    public Animator animator;
    public GameObject[] spawnpoints;
    public GameObject missile;
    public bool ready;
    public float timer;
    public float goal;

    public void resetTimer()
    {
        animator = GetComponent<Animator>();
        timer = 0;
        ready = true;
    }
    public void fire()
    {
        Instantiate(missile, spawnpoints[0].transform);
        Instantiate(missile, spawnpoints[1].transform);
        Instantiate(missile, spawnpoints[2].transform);
        Instantiate(missile, spawnpoints[3].transform);
        animator.SetBool("ready", false);
        ready = false;
    }
    public void fireHalf()
    {
        Instantiate(missile, spawnpoints[1].transform);
        Instantiate(missile, spawnpoints[2].transform);
        animator.SetBool("ready", false);
        ready = false;
    }




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime * .9f;
        if (timer >= goal&&ready==true) 
        {
            animator.SetBool("ready",true);
        }
        
    }
}
