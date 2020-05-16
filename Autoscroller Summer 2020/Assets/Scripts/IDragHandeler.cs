using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.EventSystems;

public class IDragHandeler : MonoBehaviour, IDragHandeler, IEndDragHandeler
{
	public void OnDrag(PointerEventData eventData) 
	{
		transform.position = Input.mousePosition;
	}
	public void OnEndDrag(PointerEventData eventData) 
	{
		transform.position = Vector3.zero;
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
