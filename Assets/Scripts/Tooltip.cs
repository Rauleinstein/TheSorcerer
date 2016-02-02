using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour {
    private Item _item;
    private string _data;
    private GameObject _tooltip;

    void Start() {
        _tooltip = GameObject.Find("Tooltip");
        _tooltip.SetActive(false);
    }

    void Update() {
        if (_tooltip.activeSelf) {
            _tooltip.transform.position = Input.mousePosition;
        }
    }

    public void Activate(Item item) {
        _item = item;
        ConstructDataString();
        _tooltip.SetActive(true);
    }

    public void Activate(string decscritpon, int color = 000000) {
        _data = String.Concat("<color=#", color,">", decscritpon, "</color>\n");
        _tooltip.transform.GetChild(0).GetComponent<Text>().text = _data;
        _tooltip.SetActive(true);
    }

    public void Deactivate() {
        _tooltip.SetActive(false);
    }

    public void ConstructDataString() {
        _data = String.Concat("<color=#000000><b>", _item.Title, "</b></color>\n", _item.Description);
        _tooltip.transform.GetChild(0).GetComponent<Text>().text = _data;
    }
}
