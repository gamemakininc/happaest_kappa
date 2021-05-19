using UnityEngine;

public class launchScript : MonoBehaviour
{
    public Animator anim;
    public int num;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        if (ObserverScript.Instance.defenceMission == false) { Destroy(gameObject); }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void counter() 
    {
        num--;
        if (num <= 0) 
        {
            anim.SetBool("New Bool",true);
        }

    }
    public void kill() { Destroy(gameObject); }
}
