using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private float _levelLoadDelay;
    [SerializeField] private AudioClip _successAudio;
    [SerializeField] private AudioClip _crashAudio;
    [SerializeField] private ParticleSystem _successParticles;
    [SerializeField] private ParticleSystem _crashParticles;

    private Movement _movement;
    private AudioSource _audioSource;
    private bool _isTransitioning;

    void Start() {
        _movement = GetComponent<Movement>();
        _audioSource = GetComponent<AudioSource>();
        
        _levelLoadDelay = 2f;
        _isTransitioning = false;
    }

    private void OnCollisionEnter(Collision other) {
        if (_isTransitioning) return;

        switch (other.gameObject.tag) {
            case "Friendly":
                Debug.Log("This thing is friendly.");
                break;
            case "Finish":
                _isTransitioning = true;
                FinishSequence();
                break;
            default:
                _isTransitioning = true;
                CrashSequence();
                break;
        }
    }

    void CrashSequence() {
        StopAndPlayAudioClip(_crashAudio);
        _crashParticles.Play();
        _movement.StopScript();
        Invoke("ReloadLevel", _levelLoadDelay);
    }

    void FinishSequence() {
        StopAndPlayAudioClip(_successAudio);
        _successParticles.Play();        
        _movement.StopScript();
        Invoke("LoadNextLevel", _levelLoadDelay);
    }

    private void ReloadLevel() {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }

    private void LoadNextLevel() {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        int nextScene =  (currentScene + 1 < SceneManager.sceneCountInBuildSettings) ? currentScene + 1 : 0;
        SceneManager.LoadScene(nextScene);
    }

    private void StopAndPlayAudioClip(AudioClip audioClip) {
        _audioSource.Stop();
        _audioSource.PlayOneShot(audioClip);
    }
}
