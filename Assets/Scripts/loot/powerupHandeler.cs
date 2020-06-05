using UnityEngine;
public class powerupHandeler : MonoBehaviour
{
    public GameObject[] powerUps;
    public int swapint;
    private float involChanceMin= 1;
    private float involChanceMax = 20;
    private float fireRateChanceMin = 21;
    private float fireRateChanceMax = 59;
    private float missileBounusChanceMin = 60;
    private float missileBounusChanceMax = 100;
    public void dropCalcultation()
    {
        if (swapint < involChanceMin && swapint > missileBounusChanceMax) { Instantiate(powerUps[0], transform.position, Quaternion.identity); }
        else if (swapint >= involChanceMin && swapint <= involChanceMax) { Instantiate(powerUps[1], transform.position, Quaternion.identity); }
        else if (swapint >= fireRateChanceMin && swapint <= fireRateChanceMax) { Instantiate(powerUps[2], transform.position, Quaternion.identity); }
        else if (swapint >= missileBounusChanceMin && swapint <= missileBounusChanceMax) { Instantiate(powerUps[3], transform.position, Quaternion.identity); }
    }
    private void Start()
    {
        swapint = Random.Range(1, 1000);
    }
}