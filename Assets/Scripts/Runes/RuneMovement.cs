using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private ParticleSystem _effectsExplosion;

    private void FixedUpdate()
    {
        Move();       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.TryGetComponent<Barrier>(out var barrier) == true)
        {
            ParticleSystem particale = Instantiate(_effectsExplosion, transform.position, Quaternion.identity);
            particale.Play();
            Destroy(particale.gameObject, 2);
            Destroy(gameObject);
        }    
    }

    private void Move()
    {
        if(gameObject == null) return;

        transform.position = Vector3.MoveTowards(transform.position, FinishPoint.Instance.transform.position, _speed * Time.deltaTime);
    }
}

