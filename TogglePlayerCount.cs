using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TogglePlayerCount : MonoBehaviour
{
    public Button button;

    void Start()
    {
        Button btn = button.GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        ActivePlayers.showActivePlayers = !ActivePlayers.showActivePlayers;
    }
}
