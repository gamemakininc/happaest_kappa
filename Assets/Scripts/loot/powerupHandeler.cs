using UnityEngine;
[System.Serializable]
public class powerup
{
    public powerUps thisLoot;
    public int lootChance;
}

[CreateAssetMenu]
public class powerupHandeler : ScriptableObject
{
    public powerup[] loots;
    public powerUps lootPowerups() 
    {
        int cuProb=0;
        int currentProb = Random.Range(0, 100);
        for (int i = 0; i < loots.Length; i++) 
        {
            cuProb += loots[i].lootChance;
            if (currentProb <= cuProb) 
            {
                return loots[i].thisLoot;
            }
        }
        return null;
    }
}