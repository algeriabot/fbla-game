using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResourceUpdater : MonoBehaviour
{
    public List<GameObject> rootObjects = new List<GameObject>();
    public TMP_Text eventText;
    bool triggered = false;
    private AudioSource goodAudioSource;

    void Start()
    {
        goodAudioSource = GameObject.Find("Audio").GetComponent<AudioSource>();
    }

    void Update()
    {
        moveThroughObjects();
    }

    void moveThroughObjects()
    {
        for (int i = 0; i < rootObjects.Count; i++)
        {
            GameObject gO = rootObjects[i];
            updateResources(gO);
        }

        if (triggered)
        {
            ButtonAction.lastPressed = null;
            ChatGPT.newEventTriggered = false;
        }
    }

    void updateResources(GameObject gObject)
    {
        if (ButtonAction.lastPressed != null && ChatGPT.newEventTriggered)
        {
            if (ButtonAction.lastPressed == "Yes")
            {
                eventText.text = ChatGPT.yesData.response;
                switch (gObject.name)
                {
                    case "money":
                        UpdateStat(gObject, ChatGPT.yesData.money);
                        PlayAudio(ChatGPT.yesData.money);
                        break;
                    case "sales":
                        UpdateStat(gObject, ChatGPT.yesData.sales);
                        break;
                    case "employees":
                        UpdateStat(gObject, ChatGPT.yesData.employees);
                        break;
                    case "employee_happiness":
                        UpdateStat(gObject, ChatGPT.yesData.employee_happiness);
                        break;
                }
            }
            else if (ButtonAction.lastPressed == "No")
            {
                eventText.text = ChatGPT.noData.response;
                switch (gObject.name)
                {
                    case "money":
                        PlayAudio(ChatGPT.noData.money);
                        UpdateStat(gObject, ChatGPT.noData.money);
                        break;

                    case "sales":
                        UpdateStat(gObject, ChatGPT.noData.sales);
                        break;
                    case "employees":
                        UpdateStat(gObject, ChatGPT.noData.employees);
                        break;
                    case "employee_happiness":
                        UpdateStat(gObject, ChatGPT.noData.employee_happiness);
                        break;
                }
            }
            triggered = true;
        }
        else
        {
            triggered = false;
        }
    }

    void UpdateStat(GameObject gObject, int value)
    {
        MoneyScript moneyScript = gObject.GetComponent<MoneyScript>();
        if (moneyScript != null)
        {
            moneyScript.amount += value;
        }
    }

    void PlayAudio(int moneyValue)
    {
        if (moneyValue > 0)
        {
            goodAudioSource.Play();
        }
        else if (moneyValue < 0)
        {
            gameObject.GetComponent<AudioSource>().Play();
        }
    }
}


// using System.Collections;
// using System.Collections.Generic;
// using Photon.Pun;
// using TMPro;
// using UnityEngine;

// public class ResourceUpdater : MonoBehaviour
// {
//     // Start is called before the first frame update
//     public List<GameObject> rootObjects = new List<GameObject>();
//     public TMP_Text eventText;
//     bool triggered = false;
//     private AudioSource goodAudioSource;

//     void Start()
//     {
//         goodAudioSource = GameObject.Find("Audio").GetComponent<AudioSource>();
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         moveThroughObjects();
//         //Debug.Log("last pressed:" + ButtonAction.lastPressed + " newEvent:" + ChatGPT.newEventTriggered + " YesData:" + ChatGPT.yesData);
//     }

//     void moveThroughObjects()
//     {
//         // get root objects in scene

//         // iterate root objects and do something
//         for (int i = 0; i < rootObjects.Count; i++)
//         {
//             GameObject gO = rootObjects[i];
//             updateResources(gO);
//             //Debug.Log(i);
//         }
//         if (triggered)
//         {
//             ButtonAction.lastPressed = null;
//             ChatGPT.newEventTriggered = false;
//         }
//     }


//     void updateResources(GameObject gObject)
//     {
//         if (ButtonAction.lastPressed != null && ChatGPT.newEventTriggered)
//         {
//             if (ButtonAction.lastPressed == "Yes")
//             {
//                 eventText.text = ChatGPT.yesData.response;
//                 switch (gObject.name)
//                 {
//                     case "money":
//                         PhotonView photonView = gObject.GetComponent<PhotonView>();
//                         if (photonView.IsMine) // Ensure only the owner updates
//                         {
//                             MoneyScript moneyScript = gObject.GetComponent<MoneyScript>();
//                             int newAmount = moneyScript.amount + ChatGPT.yesData.money;

//                             photonView.RPC("UpdateMoney", RpcTarget.AllBuffered, newAmount);
//                         }
//                         if (ChatGPT.yesData.money > 0)
//                         {
//                             goodAudioSource.Play();
//                         }
//                         else
//                             gameObject.GetComponent<AudioSource>().Play();
//                         break;
//                     case "sales":
//                         gObject.GetComponent<MoneyScript>().amount += ChatGPT.yesData.sales;
//                         break;
//                     case "employees":
//                         gObject.GetComponent<MoneyScript>().amount += ChatGPT.yesData.employees;
//                         break;
//                     case "employee_happiness":
//                         gObject.GetComponent<MoneyScript>().amount += ChatGPT
//                             .yesData
//                             .employee_happiness;
//                         break;
//                 }
//             }
//             else if (ButtonAction.lastPressed == "No")
//             {
//                 eventText.text = ChatGPT.noData.response;
//                 switch (gObject.name)
//                 {
//                     case "money":
//                         gObject.GetComponent<MoneyScript>().amount += ChatGPT.noData.money;
//                         if (ChatGPT.noData.money > 0)
//                         {
//                             goodAudioSource.Play();
//                         }
//                         else
//                             gameObject.GetComponent<AudioSource>().Play();
//                         break;
//                     case "sales":
//                         gObject.GetComponent<MoneyScript>().amount += ChatGPT.noData.sales;
//                         break;
//                     case "employees":
//                         gObject.GetComponent<MoneyScript>().amount += ChatGPT.noData.employees;
//                         break;
//                     case "employee_happiness":
//                         gObject.GetComponent<MoneyScript>().amount += ChatGPT
//                             .noData
//                             .employee_happiness;
//                         break;
//                 }
//             }
//             triggered = true;
//         }
//         else
//             triggered = false;
//     }
// }
