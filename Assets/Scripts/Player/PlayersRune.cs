using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersRune : MonoBehaviour
{
    [SerializeField] private int _color;
    [SerializeField] private ParticleSystem _healingBar;

    private int _numberColorGreen = 3;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.TryGetComponent<ICollide>(out var rune) == true)
        {
            Destroy(collision.gameObject);

            if(rune.GetColor() == _color)
            {
                rune.GiveBonus();

                if(rune.GetColor() == _numberColorGreen)
                {
                    _healingBar.Play();
                }
            }
            else
            {             
                rune.GiveDamage();
            }
        }
    }
}
