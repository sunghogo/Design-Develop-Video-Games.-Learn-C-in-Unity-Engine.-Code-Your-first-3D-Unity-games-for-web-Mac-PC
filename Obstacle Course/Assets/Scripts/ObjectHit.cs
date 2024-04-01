using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectHit : MonoBehaviour
{
    private Color _spawnColor;
    private Color _hitColor;
    private Color _currentColor;
    private MeshRenderer _meshRenderer;
    private float _resetTime;

    void Start() {
        _meshRenderer = GetComponent<MeshRenderer>();
        _spawnColor = _meshRenderer.material.color;
        _currentColor = _meshRenderer.material.color;
        _hitColor = Color.red;
        _resetTime = 3f;
    }

    // OnCollisionEnter() is called whenever a collision event occurs
    private void OnCollisionEnter(Collision collision) 
    {
        UpdateCurrentColor();
        if (collision.gameObject.name == "Dodgy" && _currentColor != _hitColor) {
            Debug.Log($"{gameObject.name} hit by {collision.gameObject.name}");
            ChangeToHitColor();

            CoroutineManager.DelayedAction(_resetTime, ChangeToSpawnColor);
        }
    }

    private void ChangeToHitColor() {
        _meshRenderer.material.color = _hitColor;
    }

    private void ChangeToSpawnColor() {
        _meshRenderer.material.color = _spawnColor;
    }

    private void UpdateCurrentColor() {
        _currentColor = _meshRenderer.material.color;
    }
}
