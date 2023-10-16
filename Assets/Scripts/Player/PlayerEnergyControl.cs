using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerEnergyControl : MonoBehaviour
{
    [SerializeField] private float _maxEnergy = 20;
    [SerializeField] private Image _healthBar;

    private int _energy;

    void Start()
    {
        _energy = (int)_maxEnergy;
    }

    void Update()
    {
        if (Input.GetKeyDown("i"))
        {
            TakeDamage();
        }

        if (Input.GetKeyDown("o"))
        {
            RecoverEnergy();
        }
    }

    private void TakeDamage()
    {
        UpdateEnergyValue(-1);
    }


    private void RecoverEnergy()
    {
        UpdateEnergyValue(+1);
    }

    private void UpdateEnergyValue(int value)
    {
        _energy += value;

        if (_energy > _maxEnergy)
        {
            _energy = (int)_maxEnergy;
        }
        else if (_energy <= 0)
        {
            _energy = 0;
        }

        _healthBar.fillAmount = _energy / _maxEnergy;
    }
}
