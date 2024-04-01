using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.iOS;

// Singleton
public class CoroutineManager : MonoBehaviour
{
   private static CoroutineManager _instance;
   public static CoroutineManager Instance {
    // Lazy Initialization
    get {
        if (_instance is null) {
            _instance = FindObjectOfType<CoroutineManager>(); // Check for existing CoroutineManager instance before initializing
            if (_instance is null) {
                var newGameObject = new GameObject("CoroutineManager");
                _instance = newGameObject.AddComponent<CoroutineManager>();
                DontDestroyOnLoad(newGameObject);
            }
        }
        return _instance;
    }
   }

   void Awake() {
    if (_instance is null) { // Initializes on AddComponent<CoroutineMangaer>()
        _instance = this;
        DontDestroyOnLoad(gameObject);
    } else if (_instance != this) { // Destroys duplicate CoroutineManager gameObjects if newly created due to scene transitions
        Destroy(gameObject);
    }
   }

   public static Coroutine StartGlobalCoroutine(IEnumerator coroutine) {
    return Instance.StartCoroutine(coroutine);
   }

   public static void StopGlobalCoroutine (Coroutine coroutine) {
        Instance.StopCoroutine(coroutine);
   }

   private static IEnumerator DelayedActionCoroutine(float seconds, System.Action action) {
        yield return new WaitForSeconds(seconds);
        action?.Invoke();
   }

   public static void DelayedAction(float seconds, System.Action action) {
        var delayedActionCoroutine = DelayedActionCoroutine(seconds, action);
        StartGlobalCoroutine(delayedActionCoroutine);
   }
}
