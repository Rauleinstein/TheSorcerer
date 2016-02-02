using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class AgentScript : MonoBehaviour
{
    private static NavMeshAgent _agent;
    private static bool _move;
    private Vector3 _targetPosition;

    private bool _placeItem;
    private GameObject _item;
    private Action _callback;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _targetPosition = transform.position;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                var playerPlane = new Plane(Vector3.up, transform.position);
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                float hitdist;

                if (playerPlane.Raycast(ray, out hitdist))
                {
                    _targetPosition = ray.GetPoint(hitdist);
                    StartMove();
                    _agent.SetDestination(_targetPosition);
                }
            }
        }

        if (!_move)
        {
            return;
        }

        if (_placeItem && Vector3.Distance(transform.position, _targetPosition) < 1)
        {
            Instantiate(_item, _targetPosition + new Vector3(0, 0.5f, 0), Quaternion.identity);
            _placeItem = false;
            StopMove();
            _callback();
            return;
        }

        if (Vector3.Distance(transform.position, _targetPosition) < 0.1f)
        {
            StopMove();
        }
    }

    public void PlaceItem(Vector3 position, GameObject item, Action callback)
    {
        _callback = callback;
        _placeItem = true;
        _item = item;

        _targetPosition = position;
        StartMove();
        _agent.SetDestination(_targetPosition);
    }

    public static void StartMove()
    {
        Animation anim;
        anim = _agent.GetComponentInChildren<Animation>();
        anim.CrossFade("Walk");
        _move = true;
        _agent.enabled = true;
    }

    public static void StopMove()
    {
        Animation anim;
        anim = _agent.GetComponentInChildren<Animation>();
        anim.CrossFade("Idle1");
        _move = false;
        _agent.enabled = false;
    }
}
