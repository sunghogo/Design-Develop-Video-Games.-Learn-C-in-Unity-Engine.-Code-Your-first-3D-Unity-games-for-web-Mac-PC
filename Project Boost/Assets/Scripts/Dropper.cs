using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    [SerializeField] private UnityEngine.Vector3 _movementVector;
    [SerializeField] private float _holdDuration;

    private UnityEngine.Vector3 _startingPosition;

    private float _startingTime;


    // Start is called before the first frame update
    void Start()
    {
        _startingPosition = transform.position;
        _startingTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Time.time - _startingTime) <= _holdDuration) transform.position = _startingPosition;
    }
}
