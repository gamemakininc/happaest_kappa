using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour 
{
	//player output from fitting system
	public int pBulletSelector;
	public float pSpeed;
	public float phealth; 
	public float pShield;
	public int[] pFitSetup;
	public float pSRegen;
	public float pRepair;
	//save for player payload slot0-1
	public int pPl0;
	public int pPl1;
	//change scene to 'combat'
	public void Combat() 
	{
		//set local varibles from fitting
		pBulletSelector = GameObject.Find("Player").GetComponent<fittingScript>().bulletSelector;
		pSpeed = GameObject.Find("Player").GetComponent<fittingScript>().MoveSpeed;
		phealth = GameObject.Find("Player").GetComponent<fittingScript>().health;
		pRepair = GameObject.Find("Player").GetComponent<fittingScript>().repair;
		pShield = GameObject.Find("Player").GetComponent<fittingScript>().shield;
		pSRegen = GameObject.Find("Player").GetComponent<fittingScript>().sRegen;
		pPl0 = GameObject.Find("Player").GetComponent<fittingScript>().payload0Selector;
		pPl1 = GameObject.Find("Player").GetComponent<fittingScript>().payload1Selector;
		pFitSetup = GameObject.Find("Player").GetComponent<fittingScript>().fitSetup;
		//sync local variables to observer
		ObserverScript.Instance.pBulletSelector = pBulletSelector;
		ObserverScript.Instance.pSpeed = pSpeed;
		ObserverScript.Instance.pRepair = pRepair;
		ObserverScript.Instance.pHealth = phealth;
		ObserverScript.Instance.pSRegen = pSRegen;
		ObserverScript.Instance.pShield = pShield;
		ObserverScript.Instance.fitSetup = pFitSetup;
		ObserverScript.Instance.pP0 = pPl0;
		ObserverScript.Instance.pP1 = pPl1;
		//set new scene
		SceneManager.LoadScene("Combat");
	}
	public void SampleScene() 
	{
		//set local varibles from fitting
		pBulletSelector = GameObject.Find("Player").GetComponent<fittingScript>().bulletSelector;
		pSpeed = GameObject.Find("Player").GetComponent<fittingScript>().MoveSpeed;
		phealth = GameObject.Find("Player").GetComponent<fittingScript>().health;
		pRepair = GameObject.Find("Player").GetComponent<fittingScript>().repair;
		pShield = GameObject.Find("Player").GetComponent<fittingScript>().shield;
		pSRegen = GameObject.Find("Player").GetComponent<fittingScript>().sRegen;
		pPl0 = GameObject.Find("Player").GetComponent<fittingScript>().payload0Selector;
		pPl1 = GameObject.Find("Player").GetComponent<fittingScript>().payload1Selector;
		pFitSetup = GameObject.Find("Player").GetComponent<fittingScript>().fitSetup;
		//sync local variables to observer
		ObserverScript.Instance.pBulletSelector = pBulletSelector;
		ObserverScript.Instance.pSpeed = pSpeed;
		ObserverScript.Instance.pRepair = pRepair;
		ObserverScript.Instance.pHealth = phealth;
		ObserverScript.Instance.pSRegen = pSRegen;
		ObserverScript.Instance.pShield = pShield;
		ObserverScript.Instance.fitSetup = pFitSetup;
		ObserverScript.Instance.pP0 = pPl0;
		ObserverScript.Instance.pP1 = pPl1;
		//set new scene
		SceneManager.LoadScene("SampleScene");
	}
}
