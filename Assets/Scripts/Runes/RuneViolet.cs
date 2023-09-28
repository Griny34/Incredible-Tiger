using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneViolet : MonoBehaviour, ICollide
{
    [SerializeField] private ParticleSystem _effactExplosion;
    [SerializeField] private ParticleSystem _effactBonus;

    private int _color = 2;
    private int _bonus = 1;

    public int GetColor()
    {
        return _color;
    }

    public void GiveBonus()
    {
        ParticleSystem effactBonus = Instantiate(_effactBonus, gameObject.transform.position, Quaternion.identity);
        effactBonus.Play();
        Destroy(effactBonus.gameObject, 2);

        ScorCounter.Instance.TakePoints(_bonus);
    }

    public void GiveDamage()
    {
        ParticleSystem effactExplosion = Instantiate(_effactExplosion, gameObject.transform.position, Quaternion.identity);
        effactExplosion.Play();
        Destroy(effactExplosion.gameObject,2);

        int chance = Random.Range(0, 2);

        if(chance == 0)
        {
            WheelMovement.Instance.MoveClockWise();
        }
        else
        {
            WheelMovement.Instance.MoveContrClockWise();
        }
    }
}
