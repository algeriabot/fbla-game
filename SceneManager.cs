using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventManager : MonoBehaviour
{
    // Start is called before the first frame update
    private string sceneName;
    public static EventManager instance = null;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    void OnApplicationQuit()
    {
        PlayerPrefs.DeleteAll();
    }

    // Update is called once per frame
    void Update()
    {
        sceneName = SceneManager.GetActiveScene().name;

        if (Input.GetKey("escape") && sceneName == "YesNo Scene")
        {
            SceneManager.LoadScene("GameScene");
        }
        else if (Input.GetKey("escape") && sceneName == "Menu")
        {
            SceneManager.LoadScene("YesNo Scene");
        }
        // else if (Input.GetKey("e") && sceneName == "GameScene")
        // {
        //     SceneManager.LoadScene("YesNo Scene");
        // }
        else if (Input.GetKey("escape") && sceneName == "GameScene")
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
