using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClickSound : MonoBehaviour
{
    // Start is called before the first frame update
    private Button button;
    private AudioSource audioSource;
    void Start()
    {
        button = gameObject.GetComponent<Button>();
        audioSource = gameObject.GetComponent<AudioSource>();
        button.onClick.AddListener(OnClick);
    }

    // Update is called once per frame
    private void OnClick()
    {
        audioSource.Play();
    }
}
