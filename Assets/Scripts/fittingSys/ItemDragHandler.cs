using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemDragHandler : MonoBehaviour, IDragHandler
{
    //resource check
    public float[] placeholder;//should hold pg/wg costs in case of reset
    public float pgCost;
    public float wgCost;
    //disc variables
    public GameObject costBox;
    public GameObject nameBox;
    public GameObject descbox;
    public string itemName;
    public string itemDescription;
    //slot type variables
    public enum Slot { HIGH, LOW, PAYLOAD, GUN, SHIP };
    public Slot typeOfItem;
    //needed for reset
    Vector3 startPosition;
    //used to determine item
    public int itemIdentifyer;
    public int itemID;
    //??
    private CanvasGroup canvasGroup;

    public void OnDrag(PointerEventData eventData)
    {
        if (ObserverScript.Instance.unlocks[itemIdentifyer] == true)
        {
            if (itemIdentifyer == 34) { GetComponent<SpriteRenderer>().enabled = true; GetComponent<CircleCollider2D>().enabled = true; }
            if (itemIdentifyer == 35) { GetComponent<SpriteRenderer>().enabled = true; GetComponent<CircleCollider2D>().enabled = true; }
            if (itemIdentifyer == 36) { GetComponent<SpriteRenderer>().enabled = true; GetComponent<CircleCollider2D>().enabled = true; }
            //pickup script
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
            canvasGroup.blocksRaycasts = false;

        }

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //return on drop
        transform.position = startPosition;
        canvasGroup.blocksRaycasts = true;
    }
    
    private void OnMouseDown() 
    {
        //set reset point
        startPosition = transform.position;
        //set tooltip text boxes to current item info
        nameBox.GetComponent<Text>().text = itemName;
        descbox.GetComponent<Text>().text = itemDescription;
        costBox.GetComponent<Text>().text = ("power drain:" + pgCost + "    weaght:" + wgCost);
        //set reset point
        startPosition = this.gameObject.transform.position;
    }
    private void OnMouseUp()
    {
        //return to reset point
        transform.position = startPosition;
    }
    // Start is called before the first frame update
    void Start()
    {
        if (ObserverScript.Instance.unlocks[itemIdentifyer] == false)
        {
            //disable rendering and drag for secrit items
            if (itemIdentifyer == 34) { GetComponent<SpriteRenderer>().enabled = false; }
            if (itemIdentifyer == 35) { GetComponent<SpriteRenderer>().enabled = false; }
            if (itemIdentifyer == 36) { GetComponent<SpriteRenderer>().enabled = false; }
            //set color to shadow
            this.GetComponent<SpriteRenderer>().color = new Color (0,0,0,0.5f);
            //dissable collider
            GetComponent<CircleCollider2D>().enabled = false;
        }
        canvasGroup = gameObject.GetComponent<CanvasGroup>();
        placeholder[0] = pgCost;
        placeholder[1] = wgCost;
    }

    // Update is called once per frame
    void Update()
    {
        if (typeOfItem==Slot.GUN) 
        {
            //get currently fitted ship
            int i = GameObject.FindGameObjectWithTag("Player").GetComponent<itemDropHandeler>().itemId;
            //check what gun this is against player ship
            switch (itemID) 
            {
                case 1:
                    //check for matching ship
                    if (i == 1)
                    {//if it is 0 out pg/cpu
                        pgCost = 0;
                        wgCost = 0;
                    }
                    else 
                    {//if the ship dosent match make shure costs are set
                        pgCost = placeholder[0];
                        wgCost = placeholder[1];
                    }
                    break;
                case 2:
                    //check for matching ship
                    if (i == 3)
                    {//if it is 0 out pg/cpu
                        pgCost = 0;
                        wgCost = 0;
                    }
                    else
                    {//if the ship dosent match make shure costs are set
                        pgCost = placeholder[0];
                        wgCost = placeholder[1];
                    }
                    break;
                case 3:
                    //check for matching ship
                    if (i == 5)
                    {//if it is 0 out pg/cpu
                        pgCost = 0;
                        wgCost = 0;
                    }
                    else
                    {//if the ship dosent match make shure costs are set
                        pgCost = placeholder[0];
                        wgCost = placeholder[1];
                    }
                    break;
                case 4:
                    //check for matching ship
                    if (i == 2)
                    {//if it is 0 out pg/cpu
                        pgCost = 0;
                        wgCost = 0;
                    }
                    else
                    {//if the ship dosent match make shure costs are set
                        pgCost = placeholder[0];
                        wgCost = placeholder[1];
                    }
                    break;
                case 5:
                    //check for matching ship
                    if (i == 4)
                    {//if it is 0 out pg/cpu
                        pgCost = 0;
                        wgCost = 0;
                    }
                    else
                    {//if the ship dosent match make shure costs are set
                        pgCost = placeholder[0];
                        wgCost = placeholder[1];
                    }
                    break;
                case 6:
                    //check for matching ship
                    if (i == 6)
                    {//if it is 0 out pg/cpu
                        pgCost = 0;
                        wgCost = 0;
                    }
                    else
                    {//if the ship dosent match make shure costs are set
                        pgCost = placeholder[0];
                        wgCost = placeholder[1];
                    }
                    break;
            }
        }
    }
}
