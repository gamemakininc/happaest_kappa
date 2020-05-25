using UnityEngine;
using UnityEngine.UI;

public class fittingScript : MonoBehaviour
{
	//set bace values
	public float baceMoveSpeed = 6f;
	public float baceHealth = 100f;
	public float baceSRegen = 0.5f;
	public float baceRepair;
	public float baceShield;
	public float maxPG;
	public float maxWG;
	//swap files
	public float MoveSpeed;
	public int bulletSelector;
	public int payload0Selector;
	public int payload1Selector;
	public float health;
	public float shield;
	public float sRegen;
	public float repair;
	public int mslBonus;
	//limmiters
	public float Weight;
	public float power;
	private float sDebuffSpeed;
	private float sDebuffHpr;
	private float sDebuffShieldr;
	//misc swap files
	public int inputLoc;
	public GameObject[] slotsLoc;
	public Image PGbar;
	public Image WGbar;
	public GameObject pgText;
	public GameObject wgText;

	//the secret sauce
	//0-4 high slots, 5-9 low slots, 10-11 payload, 12 gun , 13 ship
	//value of 0 for empty slot
	public int[] fitSetup = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
	//slot isnt true
	public bool[] slotsfake;
	//a counter
	private int counter = 0;
	
	public void Start()
	{
		//update PG/WG ui elements
		float pgfill = power / maxPG;
		PGbar.fillAmount = pgfill;
		float wgfill = Weight / maxWG;
		WGbar.fillAmount = wgfill;
		wgText.GetComponent<Text>().text = (maxWG + " / " + Weight);
		pgText.GetComponent<Text>().text = (maxPG + " / " + power);
		//set local array to observer array
		fitSetup = ObserverScript.Instance.fitSetup;
	}
	public void input()
	{
		if (inputLoc == 1) { SetOutputs(); }
		else if (inputLoc == 2) { setShip(); }
	}
	public void setShip() 
	{
		fitSetup[13] = slotsLoc[13].GetComponent<itemDropHandeler>().itemId;
		if (fitSetup[13] == 1) { shipOne(); }
		else if (fitSetup[13] == 2) { shipTwo(); }
		else if (fitSetup[13] == 3) { shipThree(); }
		else if (fitSetup[13] == 4) { shipFour(); }
		else if (fitSetup[13] == 5) { shipFive(); }
		else if (fitSetup[13] == 6) { shipSix(); }
	}
	public void SetOutputs()
	{
		//reset counter
		counter = 0;
		//reset variables to bace
		power = maxPG;
		Weight = maxWG;
		health=baceHealth;
		repair=baceRepair;
		shield=baceShield;
		sRegen=baceSRegen;
		MoveSpeed=baceMoveSpeed;
		sDebuffSpeed = 1;
		sDebuffHpr = 1;
		sDebuffShieldr = 1;
		mslBonus = 0;
		//update values in drop handelers scripts
		while (counter <= 12)
		{
			fitSetup[counter] = slotsLoc[counter].GetComponent<itemDropHandeler>().itemId;
			Weight -= slotsLoc[counter].GetComponent<itemDropHandeler>().wgCost;
			power -= slotsLoc[counter].GetComponent<itemDropHandeler>().pgCost;
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
		else if (fitSetup[counter] == 7) { afterburner(); }
		else if (fitSetup[counter] == 8) { afterburner(); }
		else if (fitSetup[counter] == 9) { afterburner(); }
		counter++;
		if (fitSetup[counter] == 1) { shildBoost(); }
		else if (fitSetup[counter] == 2) { shildBoost(); }
		else if (fitSetup[counter] == 3) { shildBoost(); }
		else if (fitSetup[counter] == 4) { shieldRegen(); }
		else if (fitSetup[counter] == 5) { shieldRegen(); }
		else if (fitSetup[counter] == 6) { shieldRegen(); }
		else if (fitSetup[counter] == 7) { afterburner(); }
		else if (fitSetup[counter] == 8) { afterburner(); }
		else if (fitSetup[counter] == 9) { afterburner(); }
		counter++;
		if (fitSetup[counter] == 1) { shildBoost(); }
		else if (fitSetup[counter] == 2) { shildBoost(); }
		else if (fitSetup[counter] == 3) { shildBoost(); }
		else if (fitSetup[counter] == 4) { shieldRegen(); }
		else if (fitSetup[counter] == 5) { shieldRegen(); }
		else if (fitSetup[counter] == 6) { shieldRegen(); }
		else if (fitSetup[counter] == 7) { afterburner(); }
		else if (fitSetup[counter] == 8) { afterburner(); }
		else if (fitSetup[counter] == 9) { afterburner(); }
		counter++;
		if (fitSetup[counter] == 1) { shildBoost(); }
		else if (fitSetup[counter] == 2) { shildBoost(); }
		else if (fitSetup[counter] == 3) { shildBoost(); }
		else if (fitSetup[counter] == 4) { shieldRegen(); }
		else if (fitSetup[counter] == 5) { shieldRegen(); }
		else if (fitSetup[counter] == 6) { shieldRegen(); }
		else if (fitSetup[counter] == 7) { afterburner(); }
		else if (fitSetup[counter] == 8) { afterburner(); }
		else if (fitSetup[counter] == 9) { afterburner(); }
		counter++;
		if (fitSetup[counter] == 1) { shildBoost(); }
		else if (fitSetup[counter] == 2) { shildBoost(); }
		else if (fitSetup[counter] == 3) { shildBoost(); }
		else if (fitSetup[counter] == 4) { shieldRegen(); }
		else if (fitSetup[counter] == 5) { shieldRegen(); }
		else if (fitSetup[counter] == 6) { shieldRegen(); }
		else if (fitSetup[counter] == 7) { afterburner(); }
		else if (fitSetup[counter] == 8) { afterburner(); }
		else if (fitSetup[counter] == 9) { afterburner(); }
		counter++;
		//check low slots
		sDebuffSpeed = 1;
		if (fitSetup[counter] == 1) { healthBoost(); }
		else if (fitSetup[counter] == 2) { healthBoost(); }
		else if (fitSetup[counter] == 3) { healthBoost(); }
		else if (fitSetup[counter] == 4) { healthRegen(); }
		else if (fitSetup[counter] == 5) { healthRegen(); }
		else if (fitSetup[counter] == 6) { healthRegen(); }
		else if (fitSetup[counter] == 7) { fuel(); }
		else if (fitSetup[counter] == 8) { fuel(); }
		else if (fitSetup[counter] == 9) { fuel(); }
		else if (fitSetup[counter] == 10) { mslBonus += 3; }
		else if (fitSetup[counter] == 11) { mslBonus += 6; }
		else if (fitSetup[counter] == 12) { mslBonus += 12; }
		counter++;
		if (fitSetup[counter] == 1) { healthBoost(); }
		else if (fitSetup[counter] == 2) { healthBoost(); }
		else if (fitSetup[counter] == 3) { healthBoost(); }
		else if (fitSetup[counter] == 4) { healthRegen(); }
		else if (fitSetup[counter] == 5) { healthRegen(); }
		else if (fitSetup[counter] == 6) { healthRegen(); }
		else if (fitSetup[counter] == 7) { fuel(); }
		else if (fitSetup[counter] == 8) { fuel(); }
		else if (fitSetup[counter] == 9) { fuel(); }
		else if (fitSetup[counter] == 10) { mslBonus += 3; }
		else if (fitSetup[counter] == 11) { mslBonus += 6; }
		else if (fitSetup[counter] == 12) { mslBonus += 12; }
		counter++;
		if (fitSetup[counter] == 1) { healthBoost(); }
		else if (fitSetup[counter] == 2) { healthBoost(); }
		else if (fitSetup[counter] == 3) { healthBoost(); }
		else if (fitSetup[counter] == 4) { healthRegen(); }
		else if (fitSetup[counter] == 5) { healthRegen(); }
		else if (fitSetup[counter] == 6) { healthRegen(); }
		else if (fitSetup[counter] == 7) { fuel(); }
		else if (fitSetup[counter] == 8) { fuel(); }
		else if (fitSetup[counter] == 9) { fuel(); }
		else if (fitSetup[counter] == 10) { mslBonus += 3; }
		else if (fitSetup[counter] == 11) { mslBonus += 6; }
		else if (fitSetup[counter] == 12) { mslBonus += 12; }
		counter++;
		if (fitSetup[counter] == 1) { healthBoost(); }
		else if (fitSetup[counter] == 2) { healthBoost(); }
		else if (fitSetup[counter] == 3) { healthBoost(); }
		else if (fitSetup[counter] == 4) { healthRegen(); }
		else if (fitSetup[counter] == 5) { healthRegen(); }
		else if (fitSetup[counter] == 6) { healthRegen(); }
		else if (fitSetup[counter] == 7) { fuel(); }
		else if (fitSetup[counter] == 8) { fuel(); }
		else if (fitSetup[counter] == 9) { fuel(); }
		else if (fitSetup[counter] == 10) { mslBonus += 3; }
		else if (fitSetup[counter] == 11) { mslBonus += 6; }
		else if (fitSetup[counter] == 12) { mslBonus += 12; }
		counter++;
		if (fitSetup[counter] == 1) { healthBoost(); }
		else if (fitSetup[counter] == 2) { healthBoost(); }
		else if (fitSetup[counter] == 3) { healthBoost(); }
		else if (fitSetup[counter] == 4) { healthRegen(); }
		else if (fitSetup[counter] == 5) { healthRegen(); }
		else if (fitSetup[counter] == 6) { healthRegen(); }
		else if (fitSetup[counter] == 7) { fuel(); }
		else if (fitSetup[counter] == 8) { fuel(); }
		else if (fitSetup[counter] == 9) { fuel(); }
		else if (fitSetup[counter] == 10) { mslBonus += 3; }
		else if (fitSetup[counter] == 11) { mslBonus += 6; }
		else if (fitSetup[counter] == 12) { mslBonus += 12; }
		counter++;
		//check payload
		if (fitSetup[counter] == 1) { payload0Selector = 1; }
		else if (fitSetup[counter] == 2) { payload0Selector = 2; }
		else if (fitSetup[counter] == 3) { payload0Selector = 3; }
		else if (fitSetup[counter] == 4) { }
		else if (fitSetup[counter] == 5) { }
		else if (fitSetup[counter] == 6) { }
		counter++;
		if (fitSetup[counter] == 1) { payload1Selector = 1; }
		else if (fitSetup[counter] == 2) { payload1Selector = 2; }
		else if (fitSetup[counter] == 3) { payload1Selector = 3; }
		else if (fitSetup[counter] == 4) { }
		else if (fitSetup[counter] == 5) { }
		else if (fitSetup[counter] == 6) { }
		counter++;
		//check gun
		if (fitSetup[counter] == 0) { Debug.Log("error no gun"); }
		else if (fitSetup[counter] == 1) { bulletSelector = 1; }
		else if (fitSetup[counter] == 2) { bulletSelector = 2; }
		else if (fitSetup[counter] == 3) { bulletSelector = 3; }
		else if (fitSetup[counter] == 4) { bulletSelector = 4; }
		else if (fitSetup[counter] == 5) { bulletSelector = 5; }
		else if (fitSetup[counter] == 6) { bulletSelector = 6; }

		//update PG/WG ui elements
		float pgfill = power / maxPG;
		PGbar.fillAmount = pgfill;
		float wgfill = Weight / maxWG;
		WGbar.fillAmount = wgfill;
		wgText.GetComponent<Text>().text =(maxWG + " / " + Weight);
		pgText.GetComponent<Text>().text =(maxPG + " / " + power);

		//output to observer
		ObserverScript.Instance.fitSetup = fitSetup;
		ObserverScript.Instance.pSpeed = MoveSpeed;
		ObserverScript.Instance.pRepair = repair;
		ObserverScript.Instance.pHealth = health;
		ObserverScript.Instance.pSRegen = sRegen;
		ObserverScript.Instance.pShield = shield;
		ObserverScript.Instance.pBulletSelector = bulletSelector;
		ObserverScript.Instance.pP0 = payload0Selector;
		ObserverScript.Instance.pP1 = payload1Selector;
		ObserverScript.Instance.mslBonus = mslBonus;
	}
	void shildBoost() 
	{
		if (fitSetup[counter] == 1) { shield += 15; }
		else if (fitSetup[counter] == 2) { shield += 20; }
		else if (fitSetup[counter] == 3) { shield += 40; }
	}
	void shieldRegen() 
	{
		if (fitSetup[counter] == 4) { sRegen += 1.5f  *sDebuffShieldr; sDebuffShieldr -= .15f; }
		else if (fitSetup[counter] == 5) { sRegen += 2.0f * sDebuffShieldr; sDebuffShieldr -= .15f; }
		else if (fitSetup[counter] == 6) { sRegen += 4.0f * sDebuffShieldr; sDebuffShieldr -= .15f; }
	}
	void healthBoost()
	{
		if (fitSetup[counter] == 1) { health +=20; }
		else if (fitSetup[counter] == 2) { health +=25; }
		else if (fitSetup[counter] == 3) { health +=50; }
	}
	void healthRegen()
	{
		if (fitSetup[counter] == 4) { repair += 1f * sDebuffHpr; sDebuffHpr -= .15f; }
		else if (fitSetup[counter] == 5) { repair += 1.5f * sDebuffHpr; sDebuffHpr -= .15f; }
		else if (fitSetup[counter] == 6) { repair += 2.0f * sDebuffHpr; sDebuffHpr -= .15f; }
	}
	void afterburner() 
	{
		if (fitSetup[counter] == 7) { MoveSpeed = 1 * sDebuffSpeed; sDebuffSpeed -= 0.15f; }
		else if (fitSetup[counter] == 8) { MoveSpeed = 2 * sDebuffSpeed; sDebuffSpeed -= 0.15f; }
		else if (fitSetup[counter] == 9) { MoveSpeed = 3 * sDebuffSpeed; sDebuffSpeed -= 0.15f; }
	}
	void fuel() 
	{
		if (fitSetup[counter] == 7) { MoveSpeed = 0.5f * sDebuffSpeed; sDebuffSpeed -= 0.15f; }
		else if (fitSetup[counter] == 8) { MoveSpeed = 1.5f * sDebuffSpeed; sDebuffSpeed -= 0.15f; }
		else if (fitSetup[counter] == 9) { MoveSpeed = 2.5f * sDebuffSpeed; sDebuffSpeed -= 0.15f; }
	}
	void shipOne() 
	{
		slotsfake[0] = false;
		slotsfake[1] = true;
		slotsfake[2] = true;
		slotsfake[3] = true;
		slotsfake[4] = true;
		slotsfake[5] = false;
		slotsfake[6] = true;
		slotsfake[7] = true;
		slotsfake[8] = true;
		slotsfake[9] = true;
		slotsfake[10] = true;
		slotsfake[11] = true;
		slotsfake[12] = false;
		counter = 0;
		//update slots and clear fitted items
		while (counter <= 12)
		{
			slotsLoc[counter].GetComponent<itemDropHandeler>().slotNull = slotsfake[counter];
			slotsLoc[counter].GetComponent<itemDropHandeler>().slotNeedUpdate = true;
			counter++;
			Debug.Log(counter);
		}
		//set bace values
		bulletSelector = 1;
		baceMoveSpeed = 6f;
		baceHealth = 99f;
		baceSRegen = 0.4f;
		baceRepair = 1;
		baceShield = 1;
		maxPG = 15 ;
		maxWG = 15 ;
		power = maxPG;
		Weight = maxWG;
		//update PG/WG ui elements
		float pgfill = power / maxPG;
		PGbar.fillAmount = pgfill;
		float wgfill = Weight / maxWG;
		WGbar.fillAmount = wgfill;
		wgText.GetComponent<Text>().text = (maxWG + " / " + Weight);
		pgText.GetComponent<Text>().text = (maxPG + " / " + power);
	}
	void shipTwo() 
	{

	}
	void shipThree()
	{

	}
	void shipFour()
	{

	}
	void shipFive()
	{

	}
	void shipSix()
	{

	}

	public void Update() 
	{

	}

}
