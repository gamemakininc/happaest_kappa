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
		//set new scene
		SceneManager.LoadScene("Combat");
	}
	public void SampleScene()
	{
		//set new scene
		SceneManager.LoadScene("SampleScene");
		
	}
	public void testMenu() 
	{
		SceneManager.LoadScene("test menu");
	}
	public void mainMenu() 
	{
		SceneManager.LoadScene("mainMenu");
	}
	public void briefing()
	{
		SceneManager.LoadScene("briefing");
	}
	public void saveGame()
	{
		SceneManager.LoadScene("saveGame");
	}
}
