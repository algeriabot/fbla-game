using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSceneCollider : MonoBehaviour
{
    public string sceneName;

    void OnTriggerEnter2D(Collider2D col)
    {
        // Debug.Log("Collision detected" + " " + col.gameObject.name);
        if (col.gameObject.name == "Player")
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
