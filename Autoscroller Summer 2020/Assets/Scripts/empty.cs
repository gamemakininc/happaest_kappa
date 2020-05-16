using UnityEngine;
//kill script *exists
public class empty : MonoBehaviour
{
    //timer
    public float timer;
    // Update is called once per frame
    void Update()
    {
        //incroment timer
        timer += 1.0F * Time.deltaTime;
        //check timer
        if (timer >= 2)
        {
            //game object: *dosn't
            GameObject.Destroy(gameObject);
        }
    }
}
