using System;
using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class ItemData : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler {
    public Item Item;
    public int Amount;
    public int Slot;

    private Vector2 _offset;
    private Inventory _inventory;
    private Tooltip _tooltip;

    void Start() {
        _inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
        _tooltip = _inventory.GetComponent<Tooltip>();
    }

    public void OnBeginDrag(PointerEventData eventData) {
        if (Item != null) {
            transform.SetParent(transform.parent.parent);
            transform.position = eventData.position - _offset;
        }
    }

    public void OnDrag(PointerEventData eventData) {
        if (Item != null) {
            transform.position = eventData.position - _offset;
        }
    }

    public void OnEndDrag(PointerEventData eventData) {
        transform.SetParent(_inventory.Slots[Slot].transform);
        transform.position = _inventory.Slots[Slot].transform.position + new Vector3(20, -20, 0);

        if (!EventSystem.current.IsPointerOverGameObject()) {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitdist;

            if (Physics.Raycast(ray, out hitdist, Mathf.Infinity))
            {
                if (hitdist.transform.gameObject.layer == LayerMask.NameToLayer("Ground")) {
                    Debug.Log("Hit");
                    //Instantiate(Resources.Load<GameObject>("Items/" + Item.Slug), hitdist.point, Quaternion.identity);
                    GameObject.Find("Player").GetComponent<AgentScript>().PlaceItem(hitdist.point, Resources.Load<GameObject>("Items/" + Item.Slug), RemoveFromInventory);
                    //RemoveFromInventory();
                }
            }
        }
    }

    private void RemoveFromInventory() {
        Destroy(this.gameObject);
        _inventory.Items[Slot] = new Item();
    }

    public void OnPointerDown(PointerEventData eventData) {
        if (Item != null) {
            _offset = eventData.position - new Vector2(transform.position.x, transform.position.y);
            GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
    }


    public void OnPointerEnter(PointerEventData eventData) {
        _tooltip.Activate(Item);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
     _tooltip.Deactivate();
    }

    public void OnPointerUp(PointerEventData eventData)
    {

        GetComponent<CanvasGroup>().blocksRaycasts = true;

        // Place item
        //var playerPlane = new Plane(Vector3.up, transform.position);

    }
}
