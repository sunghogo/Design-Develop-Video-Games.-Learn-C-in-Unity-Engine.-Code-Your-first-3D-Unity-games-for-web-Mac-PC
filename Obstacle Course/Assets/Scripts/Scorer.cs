using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Scorer : MonoBehaviour
{
    [SerializeField] private int _collisions;
    
    // Start is called before the first frame update
    void Start()
    {
        _collisions = 0;
    }

    private void OnCollisionEnter(Collision collision) {
        var objectHit = collision.gameObject.GetComponent<ObjectHit>();
        if (objectHit is not null) {
            _collisions++;
            Debug.Log($"You've bumped into a thing {_collisions} many times");
        }
    }
}
