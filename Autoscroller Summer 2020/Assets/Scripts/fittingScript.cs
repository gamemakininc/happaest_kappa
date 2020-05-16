using UnityEngine;

public class fittingScript : MonoBehaviour 
{
	//set bace values
	public float baceMoveSpeed;
	public int bacebulletSelector;
	public int bacePayload0Selector;
	public int bacePayload1Selector;
	public int baceHealth;
	//swap files
	public float MoveSpeed;
	public int bulletSelector;
	public int payload0Selector;
	public int payload1Selector;
	public int health;
	//the secret sauce
	public int[] fitSetup;
	public void Start() 
	{
		fitSetup = ObserverScript.Instance.fitSetup;

	}
	public void SetIcons() 
	{
		//set icons in the wheel 
	}
	public void SetOutputs()
	{
		//aka wall of if statements

	}
	public void Update() 
	{

	}

}
