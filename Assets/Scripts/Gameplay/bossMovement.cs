using UnityEngine;

public class bossMovement : MonoBehaviour
{
    public Transform[] movepoints;
    public int tracker;//set to # of movepoints in editor 
    public int points;
    public float speed;
    public float lfireTime;
    public float lCoolDown;
    public Rigidbody2D rb;

    // Update is called once per frame
    void Update()
    {
        
    }
}
