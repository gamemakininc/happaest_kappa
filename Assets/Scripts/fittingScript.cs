using UnityEngine;
using UnityEngine.UI;

public class fittingScript : MonoBehaviour
{
	//set bace values
	private float baceERefireRate = 0.50f;
	private float baceRefireRate = 0.40f;
	private float baceMoveSpeed = 8f;
	public float baceHealth = 100f;
	public float baceSRegen = 0.5f;
	public float baceRepair;
	public float baceShield;
	public float maxPG;
	public float maxWG;
	//swap files
	public float erefireRate;
	public float refireRate;
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
	//output variables
	public GameObject healthOutput;
	public GameObject regenOutput;
	public GameObject p0AmmoOutput;
	public GameObject p1AmmoOutput;
	public Image PGbar;
	public Image WGbar;
	public GameObject pgText;
	public GameObject wgText;
	public GameObject speedInfo;
	public float p0ammocount;
	public float p1ammocount;

	//the secret sauce
	//0-4 high slots, 5-9 low slots, 10-11 payload, 12 gun , 13 ship
	//value of 0 for empty slot
	public int[] fitSetup = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
	//slot isnt true
	public bool[] slotsfake=new bool[] { true, true, true, true, true, true, true, true, true, true, true, true, false, };
	//a counter
	private int counter = 0;
	
