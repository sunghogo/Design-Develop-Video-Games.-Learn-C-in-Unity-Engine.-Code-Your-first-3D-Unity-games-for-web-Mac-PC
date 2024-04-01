using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField] private float _xAngle, _yAngle,_zAngle;

    [SerializeField] private float _rotationSpeed;
    

    // Start is called before the first frame update
    void Start()
    {
        _xAngle = 0;
        _yAngle = 20;
        _zAngle = 0;

        _rotationSpeed = 10;

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(_xAngle, _yAngle* Time.deltaTime * _rotationSpeed, _zAngle) ;
    }
}
