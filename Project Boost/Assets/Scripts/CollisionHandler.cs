using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        switch (other.gameObject.tag) {
            case "Friendly":
                Debug.Log("This thing is friendly.");
                break;
            case "Finish":
                LoadNextLevel();
                break;
            case "Fuel":
                Debug.Log("You got fuel.!");
                break;
            default:
                ReloadLevel();
                break;
        }
    }

    private void ReloadLevel() {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }

    private void LoadNextLevel() {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        int nextScene =  (currentScene + 1 >= SceneManager.sceneCountInBuildSettings) ? 0 : currentScene + 1;
        SceneManager.LoadScene(nextScene);
    }
}
