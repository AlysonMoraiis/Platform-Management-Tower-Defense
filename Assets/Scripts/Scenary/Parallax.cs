using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float _lenght;
    private float _startPos;

    private Transform _camera;

    public float _parallaxEffect;

    void Start()
    {
        _startPos = transform.position.x;
        _lenght = GetComponent<SpriteRenderer>().bounds.size.x;
        _camera = Camera.main.transform;
    }

    void Update()
    {
        float RePosition = _camera.transform.position.x * (1 - _parallaxEffect);

        float Distance = _camera.transform.position.x * _parallaxEffect;

        transform.position = new Vector3(_startPos + Distance, transform.position.y, transform.position.z);

        if (RePosition > _startPos + _lenght)
        {
            _startPos += _lenght;
        }
        else if (RePosition < _startPos - _lenght)
        {
            _startPos -= _lenght;
        }
    }
}
