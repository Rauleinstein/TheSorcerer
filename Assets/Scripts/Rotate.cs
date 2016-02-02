using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {
    private Vector3 startPosition;
	// Use this for initialization
	void Start () {
	    startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, Time.deltaTime * 100, 0, Space.World);
        transform.position = new Vector3(startPosition.x, startPosition.y + (Mathf.Sin(Time.time * 2) / 4), startPosition.z);
    }
}
