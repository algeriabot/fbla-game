using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Threading;
public class ButtonAction : MonoBehaviour
{
    public Button button;
	public static string lastPressed;

	void Start () {
		Button btn = button.GetComponent<Button>();
		btn.onClick.AddListener(OnClick);
	}

	void OnClick(){
		if(ChatGPT.newEventTriggered)
		lastPressed = button.name;
		//Debug.Log(lastPressed);
		GameObject.Find("No").SetActive(false);
        GameObject.Find("Yes").SetActive(false);
	}
}
