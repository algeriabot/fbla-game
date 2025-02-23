using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class TutorialAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    private string fullText;
    public float typingSpeed = 0.01f;
    private TextMeshProUGUI textComponent;
    Coroutine ani;
    //private bool finishedP1 = false;
    //private const string p2 = "Oh, sorry, here’s how you’ll do all that. The main thing you need to focus on is the conference room, where you’ll either say ‘yes’ or ‘no’. Make some good decisions that’ll help the company! Just click the ‘new scenario’ button to pop up a new scenario. But watch out, if any of your metrics hit 0, you’ll lose! Remember to maximize revenue, good luck!";

    void Start()
    {
        textComponent = gameObject.GetComponent<TextMeshProUGUI>();
        fullText = textComponent.text;
        ani = StartCoroutine(TypeText());

    }

    void Update(){
        //if(finishedP1){
           // fullText = p2;
            //StartCoroutine(TypeText());
        //}
        
    }
    public IEnumerator TypeText()
    {
        textComponent.text = "";
        foreach (char c in fullText)
        {
            textComponent.text += c;
            yield return new WaitForSeconds(typingSpeed + (UnityEngine.Random.Range(1, 20)*0.003f));
        }
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Title Screen");
    }
}
