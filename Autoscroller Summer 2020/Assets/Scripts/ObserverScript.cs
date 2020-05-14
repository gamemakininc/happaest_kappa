using UnityEngine;

public class ObserverScript : MonoBehaviour
{
    public static ObserverScript Instance { get; private set; }
    public int bulletSelector;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else 
        {
            Destroy(gameObject);
        }
    }


}
