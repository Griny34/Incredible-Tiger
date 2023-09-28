using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneGreen : MonoBehaviour, ICollide
{
    [SerializeField] private ParticleSystem _effactExplosion;
    [SerializeField] private ParticleSystem _effactBonus;

    private int _color = 3;
    private int _bonus = 1;
    private int _damag = 1;

    public int GetColor()
    {
        return _color;
    }

    public void GiveBonus()
    {
        if(Health.Instance.Value < Health.Instance.StartValue)
        {
            ParticleSystem effactBonus = Instantiate(_effactBonus, gameObject.transform.position, Quaternion.identity);
            effactBonus.Play();
            Destroy(effactBonus.gameObject, 2);

            Health.Instance.Value += _bonus;
        }        
    }

    public void GiveDamage()
    {
        if(Health.Instance.Value > 0)
        {
            ParticleSystem effactExplosion = Instantiate(_effactExplosion, gameObject.transform.position, Quaternion.identity);
            effactExplosion.Play();
            Destroy(effactExplosion.gameObject, 2);

            Health.Instance.Value -= _damag;
        }       
    }
}
