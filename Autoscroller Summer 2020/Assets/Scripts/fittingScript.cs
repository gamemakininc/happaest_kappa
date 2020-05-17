using UnityEngine;

public class fittingScript : MonoBehaviour
{
	//set bace values
	public float baceMoveSpeed = 9f;
	public float baceHealth = 100f;
	public float baceSRegen =0.5f;
	public float baceRepair;
	public float baceShield;
	//swap files
	public float MoveSpeed;
	public int bulletSelector;
	public int payload0Selector;
	public int payload1Selector;
	public float health;
	public float shield;
	public float sRegen;
	public float repair;
	//limmiters
	public int mWeight;
	public int mPower;
	public int Weight;
	public int power;
	public int slotsHigh;
	public int slotsLow;

	//the secret sauce
	//0-4 high slots, 5-9 low slots, 10-11 payload, 12 gun
	//value of 0 for empty slot
	public int[] fitSetup= new int[] {0,0,0,0,0,0,0,0,0,0,0,0,0};
	//a counter
	private int counter = 0;
	
	public void Awake() 
	{
		//set local array to observer array
		fitSetup = ObserverScript.Instance.fitSetup;
		//update values in drop handelers scripts
		while (counter <= 12)
		{
			this.gameObject.transform.GetChild(counter).GetComponentInChildren<itemDropHandeler>().itemId = fitSetup[counter];
			counter++;
		}
	}
	public void SetOutputs()
	{
		//reset counter
		counter = 0;
		//update values in drop handelers scripts
		while (counter <= 12)
		{
			fitSetup[counter] = this.gameObject.transform.GetChild(counter).GetComponentInChildren<itemDropHandeler>().itemId;
			counter++;
		}
		//reset counter
		counter = 0;
		//aka wall of if statements
		//check high slots
		if (fitSetup[counter] == 1) { shildBoost(); }
		else if (fitSetup[counter] == 2) { shildBoost(); }
		else if (fitSetup[counter] == 3) { shildBoost(); }
		else if (fitSetup[counter] == 4) { shieldRegen(); }
		else if (fitSetup[counter] == 5) { shieldRegen(); }
		else if (fitSetup[counter] == 6) { shieldRegen(); }
		counter++;
		if (fitSetup[counter] == 1) { shildBoost(); }
		else if (fitSetup[counter] == 2) { shildBoost(); }
		else if (fitSetup[counter] == 3) { shildBoost(); }
		else if (fitSetup[counter] == 4) { shieldRegen(); }
		else if (fitSetup[counter] == 5) { shieldRegen(); }
		else if (fitSetup[counter] == 6) { shieldRegen(); }
		counter++;
		if (fitSetup[counter] == 1) { shildBoost(); }
		else if (fitSetup[counter] == 2) { shildBoost(); }
		else if (fitSetup[counter] == 3) { shildBoost(); }
		else if (fitSetup[counter] == 4) { shieldRegen(); }
		else if (fitSetup[counter] == 5) { shieldRegen(); }
		else if (fitSetup[counter] == 6) { shieldRegen(); }
		counter++;
		if (fitSetup[counter] == 1) { shildBoost(); }
		else if (fitSetup[counter] == 2) { shildBoost(); }
		else if (fitSetup[counter] == 3) { shildBoost(); }
		else if (fitSetup[counter] == 4) { shieldRegen(); }
		else if (fitSetup[counter] == 5) { shieldRegen(); }
		else if (fitSetup[counter] == 6) { shieldRegen(); }
		counter++;
		if (fitSetup[counter] == 1) { shildBoost(); }
		else if (fitSetup[counter] == 2) { shildBoost(); }
		else if (fitSetup[counter] == 3) { shildBoost(); }
		else if (fitSetup[counter] == 4) { shieldRegen(); }
		else if (fitSetup[counter] == 5) { shieldRegen(); }
		else if (fitSetup[counter] == 6) { shieldRegen(); }
		counter++;
		//check low slots
		if (fitSetup[counter] == 1) { healthBoost(); }
		else if (fitSetup[counter] == 2) { healthBoost(); }
		else if (fitSetup[counter] == 3) { healthBoost(); }
		else if (fitSetup[counter] == 4) { healthRegen(); }
		else if (fitSetup[counter] == 5) { healthRegen(); }
		else if (fitSetup[counter] == 6) { healthRegen(); }
		counter++;
		if (fitSetup[counter] == 1) { healthBoost(); }
		else if (fitSetup[counter] == 2) { healthBoost(); }
		else if (fitSetup[counter] == 3) { healthBoost(); }
		else if (fitSetup[counter] == 4) { healthRegen(); }
		else if (fitSetup[counter] == 5) { healthRegen(); }
		else if (fitSetup[counter] == 6) { healthRegen(); }
		counter++;
		if (fitSetup[counter] == 1) { healthBoost(); }
		else if (fitSetup[counter] == 2) { healthBoost(); }
		else if (fitSetup[counter] == 3) { healthBoost(); }
		else if (fitSetup[counter] == 4) { healthRegen(); }
		else if (fitSetup[counter] == 5) { healthRegen(); }
		else if (fitSetup[counter] == 6) { healthRegen(); }
		counter++;
		if (fitSetup[counter] == 1) { healthBoost(); }
		else if (fitSetup[counter] == 2) { healthBoost(); }
		else if (fitSetup[counter] == 3) { healthBoost(); }
		else if (fitSetup[counter] == 4) { healthRegen(); }
		else if (fitSetup[counter] == 5) { healthRegen(); }
		else if (fitSetup[counter] == 6) { healthRegen(); }
		counter++;
		if (fitSetup[counter] == 1) { healthBoost(); }
		else if (fitSetup[counter] == 2) { healthBoost(); }
		else if (fitSetup[counter] == 3) { healthBoost(); }
		else if (fitSetup[counter] == 4) { healthRegen(); }
		else if (fitSetup[counter] == 5) { healthRegen(); }
		else if (fitSetup[counter] == 6) { healthRegen(); }
		counter++;
		//check payload
		if (fitSetup[counter] == 1) { payload0Selector = 1; }
		else if (fitSetup[counter] == 2) { }
		else if (fitSetup[counter] == 3) { }
		else if (fitSetup[counter] == 4) { }
		else if (fitSetup[counter] == 5) { }
		else if (fitSetup[counter] == 6) { }
		counter++;
		if (fitSetup[counter] == 1) { payload1Selector = 1; }
		else if (fitSetup[counter] == 2) { }
		else if (fitSetup[counter] == 3) { }
		else if (fitSetup[counter] == 4) { }
		else if (fitSetup[counter] == 5) { }
		else if (fitSetup[counter] == 6) { }
		counter++;
		//check gun
		if (fitSetup[counter] == 0) { Debug.Log("error no gun"); }
		else if (fitSetup[counter] == 1) { bulletSelector = 1; }
		else if (fitSetup[counter] == 2) { bulletSelector = 2; }
		else if (fitSetup[counter] == 3) { bulletSelector = 3; }
		else if (fitSetup[counter] == 4) { }
		else if (fitSetup[counter] == 5) { }
		else if (fitSetup[counter] == 6) { }

	}
	void shildBoost() 
	{
		if (fitSetup[counter] == 1) { shield += 15; }
		else if (fitSetup[counter] == 2) { shield += 20; }
		else if (fitSetup[counter] == 3) { shield += 40; }
	}
	void shieldRegen() 
	{
		if (fitSetup[counter] == 4) { sRegen += 1.5f; }
		else if (fitSetup[counter] == 5) { sRegen += 2.0f; }
		else if (fitSetup[counter] == 6) { sRegen += 4.0f; }
	}
	void healthBoost()
	{
		if (fitSetup[counter] == 1) { health += 20; }
		else if (fitSetup[counter] == 2) { health += 30; }
		else if (fitSetup[counter] == 3) { health += 50; }
	}
	void healthRegen()
	{
		if (fitSetup[counter] == 4) { repair += 1f; }
		else if (fitSetup[counter] == 5) { repair += 1.5f; }
		else if (fitSetup[counter] == 6) { repair += 2.0f; }
	}
	public void Update() 
	{

	}

}
