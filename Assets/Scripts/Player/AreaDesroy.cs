using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaDesroy : MonoBehaviour
{
    [SerializeField] private int _damag;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.TryGetComponent<RuneMovement>(out var rune) == true)
        {
            Destroy(collision.gameObject);

            Health.Instance.TakeDamag(_damag);
        }
    }
}
