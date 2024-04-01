using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectHit : MonoBehaviour
{
    private Color _spawnColor;
    private Color _hitColor;
    private MeshRenderer _meshRenderer;
    private float _resetTime;

    void Start() {
        _meshRenderer = GetComponent<MeshRenderer>();
        _spawnColor = _meshRenderer.material.color;
        _hitColor = Color.red;
        _resetTime = 3f;
    }

    // OnCollisionEnter() is called whenever a collision event occurs
    private void OnCollisionEnter(Collision collision) 
    {
        if (collision.gameObject.tag == "Player" && gameObject.tag != "Hit") {
            Hit();
            Debug.Log($"{gameObject.name} hit by {collision.gameObject.name}");
            CoroutineManager.DelayedAction(_resetTime, Reset);
        }
    }

    private void Hit() {
        TagHit();
        ChangeToHitColor();
    }

    private void Reset() {
        Untag();
        ResetColor();
    }

    private void TagHit() {
        gameObject.tag = "Hit";
    }

    private void Untag() {
        gameObject.tag = "Untagged";

    }

    private void ChangeToHitColor() {
        _meshRenderer.material.color = _hitColor;
    }

    private void ResetColor() {
        _meshRenderer.material.color = _spawnColor;
    }
}
