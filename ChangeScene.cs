using System.Collections;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{
    public Button button;
    public string sceneName;

    //private AudioSource audioSource;

    void Start()
    {
        //audioSource = gameObject.GetComponent<AudioSource>();
        Button btn = button.GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        // load data here
        //audioSource.Play();
        SceneManager.LoadScene(sceneName);
    }
}
