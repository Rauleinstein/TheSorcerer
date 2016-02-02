using UnityEngine;
using System.Collections;

public class CreateBridge : MonoBehaviour {

    public Transform Bridge;
    public GameObject Cube;
    public int Speed;
    private Vector3 initialPos;
    private bool show;

	// Use this for initialization
	void Start () {
        initialPos = Bridge.position;
        Bridge.position = Bridge.position - new Vector3(0,100,0);
        show = false;
	
	}
	
	// Update is called once per frame
	void Update () {
        float step = Speed * Time.deltaTime;
        if (Input.GetKeyDown("k"))
        {
            show = true;
            Cube.GetComponent<NavMeshObstacle>().enabled = false;
        }
        if((initialPos.y > Bridge.position.y)&&(show))
        {
            Bridge.position = Vector3.MoveTowards(Bridge.position, Bridge.position + new Vector3(0, 100, 0), step);
        }
              
	}
}