	public void Start()
	{

		mixMaster.Instance.nTrack = 3;

		slotsfake[0] = true;
		slotsfake[1] = true;
		slotsfake[2] = true;
		slotsfake[3] = true;
		slotsfake[4] = true;
		slotsfake[5] = true;
		slotsfake[6] = true;
		slotsfake[7] = true;
		slotsfake[8] = true;
		slotsfake[9] = true;
		slotsfake[10] = true;
		slotsfake[11] = true;
		slotsfake[12] = true;
		counter = 0;
		//update slots and clear fitted items
		while (counter <= 12)
		{
			slotsLoc[counter].GetComponent<itemDropHandeler>().slotNull = slotsfake[counter];
			slotsLoc[counter].GetComponent<itemDropHandeler>().slotNeedUpdate = true;
			counter++;
		}
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
		else if (fitSetup[13] == 7) { secritShipOne(); }
		else if (fitSetup[13] == 8) { secritShipTwo(); }
	}
	public void SetOutputs()
	{
		//reset counter
		counter = 0;
		//reset variables to bace
		p0ammocount = 0;
		p1ammocount = 0;
		power = maxPG;
		Weight = maxWG;
		health=baceHealth;
		repair=baceRepair;
		shield=baceShield;
		sRegen=baceSRegen;
		MoveSpeed=baceMoveSpeed;
		refireRate = baceRefireRate;
		erefireRate = baceERefireRate;
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
		else if (fitSetup[counter] == 10) { refireRate += 0.05f; erefireRate += 0.02f; }
		else if (fitSetup[counter] == 11) { refireRate += 0.05f; erefireRate += 0.1f; }
		else if (fitSetup[counter] == 12) { refireRate += 0.1f; erefireRate += 0.1f; }
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
		else if (fitSetup[counter] == 10) { refireRate += 0.05f; erefireRate += 0.02f; }
		else if (fitSetup[counter] == 11) { refireRate += 0.05f; erefireRate += 0.1f; }
		else if (fitSetup[counter] == 12) { refireRate += 0.1f; erefireRate += 0.1f; }
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
		else if (fitSetup[counter] == 10) { refireRate += 0.05f; erefireRate += 0.02f; }
		else if (fitSetup[counter] == 11) { refireRate += 0.05f; erefireRate += 0.1f; }
		else if (fitSetup[counter] == 12) { refireRate += 0.1f; erefireRate += 0.1f; }
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
		else if (fitSetup[counter] == 10) { refireRate += 0.05f; erefireRate += 0.02f; }
		else if (fitSetup[counter] == 11) { refireRate += 0.05f; erefireRate += 0.1f; }
		else if (fitSetup[counter] == 12) { refireRate += 0.1f; erefireRate += 0.1f; }
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
		else if (fitSetup[counter] == 10) { refireRate += 0.05f; erefireRate += 0.02f; }
		else if (fitSetup[counter] == 11) { refireRate += 0.05f; erefireRate += 0.1f; }
		else if (fitSetup[counter] == 12) { refireRate += 0.1f; erefireRate += 0.1f; }
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
		else if (fitSetup[counter] == 10) { mslBonus += 3; p0ammocount += 3; p1ammocount += 3; }
		else if (fitSetup[counter] == 11) { mslBonus += 6; p0ammocount += 6; p1ammocount += 6; }
		else if (fitSetup[counter] == 12) { mslBonus += 12; p0ammocount += 12; p1ammocount += 12; }
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
		else if (fitSetup[counter] == 10) { mslBonus += 3; p0ammocount += 3; p1ammocount += 3; }
		else if (fitSetup[counter] == 11) { mslBonus += 6; p0ammocount += 6; p1ammocount += 6; }
		else if (fitSetup[counter] == 12) { mslBonus += 12; p0ammocount += 12; p1ammocount += 12; }
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
		else if (fitSetup[counter] == 10) { mslBonus += 3; p0ammocount += 3; p1ammocount += 3; }
		else if (fitSetup[counter] == 11) { mslBonus += 6; p0ammocount += 6; p1ammocount += 6; }
		else if (fitSetup[counter] == 12) { mslBonus += 12; p0ammocount += 12; p1ammocount += 12; }
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
		else if (fitSetup[counter] == 10) { mslBonus += 3; p0ammocount += 3; p1ammocount += 3; }
		else if (fitSetup[counter] == 11) { mslBonus += 6; p0ammocount += 6; p1ammocount += 6; }
		else if (fitSetup[counter] == 12) { mslBonus += 12; p0ammocount += 12; p1ammocount += 12; }
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
		else if (fitSetup[counter] == 10) { mslBonus += 3; p0ammocount += 3; p1ammocount += 3; }
		else if (fitSetup[counter] == 11) { mslBonus += 6; p0ammocount += 6; p1ammocount += 6; }
		else if (fitSetup[counter] == 12) { mslBonus += 12; p0ammocount += 12; p1ammocount += 12; }
		counter++;
		//check payload
		if (fitSetup[counter] == 1) { payload0Selector = 1; p0ammocount += 20; }
		else if (fitSetup[counter] == 2) { payload0Selector = 2; p0ammocount += 15; }
		else if (fitSetup[counter] == 3) { payload0Selector = 3; p0ammocount += 10; }
		else if (fitSetup[counter] == 4) { }
		else if (fitSetup[counter] == 5) { }
		else if (fitSetup[counter] == 6) { }
		counter++;
		if (fitSetup[counter] == 1) { payload1Selector = 1; p0ammocount += 20; }
		else if (fitSetup[counter] == 2) { payload1Selector = 2; p0ammocount += 15; }
		else if (fitSetup[counter] == 3) { payload1Selector = 3; p0ammocount += 10; }
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
		wgText.GetComponent<Text>().text = (maxWG + " / " + Weight);
		pgText.GetComponent<Text>().text = (maxPG + " / " + power);
		p0AmmoOutput.GetComponent<Text>().text = (p0ammocount + "/"+ p0ammocount);
		p1AmmoOutput.GetComponent<Text>().text = (p1ammocount + "/"+ p1ammocount);
		healthOutput.GetComponent<Text>().text = ("hull:"+health + "  rep rate:" + repair);
		regenOutput.GetComponent<Text>().text = ("shields:" + shield +" boost rate:"+sRegen);
		speedInfo.GetComponent<Text>().text = ("speed:"+MoveSpeed);


		//output to observer
		ObserverScript.Instance.efireRate = erefireRate;
		ObserverScript.Instance.fireRate = refireRate;
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
		slotsfake[0] = true;
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
		}
		//set bace values
		bulletSelector = 1;
		baceMoveSpeed = 6f;
		baceHealth = 100f;
		baceSRegen = 0.4f;
		baceRepair = 0;
		baceShield = 0;
		maxPG = 15 ;
		maxWG = 13 ;
		power = maxPG;
		Weight = maxWG;
		fitSetup[12] = bulletSelector;
		//push gun selection and set sprite
		slotsLoc[12].GetComponent<itemDropHandeler>().itemId = bulletSelector;
		slotsLoc[12].GetComponent<itemDropHandeler>().updateSprite();

		//update PG/WG ui elements
		float pgfill = power / maxPG;
		PGbar.fillAmount = pgfill;
		float wgfill = Weight / maxWG;
		WGbar.fillAmount = wgfill;
		
