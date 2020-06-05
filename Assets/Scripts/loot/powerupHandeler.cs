using UnityEngine;
public class powerupHandeler : MonoBehaviour
{
    public GameObject[] powerUps;
    public int swapint;
    public float involChanceMin= 1;
    public float involChanceMax = 3;
    public float fireRateChanceMin = 4;
    public float fireRateChanceMax = 5;
    public float missileBounusChanceMin = 6;
    public float missileBounusChanceMax = 10;
    public void dropCalcultation()
    {
        if (swapint < involChanceMin && swapint > missileBounusChanceMax) {return; }
        if (swapint >= involChanceMin && swapint <= involChanceMax) { Instantiate(powerUps[1], transform.position, Quaternion.identity); }
        if (swapint >= fireRateChanceMin && swapint <= fireRateChanceMax) { Instantiate(powerUps[2], transform.position, Quaternion.identity); }
        if (swapint >= missileBounusChanceMin && swapint <= missileBounusChanceMax) { Instantiate(powerUps[3], transform.position, Quaternion.identity); }
    }
    private void Start()
    {
        swapint = Random.Range(1, 100);
    }
}