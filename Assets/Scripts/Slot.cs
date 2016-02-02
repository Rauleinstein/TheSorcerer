using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler
{
    public int Id;
    private Inventory _inventory;
    

    void Start() {
        _inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
    }

    public void OnDrop(PointerEventData eventData){
        ItemData droppedItem = eventData.pointerDrag.GetComponent<ItemData>();
        if (_inventory.Items[Id].Id == -1) {
            _inventory.Items[droppedItem.Slot] = new Item();
            _inventory.Items[Id] = droppedItem.Item;
            droppedItem.Slot = Id;
        } else if(droppedItem.Slot != Id) {
            Transform item = transform.GetChild(0);
            item.GetComponent<ItemData>().Slot = droppedItem.Slot;
            item.transform.SetParent(_inventory.Slots[droppedItem.Slot].transform);
            item.transform.position = _inventory.Slots[droppedItem.Slot].transform.position + new Vector3(20, -20, 0); ;

            droppedItem.Slot = Id;
            droppedItem.transform.SetParent(transform);
            droppedItem.transform.position = transform.position;

            _inventory.Items[droppedItem.Slot] = item.GetComponent<ItemData>().Item;
            _inventory.Items[Id] = droppedItem.Item;
        }
    }
}
