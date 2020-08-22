using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gofer : MonoBehaviour
{
    private savescript ss;
    private void Start()
    {
        ss = FindObjectOfType<savescript>();
    }
    //gobetween for load script
    public void load1() 
    {
        ss.loadS1();
    }
    public void load2()
    {
        ss.loadS2();
    }
    public void load3()
    {
        ss.loadS3();
    }
}
