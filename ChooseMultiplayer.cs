using System.Collections;
using System.Threading;
using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChooseMultiplayer : MonoBehaviour
{
    public Button button;
    public static bool isMultiplayer = false;

    //private AudioSource audioSource;
    void Start()
    {
        //audioSource = gameObject.GetComponent<AudioSource>();
        Button btn = button.GetComponent<Button>();
        //btn.onClick.AddListener(OnClick);
    }

    public bool accesorForInspector
    {
        get { return isMultiplayer; }
        set { isMultiplayer = value; }
    }

    private void Update()
    {
        if (isMultiplayer)
        {
            PhotonNetwork.ConnectUsingSettings();
        }
        else
        {
            PhotonNetwork.Disconnect();
        }
    }
}
