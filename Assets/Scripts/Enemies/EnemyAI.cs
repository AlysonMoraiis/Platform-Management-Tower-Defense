using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float _speed;

    public bool _canMove;

    private Vector2 _moveSpot;
    
    void Start()
    {
        _moveSpot = new Vector2(0, transform.position.y);
        RotateTowardsMoveSpot();
    }

    void Update()
    {
        GoToCenter();
    }

    private void GoToCenter()
    {
        if (_canMove)
        {
            transform.position = Vector2.MoveTowards(transform.position, _moveSpot, _speed * Time.deltaTime);
        }
    }

    private void RotateTowardsMoveSpot()
    {
        Vector3 rotation = transform.eulerAngles;

        rotation.y = transform.position.x > _moveSpot.x ? 180f : 0f;

        transform.eulerAngles = rotation;
    }
}
