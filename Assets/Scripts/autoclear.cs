using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoclear : MonoBehaviour
{
    private float timer;
    public float killTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += 1 * Time.deltaTime;
        if (timer >= killTime) 
        {
            //remove self
            Destroy(gameObject);
        }
    }
}
