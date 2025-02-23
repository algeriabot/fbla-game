using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;

public class ActivePlayers : MonoBehaviour
{
    public TMP_Text aPText;

    public static bool showActivePlayers = true;

    public static ActivePlayers instance = null;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        if (ChooseMultiplayer.isMultiplayer && showActivePlayers)
            aPText.text = "Active Players: " + PhotonNetwork.CountOfPlayers;
    }

    private float lastUpdateTime = 0f;
    private float updateInterval = 5f; // Update every 5 seconds

    void Update()
    {
        //Debug.Log(lastUpdateTime);
        //outlineText.text = aPText.text;
        if (ChooseMultiplayer.isMultiplayer && showActivePlayers)
        {
            if (Time.time - lastUpdateTime >= updateInterval) // Only update if enough time has passed
            {
                lastUpdateTime = Time.time; // Reset the timer
                aPText.text = "Active Players: " + PhotonNetwork.CountOfPlayers; // Update the text
            }
        }
        else
        {
            aPText.text = ""; // Clear text if not multiplayer or showActivePlayers is false
        }
    }
}
