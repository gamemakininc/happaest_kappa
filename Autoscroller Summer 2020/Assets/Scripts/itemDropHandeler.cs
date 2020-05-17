using UnityEngine;
using UnityEngine.EventSystems;

public class itemDropHandeler : MonoBehaviour, IDropHandler
{
    public Sprite otherSprite;
    public Sprite cSprite;
    public int slotNumber;
    public int itemId;
    public ItemDragHandler.Slot typeOfItem = ItemDragHandler.Slot.HIGH;
    public void OnDrop(PointerEventData eventData)
    {
        ItemDragHandler d = eventData.pointerDrag.GetComponent<ItemDragHandler>();
        if (d != null)
        {
            if (typeOfItem == d.typeOfItem) 
            {
                itemId = eventData.pointerDrag.GetComponent<ItemDragHandler>().itemID;
                otherSprite = eventData.pointerDrag.GetComponent<SpriteRenderer>().sprite;
                this.gameObject.transform.GetChild(0).GetComponentInChildren<SpriteRenderer>().sprite = otherSprite;
            }
        }


    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
