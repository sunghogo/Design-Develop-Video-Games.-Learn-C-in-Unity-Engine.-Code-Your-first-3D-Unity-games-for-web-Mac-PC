using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectHit : MonoBehaviour
{
    // OnCollisionEnter() is called whenever a collision event occurs
    private void OnCollisionEnter(Collision other) 
    {
        if (GetComponent<MeshRenderer>().material.color == Color.red) {
            return;
        }
        Debug.Log($"{gameObject.name} hit by {other.gameObject.name}");
        // Call GetComponent<Component>() to retrieve the specified component from the attached object
        Color oldColor = GetComponent<MeshRenderer>().material.color;
        GetComponent<MeshRenderer>().material.color = Color.red;

        StartCoroutine(WaitAndChangeColor(1.5f, oldColor));
    }

    private IEnumerator WaitAndChangeColor(float seconds, Color color) {
        yield return new WaitForSeconds(seconds);
        GetComponent<MeshRenderer>().material.color = color;
    }
}
