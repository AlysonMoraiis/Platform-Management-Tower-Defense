using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyCollider : MonoBehaviour
{
    [SerializeField] private EnemyAI _enemyAI;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private float _knockbackForce;
    [SerializeField] private float _knockbackCounter;

    private bool _knockFromRight;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Wall") || (other.gameObject.CompareTag("Player")))
        {
            if (other.transform.position.x <= transform.position.x)
            {
                _knockFromRight = false;
            }
            else
            {
                _knockFromRight = true;
            }

            StartCoroutine(Knock());
        }
    }

    private IEnumerator Knock()
    {
        _enemyAI._canMove = false;

        float randomForce = Random.Range(-_knockbackForce / 5, _knockbackForce / 5);

        if (_knockFromRight)
        {
            _rigidbody2D.AddForce(new Vector2(-_knockbackForce + randomForce, _knockbackForce * 2.3f));
        }

        else if (!_knockFromRight)
        {
            _rigidbody2D.AddForce(new Vector2(_knockbackForce + randomForce, _knockbackForce * 2.3f));
        }

        yield return new WaitForSeconds(_knockbackCounter);

        _enemyAI._canMove = true;
    }
}
