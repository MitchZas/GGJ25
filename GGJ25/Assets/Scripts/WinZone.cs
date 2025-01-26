using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System;

public class WinZone : MonoBehaviour
{
    [SerializeField] LevelLoader levelLoaderScript;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Clam")
        {
            levelLoaderScript.LoadNextLevel();
        }
    }
}
