using UnityEngine;

public class saveMenuGofer : MonoBehaviour
{
    //this script solely exists as a middleman between savescript and the save menu
    savescript SaveS;
    // Start is called before the first frame update
    void Start()
    {
        SaveS = FindObjectOfType<savescript>();
    }
    public void save1() 
    {
        SaveS.saveS1();
    }
    public void save2() 
    {
        SaveS.saveS2();
    }
    public void save3() 
    {
        SaveS.saveS3();
    }
    public void updateMatt() 
    {
        SaveS.setPlaceMats();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
