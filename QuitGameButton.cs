using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Threading;
public class QuitGameButton : MonoBehaviour
{
    public Button button;

	void Start () {
		Button btn = button.GetComponent<Button>();
		btn.onClick.AddListener(OnClick);
	}

	private void OnClick(){
		// save data here
        #if UNITY_EDITOR
        //if in the editor, just stop running
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif

	}
}
