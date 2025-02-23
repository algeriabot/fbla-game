using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnOffText : MonoBehaviour
{
    public Button button;

    void Start()
    {
        Button btn = button.GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        if (TextAnimation.typewriter)
            TextAnimation.typewriter = false;
        else
            TextAnimation.typewriter = true;
    }
}
