using UnityEngine;
using System.Collections;
using TMPro;
using System;
using UnityEngine.UI;


public class TextAnimation : MonoBehaviour
{
    private TextMeshProUGUI textComponent; // Assign in Inspector
    private string fullText;
    public float typingSpeed = 0.01f;

    public Button yesButton;
    public Button noButton;
    public static bool typewriter = true;

    private void Start()
    {
        textComponent = gameObject.GetComponent<TextMeshProUGUI>();
        fullText = textComponent.text;
        StartCoroutine(TypeText());
    }

    public void Update(){
        if(ChatGPT.eventFinished){
        textComponent = gameObject.GetComponent<TextMeshProUGUI>();
        fullText = textComponent.text;
        StartCoroutine(TypeText());
        ChatGPT.eventFinished = false;
        }

    }

    public IEnumerator TypeText()
    {
        if(typewriter){
        enableButtons(false);
        textComponent.text = "";
        foreach (char c in fullText)
        {
            textComponent.text += c;
            yield return new WaitForSeconds(typingSpeed + (UnityEngine.Random.Range(1, 20)*0.003f));
        }
        //enables the choice
        enableButtons(true);
        }
    }

    public void enableButtons(bool enable){
    noButton.interactable = enable;
    yesButton.interactable = enable;
}
}