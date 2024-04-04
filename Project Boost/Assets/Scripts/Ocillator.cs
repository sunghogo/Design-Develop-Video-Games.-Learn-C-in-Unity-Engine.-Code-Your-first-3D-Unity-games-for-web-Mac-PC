using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ocillator : MonoBehaviour
{
    [SerializeField] private Vector3 _movementVector;
    [SerializeField] [Range(0,1)] private float _movementFactor;
    [SerializeField] private float _period = 2f;

    private Vector3 _startingPosition;

    // Start is called before the first frame update
    void Start()
    {
        _startingPosition = transform.position;    
    }

    // Update is called once per frame
    void Update()
    {
        if (_period <= Mathf.Epsilon) return;

        const float tau = Mathf.PI * 2; // continually growing over time

        float cycles = Time.time / _period; // constant value 6.283...

        float rawSinWave = Mathf.Sin(cycles * tau); // going from -1 to 1

        _movementFactor = (rawSinWave + 1f) / 2f; // normalize range 0 to 1

        Vector3 offset = _movementVector * _movementFactor;
        transform.position = _startingPosition + offset;
    }
}
