using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDragHandler : MonoBehaviour, IDragHandler 
{
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position = Vector3.zero;

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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
