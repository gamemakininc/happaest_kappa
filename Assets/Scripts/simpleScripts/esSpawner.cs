
using UnityEngine;

public class esSpawner : MonoBehaviour
{
    public GameObject endScreen;
    public void sWin() 
    {
        //notify end screen
        endScreen.GetComponent<endScreenScript>().win = true;
        //enable end screen
        endScreen.SetActive(true);
    }
    public void sFail() 
    {
        //notify end screen
        endScreen.GetComponent<endScreenScript>().win = false;
        //enable end screen
        endScreen.SetActive(true);
    }
}
