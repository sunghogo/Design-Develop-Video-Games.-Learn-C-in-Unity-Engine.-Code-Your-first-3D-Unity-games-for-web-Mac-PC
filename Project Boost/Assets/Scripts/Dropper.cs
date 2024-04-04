using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    [SerializeField] private UnityEngine.Vector3 _movementVector;
    [SerializeField] private float _duration;
    private bool _hitObject;


    // Start is called before the first frame update
    void Start()
    {
        _hitObject = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_hitObject) transform.position += _movementVector * Time.deltaTime * 1/ _duration;
    }

    void OnCollisionEnter() {
        _hitObject = true;
    }
}
