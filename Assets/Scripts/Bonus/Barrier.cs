using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    [SerializeField] private float _lifeTime;

    public float LifeTime => _lifeTime;
}
