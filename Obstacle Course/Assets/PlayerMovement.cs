using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _xVelocity, _yVelocity, _zVelocity;
    [SerializeField] private float _moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        _xVelocity = 0.0f;
        _yVelocity = 0.0f;
        _zVelocity = 0.0f;
        _moveSpeed = 10f;

        PrintInstruction();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    void PrintInstruction() {
        Debug.Log("Welcome to the game.");
        Debug.Log("Move your player with WASD or arrow keys.");
        Debug.Log("Don't hit the walls!");
    }

    void MovePlayer() {
        // Time.deltaTime normalizes magnitude for differing Update calls due to varying framerates
        _xVelocity=Input.GetAxis("Horizontal") * Time.deltaTime * _moveSpeed;
        _yVelocity=Input.GetAxis("Jump") * Time.deltaTime * 0.2f * _moveSpeed;
        _zVelocity=Input.GetAxis("Vertical") * Time.deltaTime  * _moveSpeed;
        transform.Translate(_xVelocity, _yVelocity, _zVelocity);        
    }
}
