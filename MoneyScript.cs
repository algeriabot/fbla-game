using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoneyScript : MonoBehaviour
{
    public TMP_Text moneyText;
    public string resource;
    public int amount;
    private bool connected = false;
    int tempAmount;
    public int latestAmount;
    public float typingSpeed = 0.01f;
    public static int finalScore;
    public static bool trigger = false;

    // public static bool firstInit = true;

    private PhotonView photonView;

    void Start()
    {
        photonView = GetComponent<PhotonView>(); // Get PhotonView component
        // if (PhotonNetwork.IsMasterClient)
        if (!PhotonNetwork.IsMasterClient)
            PhotonNetwork.IsMessageQueueRunning = true;

        // if the game has already started don't reset values, or if the multiplayer game finished let them restart
        if (PlayerPrefs.HasKey(resource))
        {
            amount = PlayerPrefs.GetInt(resource);
        }
        else
        {
            startingValue();
        }
        // if (firstInit || amount == 0)
        //     startingValue();
        // firstInit = false;

        latestAmount = amount;
        moneyText.text = resource + ":" + amount + extraResourceText();
    }

    void OnDestroy()
    {
        // Save the amount when the scene is changed
        PlayerPrefs.SetInt(resource, amount);
    }

    IEnumerator ReconnectToPhoton()
    {
        yield return new WaitForSeconds(2); // Wait for 2 seconds before retrying connection
        connected = false;
        PhotonNetwork.ConnectUsingSettings(); // Reconnect to Photon
    }

    public void OnDisconnected(Photon.Realtime.DisconnectCause cause)
    {
        Debug.Log("Disconnected from Photon: " + cause);
        if (!PhotonNetwork.IsConnected)
        {
            StartCoroutine(ReconnectToPhoton()); // Attempt to reconnect
            Debug.Log("Connecting to Photon...");
        }
    }

    void Update()
    {
        if (!PhotonNetwork.InRoom)
        {
            Debug.Log("Not in room");
            if (PhotonNetwork.IsConnectedAndReady)
            {
                PhotonNetwork.JoinRandomRoom();
                Debug.Log("Joining random room");
            }
        }
        if (!connected)
        {
            PhotonNetwork.ConnectUsingSettings();
        }
        if (amount <= 0)
        {
            trigger = true;
        }

        // Check if resources have been updated
        if (latestAmount != amount)
        {
            Debug.Log("Resource updated: " + resource + " " + amount + " " + latestAmount);
            latestAmount = amount;
            StopAllCoroutines();
            StartCoroutine(TypeText(resource + ":" + amount + extraResourceText()));

            if (ChooseMultiplayer.isMultiplayer)
            {
                photonView.RPC("UpdateMoney", RpcTarget.OthersBuffered, amount); // Call RPC to sync money across clients
            }
        }

        // Check if user has pressed escape
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("QUIT");
            Application.Quit();
        }

        // Game ends when money reaches 0
        if (trigger)
        {
            if (gameObject.name == "money")
            {
                finalScore = amount;
                SceneManager.LoadScene("GameEnd");
            }
        }
    }

    // Coroutine to type text with a delay
    public IEnumerator TypeText(string text)
    {
        moneyText.text = "";
        foreach (char c in text)
        {
            moneyText.text += c;
            yield return new WaitForSeconds(
                typingSpeed + (UnityEngine.Random.Range(1, 20) * 0.003f)
            );
        }
    }

    // Add extra text based on the resource type
    string extraResourceText()
    {
        switch (gameObject.name)
        {
            case "money":
                return "k";
            case "employee_happiness":
                return "/100";
            default:
                return "";
        }
    }

    // Set the initial values based on the resource
    void startingValue()
    {
        switch (gameObject.name)
        {
            case "money":
                amount = 100;
                break;
            case "sales":
                amount = 500;
                break;
            case "employees":
                amount = 10;
                break;
            case "employee_happiness":
                amount = 30;
                break;
        }
    }

    // RPC method to update money across all clients
    [PunRPC]
    void UpdateMoney(int newAmount)
    {
        Debug.Log(gameObject.name + "  " + newAmount + " " + PhotonNetwork.IsMasterClient);
        MoneyScript moneyScript = GetComponent<MoneyScript>();
        if (moneyScript != null)
        {
            moneyScript.amount = newAmount; // Update the money amount
            PlayerPrefs.SetInt(resource, amount); // Save the updated amount
        }
    }
}
