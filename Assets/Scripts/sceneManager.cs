using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour 
{
	
	//change scene to 'combat'
	public void gameplay()
	{
		//set new scene
		SceneManager.LoadScene("gameplay");
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
	public void hangar()
	{
		SceneManager.LoadScene("hangar");
	}
}
