using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    [SerializeField] private int _timeToWait = 3;
    private MeshRenderer _renderer;
    private Rigidbody _rigidbody;
    private bool _falling;
    private Vector3 _spawnPosition;
    private float _resetTime;


    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponent<MeshRenderer>();
        _rigidbody = GetComponent<Rigidbody>();

        _renderer.enabled = false;
        _rigidbody.useGravity = false;
        _falling = false;
        _resetTime = 3f;
        _spawnPosition = transform.position;    

    }

    // Update is called once per frame
    void Update()
    {
        if (!_falling && (int)Time.time > 0 && ((int)Time.time % _timeToWait == 0)) {
            Fall();
            CoroutineManager.DelayedAction(_resetTime, Reset);
        }
    }

    private void Fall() {
        _renderer.enabled = true;
        _rigidbody.useGravity = true;
        _falling = true;
    }

    private void Reset()
    {
        _renderer.enabled = false;
        _rigidbody.useGravity = false;
        _falling = false;
        transform.position = _spawnPosition;
    }
}
