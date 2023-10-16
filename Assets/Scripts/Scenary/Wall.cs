using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] private int _wallHealth;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private Color _defaltColor;

    private void Start()
    {
        _defaltColor = _spriteRenderer.color;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            DamageTaken();
        }
    }

    private void DamageTaken()
    {
        _wallHealth -= 1;

        if (_wallHealth <= 0)
        {
            Destroy(gameObject);
        }
        
        StartCoroutine(Flash());
    }

    private IEnumerator Flash()
    {
        _spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.04f);
        _spriteRenderer.color = _defaltColor;

    }
}
