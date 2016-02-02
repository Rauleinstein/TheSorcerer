using UnityEngine;
using LitJson;
using System.Collections.Generic;
using System.IO;

public class ItemDatabase : MonoBehaviour {
    private readonly List<Item> _database = new List<Item>();
    private JsonData _itemData;

	void Start () {
        _itemData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/Items.json"));
        ConstructItemDatabase();
	}

    public Item GetItemById(int id)
    {
        for (int i = 0; i < _database.Count; i++)
        {
            if (_database[i].Id == id)
            {
                return _database[i];
            }
        }

        return null;
    }

    void ConstructItemDatabase() {
        for (int i = 0; i < _itemData.Count; i++) {
            _database.Add(new Item((int)_itemData[i]["id"], _itemData[i]["title"].ToString(), _itemData[i]["description"].ToString(), _itemData[i]["stackable"].IsBoolean ,_itemData[i]["slug"].ToString()));
        }
    }
}