		wgText.GetComponent<Text>().text = (maxWG + " / " + Weight);
		pgText.GetComponent<Text>().text = (maxPG + " / " + power);
		healthOutput.GetComponent<Text>().text = ("hull:" + baceHealth + "  rep rate:" + baceRepair);
		regenOutput.GetComponent<Text>().text = ("shields:" + baceShield + " boost rate:" + baceSRegen);
		speedInfo.GetComponent<Text>().text = ("speed:" + baceMoveSpeed);
	}
	void shipTwo() 
	{
		slotsfake[0] = false;
		slotsfake[1] = true;
		slotsfake[2] = true;
		slotsfake[3] = true;
		slotsfake[4] = true;
		slotsfake[5] = true;
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
		}
		//set bace values
		bulletSelector = 4;
		baceMoveSpeed = 6f;
		baceHealth = 100f;
		baceSRegen = 0.4f;
		baceRepair = 0;
		baceShield = 0;
		maxPG = 15;
		maxWG = 14;
		power = maxPG;
		Weight = maxWG;
		fitSetup[12] = bulletSelector;
		//push gun selection and set sprite
		slotsLoc[12].GetComponent<itemDropHandeler>().itemId = bulletSelector;
		slotsLoc[12].GetComponent<itemDropHandeler>().updateSprite();

		//update PG/WG ui elements
		float pgfill = power / maxPG;
		PGbar.fillAmount = pgfill;
		float wgfill = Weight / maxWG;
		WGbar.fillAmount = wgfill;
		wgText.GetComponent<Text>().text = (maxWG + " / " + Weight);
		pgText.GetComponent<Text>().text = (maxPG + " / " + power);
		healthOutput.GetComponent<Text>().text = ("hull:" + baceHealth + "  rep rate:" + baceRepair);
		regenOutput.GetComponent<Text>().text = ("shields:" + baceShield + " boost rate:" + baceSRegen);
		speedInfo.GetComponent<Text>().text = ("speed:" + baceMoveSpeed);
	}
	void shipThree()
	{
		slotsfake[0] = false;
		slotsfake[1] = true;
		slotsfake[2] = true;
		slotsfake[3] = true;
		slotsfake[4] = true;
		slotsfake[5] = false;
		slotsfake[6] = false;
		slotsfake[7] = true;
		slotsfake[8] = true;
		slotsfake[9] = true;
		slotsfake[10] = false;
		slotsfake[11] = true;
		slotsfake[12] = false;
		counter = 0;
		//update slots and clear fitted items
		while (counter <= 12)
		{
			slotsLoc[counter].GetComponent<itemDropHandeler>().slotNull = slotsfake[counter];
			slotsLoc[counter].GetComponent<itemDropHandeler>().slotNeedUpdate = true;
			counter++;
		}
		//set bace values
		bulletSelector = 2;
		baceMoveSpeed = 6f;
		baceHealth = 99f;
		baceSRegen = 0.4f;
		baceRepair = 0;
		baceShield = 0;
		maxPG = 24;
		maxWG = 20;
		power = maxPG;
		Weight = maxWG;
		fitSetup[12] = bulletSelector;
		slotsLoc[12].GetComponent<itemDropHandeler>().itemId = bulletSelector;

		//update PG/WG ui elements
		float pgfill = power / maxPG;
		PGbar.fillAmount = pgfill;
		float wgfill = Weight / maxWG;
		WGbar.fillAmount = wgfill;
		wgText.GetComponent<Text>().text = (maxWG + " / " + Weight);
		pgText.GetComponent<Text>().text = (maxPG + " / " + power);
		healthOutput.GetComponent<Text>().text = ("hull:" + baceHealth + "  rep rate:" + baceRepair);
		regenOutput.GetComponent<Text>().text = ("shields:" + baceShield + " boost rate:" + baceSRegen);
		speedInfo.GetComponent<Text>().text = ("speed:" + baceMoveSpeed);
	}
	void shipFour()
	{
		slotsfake[0] = false;
		slotsfake[1] = false;
		slotsfake[2] = true;
		slotsfake[3] = true;
		slotsfake[4] = true;
		slotsfake[5] = false;
		slotsfake[6] = true;
		slotsfake[7] = true;
		slotsfake[8] = true;
		slotsfake[9] = true;
		slotsfake[10] = false;
		slotsfake[11] = true;
		slotsfake[12] = false;
		counter = 0;
		//update slots and clear fitted items
		while (counter <= 12)
		{
			slotsLoc[counter].GetComponent<itemDropHandeler>().slotNull = slotsfake[counter];
			slotsLoc[counter].GetComponent<itemDropHandeler>().slotNeedUpdate = true;
			counter++;
		}
		//set bace values
		bulletSelector = 5;
		baceMoveSpeed = 6f;
		baceHealth = 50f;
		baceSRegen = 2f;
		baceRepair = 0;
		baceShield = 100;
		maxPG = 20;
		maxWG = 24;
		power = maxPG;
		Weight = maxWG;
		fitSetup[12] = bulletSelector;
		//push gun selection and set sprite
		slotsLoc[12].GetComponent<itemDropHandeler>().itemId = bulletSelector;
		slotsLoc[12].GetComponent<itemDropHandeler>().updateSprite();

		//update PG/WG ui elements
		float pgfill = power / maxPG;
		PGbar.fillAmount = pgfill;
		float wgfill = Weight / maxWG;
		WGbar.fillAmount = wgfill;
		wgText.GetComponent<Text>().text = (maxWG + " / " + Weight);
		pgText.GetComponent<Text>().text = (maxPG + " / " + power);
		healthOutput.GetComponent<Text>().text = ("hull:" + baceHealth + "  rep rate:" + baceRepair);
		regenOutput.GetComponent<Text>().text = ("shields:" + baceShield + " boost rate:" + baceSRegen);
		speedInfo.GetComponent<Text>().text = ("speed:" + baceMoveSpeed);
	}
	void shipFive()
	{
		slotsfake[0] = false;
		slotsfake[1] = false;
		slotsfake[2] = true;
		slotsfake[3] = true;
		slotsfake[4] = true;
		slotsfake[5] = false;
		slotsfake[6] = false;
		slotsfake[7] = false;
		slotsfake[8] = false;
		slotsfake[9] = true;
		slotsfake[10] = false;
		slotsfake[11] = false;
		slotsfake[12] = false;
		counter = 0;
		//update slots and clear fitted items
		while (counter <= 12)
		{
			slotsLoc[counter].GetComponent<itemDropHandeler>().slotNull = slotsfake[counter];
			slotsLoc[counter].GetComponent<itemDropHandeler>().slotNeedUpdate = true;
			counter++;
		}
		//set bace values
		bulletSelector = 3;
		baceMoveSpeed = 6f;
		baceHealth = 100f;
		baceSRegen = 0.4f;
		baceRepair = 0;
		baceShield = 20;
		maxPG = 40;
		maxWG = 45;
		power = maxPG;
		Weight = maxWG;
		fitSetup[12] = bulletSelector;
		//push gun selection and set sprite
		slotsLoc[12].GetComponent<itemDropHandeler>().itemId = bulletSelector;
		slotsLoc[12].GetComponent<itemDropHandeler>().updateSprite();

		//update PG/WG ui elements
		float pgfill = power / maxPG;
		PGbar.fillAmount = pgfill;
		float wgfill = Weight / maxWG;
		WGbar.fillAmount = wgfill;
		wgText.GetComponent<Text>().text = (maxWG + " / " + Weight);
		pgText.GetComponent<Text>().text = (maxPG + " / " + power);
		healthOutput.GetComponent<Text>().text = ("hull:" + baceHealth + "  rep rate:" + baceRepair);
		regenOutput.GetComponent<Text>().text = ("shields:" + baceShield + " boost rate:" + baceSRegen);
		speedInfo.GetComponent<Text>().text = ("speed:" + baceMoveSpeed);
	}
	void shipSix()
	{
		slotsfake[0] = false;
		slotsfake[1] = false;
		slotsfake[2] = false;
		slotsfake[3] = false;
		slotsfake[4] = true;
		slotsfake[5] = false;
		slotsfake[6] = false;
		slotsfake[7] = true;
		slotsfake[8] = true;
		slotsfake[9] = true;
		slotsfake[10] = false;
		slotsfake[11] = false;
		slotsfake[12] = false;
		counter = 0;
		//update slots and clear fitted items
		while (counter <= 12)
		{
			slotsLoc[counter].GetComponent<itemDropHandeler>().slotNull = slotsfake[counter];
			slotsLoc[counter].GetComponent<itemDropHandeler>().slotNeedUpdate = true;
			counter++;
		}
		//set bace values
		bulletSelector = 6;
		baceMoveSpeed = 7f;
		baceHealth = 120f;
		baceSRegen = 0.4f;
		baceRepair = 0;
		baceShield = 40;
		maxPG = 45;
		maxWG = 40;
		power = maxPG;
		Weight = maxWG;
		fitSetup[12] = bulletSelector;
		//push gun selection and set sprite
		slotsLoc[12].GetComponent<itemDropHandeler>().itemId = bulletSelector;
		slotsLoc[12].GetComponent<itemDropHandeler>().updateSprite();

		//update PG/WG ui elements
		float pgfill = power / maxPG;
		PGbar.fillAmount = pgfill;
		float wgfill = Weight / maxWG;
		WGbar.fillAmount = wgfill;
		wgText.GetComponent<Text>().text = (maxWG + " / " + Weight);
		pgText.GetComponent<Text>().text = (maxPG + " / " + power);
		healthOutput.GetComponent<Text>().text = ("hull:" + baceHealth + "  rep rate:" + baceRepair);
		regenOutput.GetComponent<Text>().text = ("shields:" + baceShield + " boost rate:" + baceSRegen);
		speedInfo.GetComponent<Text>().text = ("speed:" + baceMoveSpeed);
	}
	void secritShipTwo()
	{
		slotsfake[0] = false;
		slotsfake[1] = false;
		slotsfake[2] = false;
		slotsfake[3] = false;
		slotsfake[4] = false;
		slotsfake[5] = false;
		slotsfake[6] = false;
		slotsfake[7] = false;
		slotsfake[8] = false;
		slotsfake[9] = false;
		slotsfake[10] = false;
		slotsfake[11] = false;
		slotsfake[12] = false;
		counter = 0;
		//update slots and clear fitted items
		while (counter <= 12)
		{
			slotsLoc[counter].GetComponent<itemDropHandeler>().slotNull = slotsfake[counter];
			slotsLoc[counter].GetComponent<itemDropHandeler>().slotNeedUpdate = true;
			counter++;
		}
		//set bace values
		bulletSelector = 6;
		baceMoveSpeed = 7f;
		baceHealth = 100f;
		baceSRegen = 1f;
		baceRepair = 1;
		baceShield = 100;
		maxPG = 60;
		maxWG = 65;
		power = maxPG;
		Weight = maxWG;
		fitSetup[12] = bulletSelector;
		//push gun selection and set sprite
		slotsLoc[12].GetComponent<itemDropHandeler>().itemId = bulletSelector;
		slotsLoc[12].GetComponent<itemDropHandeler>().updateSprite();

		//update PG/WG ui elements
		float pgfill = power / maxPG;
		PGbar.fillAmount = pgfill;
		float wgfill = Weight / maxWG;
		WGbar.fillAmount = wgfill;
		wgText.GetComponent<Text>().text = (maxWG + " / " + Weight);
		pgText.GetComponent<Text>().text = (maxPG + " / " + power);
		healthOutput.GetComponent<Text>().text = ("hull:" + baceHealth + "  rep rate:" + baceRepair);
		regenOutput.GetComponent<Text>().text = ("shields:" + baceShield + " boost rate:" + baceSRegen);
		speedInfo.GetComponent<Text>().text = ("speed:" + baceMoveSpeed);
	}
	void secritShipOne()
	{
		slotsfake[0] = false;
		slotsfake[1] = false;
		slotsfake[2] = false;
		slotsfake[3] = false;
		slotsfake[4] = false;
		slotsfake[5] = false;
		slotsfake[6] = false;
		slotsfake[7] = false;
		slotsfake[8] = false;
		slotsfake[9] = false;
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
		}
		//set bace values
		bulletSelector = 6;
		baceMoveSpeed = 7f;
		baceHealth = 100f;
		baceSRegen = 2f;
		baceRepair = 2;
		baceShield = 100;
		maxPG = 60;
		maxWG = 65;
		power = maxPG;
		Weight = maxWG;
		fitSetup[12] = bulletSelector;
		//push gun selection and set sprite
		slotsLoc[12].GetComponent<itemDropHandeler>().itemId = bulletSelector;
		slotsLoc[12].GetComponent<itemDropHandeler>().updateSprite();

		//update PG/WG ui elements
		float pgfill = power / maxPG;
		PGbar.fillAmount = pgfill;
		float wgfill = Weight / maxWG;
		WGbar.fillAmount = wgfill;
		wgText.GetComponent<Text>().text = (maxWG + " / " + Weight);
		pgText.GetComponent<Text>().text = (maxPG + " / " + power);
		healthOutput.GetComponent<Text>().text = ("hull:" + baceHealth + "  rep rate:" + baceRepair);
		regenOutput.GetComponent<Text>().text = ("shields:" + baceShield + " boost rate:" + baceSRegen);
		speedInfo.GetComponent<Text>().text = ("speed:" + baceMoveSpeed);
	}
	public void Update() 
	{

	}

}
