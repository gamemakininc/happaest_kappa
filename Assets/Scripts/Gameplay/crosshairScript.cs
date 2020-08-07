using UnityEngine;

public class crosshairScript : MonoBehaviour
{
    private Vector3 _target;
    public Camera Camera;
    public float speed = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ObserverScript.Instance.mouseAiming == true)
        {
            _target = Camera.ScreenToWorldPoint(Input.mousePosition);
            _target.z = 0;
            var delta = speed * Time.deltaTime;
            delta *= Vector3.Distance(transform.position, _target);
            transform.position = Vector3.MoveTowards(transform.position, _target, delta);
        }
    }
}
