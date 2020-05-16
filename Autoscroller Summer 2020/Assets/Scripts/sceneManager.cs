using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour 
{
	//player output from fitting system
	public int pBulletSelector;
	public float pSpeed;
	public int phealth;
	public int[] pFitSetup;
	//save for player payload slot0-1
	public int pPl0;
	public int pPl1;
	//change scene to 'combat'
	public void Combat() 
	{
		//set local varibles from playerscript
		pBulletSelector = GameObject.Find("Player").GetComponent<PlayerScript>().bulletSelector;
		pSpeed = GameObject.Find("Player").GetComponent<PlayerScript>().MoveSpeed;
		phealth = GameObject.Find("Player").GetComponent<PlayerScript>().health;
		pPl0 = GameObject.Find("Player").GetComponent<PlayerScript>().payload0Selector;
		pPl1 = GameObject.Find("Player").GetComponent<PlayerScript>().payload1Selector;
		//sync local variables to observer
		ObserverScript.Instance.pBulletSelector = pBulletSelector;
		ObserverScript.Instance.pSpeed = pSpeed;
		ObserverScript.Instance.phealth = phealth;
		ObserverScript.Instance.fitSetup = pFitSetup;
		ObserverScript.Instance.pP0 = pPl0;
		ObserverScript.Instance.pP1 = pPl1;
		//set new scene
		SceneManager.LoadScene("Combat");
	}
	public void SampleScene() 
	{
		//set local varibles from playerscript
		pBulletSelector = GameObject.Find("Player").GetComponent<PlayerScript>().bulletSelector;
		pSpeed = GameObject.Find("Player").GetComponent<PlayerScript>().MoveSpeed;
		phealth = GameObject.Find("Player").GetComponent<PlayerScript>().health;
		pPl0 = GameObject.Find("Player").GetComponent<PlayerScript>().payload0Selector;
		pPl1 = GameObject.Find("Player").GetComponent<PlayerScript>().payload1Selector;
		//sync local variables to observer
		ObserverScript.Instance.pBulletSelector = pBulletSelector;
		ObserverScript.Instance.pSpeed = pSpeed;
		ObserverScript.Instance.phealth = phealth;
		ObserverScript.Instance.fitSetup = pFitSetup;
		ObserverScript.Instance.pP0 = pPl0;
		ObserverScript.Instance.pP1 = pPl1;
		//set new scene
		SceneManager.LoadScene("SampleScene");
	}
}
