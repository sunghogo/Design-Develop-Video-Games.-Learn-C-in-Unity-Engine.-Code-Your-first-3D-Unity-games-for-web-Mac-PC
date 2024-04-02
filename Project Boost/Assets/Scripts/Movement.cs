using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.TextCore.LowLevel;

public class Movement : MonoBehaviour
{
    // PARAMTERS - for tuning, typically set in the editor;

    // CACHE - e.g. references for readability or speed;

    // STATE - privvate instance (member) variables
    [SerializeField] private float _mainThrust;
    [SerializeField] private float _rotationThrust;
    [SerializeField] private AudioClip _mainEngineAudio;

    private Rigidbody _rigidBody;
    private AudioSource _audioSource;


    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
        _rigidBody.drag = 0.25f;
        _mainThrust = 1000f;
        _rotationThrust = 100f;

        // Constraints
        _rigidBody.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
    }

    private void ProcessInput() {
        ProcessThrust();
        ProcessRotation();
    }

    private void ProcessThrust() {
        if (Input.GetKey(KeyCode.Space)) {
            ApplyThrust();
            if (!_audioSource.isPlaying) _audioSource.PlayOneShot(_mainEngineAudio);
        } else {
            _audioSource.Stop();
        }
    }

    private void ProcessRotation() {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            RotateLeft();
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            RotateRight();
        }
    }

    private void RotateLeft() {
        ApplyRotation(_rotationThrust);
    }

    private void RotateRight() {
        ApplyRotation(-_rotationThrust);
    }

    private void ApplyRotation(float rotationThrust)
    {
        _rigidBody.freezeRotation = true;
        transform.Rotate(UnityEngine.Vector3.forward * rotationThrust * Time.deltaTime);
        _rigidBody.freezeRotation = false;
    }

    private void ApplyThrust() {
        _rigidBody.AddRelativeForce(UnityEngine.Vector3.up * _mainThrust * Time.deltaTime);

    }

    public void StopScript() {
        this.enabled = false;
    }
}
