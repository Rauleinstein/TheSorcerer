using UnityEngine;
using System.Collections;

public class Item {
    public Item(int id, string title, string description, bool stackable, string slug) {
        Id = id;
        Title = title;
        Description = description;
        Stackable = stackable;
        Slug = slug;
        Sprite = Resources.Load<Sprite>("Sprites/Items/" + Slug);
    }

    public Item() {
        Id = -1;
    }

    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool Stackable { get; set; }
    public string Slug { get; set; }
    public Sprite Sprite { get; set; }
}
