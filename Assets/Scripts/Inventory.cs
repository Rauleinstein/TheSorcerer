using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {
    public GameObject InventorySlot;
    public GameObject InventoryItem;
    public List<Item> Items = new List<Item>();
    public List<GameObject> Slots = new List<GameObject>();

    private GameObject _inventoryPanel;
    private GameObject _slotPanel;
    private ItemDatabase _database;
    private int _slotAmout; 

    void Start() {
        Console.WriteLine("Start");
        _database = GetComponent<ItemDatabase>();
        _slotAmout = 16;
        _inventoryPanel = GameObject.Find("Inventory Panel");
        _slotPanel = _inventoryPanel.transform.FindChild("Slot Panel").gameObject;

        for (int i = 0; i < _slotAmout; i++) {
            Items.Add(new Item());
            Slots.Add(Instantiate(InventorySlot));
            Slots[i].GetComponent<Slot>().Id = i;
            Slots[i].transform.SetParent(_slotPanel.transform);
        }

        //AddItem(0);
        //AddItem(1);
        //AddItem(1);
    }

    public void AddItem(Item item) {
        Item itemToAdd = item;

        if (itemToAdd.Stackable && IsItemInInventory(itemToAdd)) {
            for (int i = 0; i < Items.Count; i++) {
                if (Items[i].Id == itemToAdd.Id) {
                    ItemData data = Slots[i].transform.GetChild(0).GetComponent<ItemData>();
                    data.Amount++;
                    data.transform.GetChild(0).GetComponent<Text>().text = data.Amount.ToString();
                    return;
                }
            }
        }

        for (int i = 0; i < Items.Count; i++)
        {
            if (Items[i].Id < 0)
            {
                Items[i] = itemToAdd;

                GameObject itemObj = Instantiate(InventoryItem);
                itemObj.transform.SetParent(Slots[i].transform);
                itemObj.transform.localPosition = new Vector3(20, -20, 0);
                itemObj.GetComponent<Image>().sprite = itemToAdd.Sprite;
                itemObj.name = itemToAdd.Title;

                ItemData data = Slots[i].transform.GetChild(0).GetComponent<ItemData>();
                data.Item = itemToAdd;
                data.Amount = 1;
                data.Slot = i;
                

                break;
            }
        }
    }

    public void AddItem(int id) {
        AddItem(_database.GetItemById(id));
    }

    private bool IsItemInInventory(Item item) {
        for (int i = 0; i < Items.Count; i++) {
            if (Items[i].Id == item.Id) {
                return true;
            }
        }
        return false;
    }
}
