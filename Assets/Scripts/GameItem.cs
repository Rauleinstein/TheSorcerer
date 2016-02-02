using UnityEngine;
using System.Collections;

public class GameItem : MonoBehaviour {
    private Tooltip _tooltip;
    private Item _item;

    void Awake() {
        _tooltip = GameObject.Find("Inventory").gameObject.GetComponent<Tooltip>();
        _item = new Item(Id, Title, Description, Stackable, Slug);
    }

    void OnTriggerEnter(Collider other) {
        GameObject.Find("Inventory").GetComponent<Inventory>().AddItem(_item);
        Destroy(gameObject);
    }

    public int Id;
    public string Title;
    public string Description;
    public bool Stackable;
    public string Slug;
    public Sprite Sprite;

    void OnMouseEnter() {
        _tooltip.Activate(Description);
    }

    void OnMouseExit() {
        _tooltip.Deactivate();
    }
}
