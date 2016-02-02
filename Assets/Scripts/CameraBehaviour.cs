using UnityEngine;
using System.Collections;

public class CameraBehaviour : MonoBehaviour {
    public Transform FollowTarget;
    private Vector3 Offset;
    public float ZoomSpeed;
    public float Speed;
    private Vector3 Zoom;

    void Start()
    {
        Offset = transform.position - FollowTarget.position;
    }

    void LateUpdate() {


        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            Offset *= ZoomSpeed;

        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            Offset *= 1/ZoomSpeed;

        }
            

        if (Input.GetMouseButton(0))
        {
            Offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * Speed, Vector3.up) * Offset;
        }
        
        transform.position = FollowTarget.position + Offset;
        transform.LookAt(FollowTarget.transform.position);
    }
}
