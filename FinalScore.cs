using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class FinalScore : MonoBehaviour
{
    // Start is called before the first frame update
    int fs;
    void Start()
    {
        fs = MoneyScript.finalScore;
        gameObject.GetComponent<TextMeshProUGUI>().text = "SCORE: " + fs + "k";
    }

}
