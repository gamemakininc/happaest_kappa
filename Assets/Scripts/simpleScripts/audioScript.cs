using UnityEngine;

public class audioScript : MonoBehaviour
{
    public int track;
    // Start is called before the first frame update
    void Start()
    {
        mixMaster.Instance.nTrack = track;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
