using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemDragHandler : MonoBehaviour, IDragHandler
{
    //resource check
    public float pgCost;
    public float wgCost;
    //disc variables
    public GameObject nameBox;
    public GameObject descbox;
    public string itemName;
    public string itemDescription;
    //slot type variables
    public enum Slot { HIGH, LOW, PAYLOAD, GUN, SHIP };
    public Slot typeOfItem = Slot.HIGH;
    //needed for reset
    Vector3 startPosition;
    //used to determine item
    public int itemID;
    //??
    private CanvasGroup canvasGroup;

    public void OnDrag(PointerEventData eventData)
    {
        //pickup script
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        canvasGroup.blocksRaycasts = false;

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //return on drop
        transform.position = startPosition;
        canvasGroup.blocksRaycasts = true;
    }
    
    private void OnMouseDown() 
    {
        //set tooltip text boxes to current item info
        nameBox.GetComponent<Text>().text = itemName;
        descbox.GetComponent<Text>().text = itemDescription;
        //set reset point
        startPosition = transform.position;
    }
    private void OnMouseUp()
    {
        //return to reset point
        transform.position = startPosition;
    }
    // Start is called before the first frame update
    void Start()
    {
        canvasGroup = gameObject.GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
