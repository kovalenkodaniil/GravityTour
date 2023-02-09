using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Mover : MonoBehaviour
{
    [SerializeField] private float _acceleration;

    private Rigidbody2D _rb2;

    private void Awake()
    {
        _rb2 = GetComponent<Rigidbody2D>();
    }

    public void Init(Vector2 direction)
    {
        _rb2.AddForce(direction * _acceleration, ForceMode2D.Impulse);
    }
}
