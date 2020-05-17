using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDragHandler : MonoBehaviour, IDragHandler
{
    public enum Slot { HIGH, LOW, PAYLOAD, GUN };
    public Slot typeOfItem = Slot.HIGH;

    Vector3 startPosition;
    public int itemID;
    private CanvasGroup canvasGroup;
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        canvasGroup.blocksRaycasts = false;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position = startPosition;
        canvasGroup.blocksRaycasts = true;

        /*
         for (int i = 0; i < eventData.hovered.Count; i++)
        {
            if ((eventData.hovered[i].gameObject.tag == "InventorySlots" || eventData.hovered[i].gameObject.tag == "AttackSlots") && eventData.hovered[i].gameObject.transform.childCount == 0)
            {
                transform.SetParent(eventData.hovered[i].gameObject.transform);
                transform.position = eventData.hovered[i].gameObject.transform.position;
                GetComponent<CanvasGroup>().blocksRaycasts = true;
                if (eventData.hovered[i].gameObject.name == "ElementSlot")
                {
                    transform.localScale = eventData.hovered[i].gameObject.transform.localScale * 4.5f;
                } 
                else
                {
                    transform.localScale = eventData.hovered[i].gameObject.transform.localScale * 1.3f;
                }
                return;
            }
        }
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        transform.position = startPosition;
         */
    }
    
    private void OnMouseDown() 
    {
        startPosition = transform.position;
    }
    private void OnMouseUp()
    {
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
