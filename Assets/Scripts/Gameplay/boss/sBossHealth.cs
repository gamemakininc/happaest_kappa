using UnityEngine;

public class sBossHealth : MonoBehaviour
{
    //set in editor the number of turrets
    public int turretsCurrent;

    //turretscript Die() triggers
    public void updateVarsTurret()
    {
        //remove 1 turret
        turretsCurrent--;
        //check for active turrets
        if (turretsCurrent <= 0)
        {
            //add score to level score
            ObserverScript.Instance.levelScore += 1000;
            //get wave spawner script refrence
            EnemyWavev2 waveSpner = FindObjectOfType<EnemyWavev2>();
            //end level
            waveSpner.OnLevelComplete();
            //tell observer static boss level complete
            ObserverScript.Instance.type3++;
        }
        //debug remove when the boss functions
        Debug.Log("turrets detected: " + turretsCurrent);
    }
}
