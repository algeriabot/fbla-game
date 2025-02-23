using System.IO;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ProductToSell : MonoBehaviour
{
    public TMP_Text productName;
    public Button button;
    public string sceneName;
    public TextAsset gptPrompt;
    public static string path { get; private set; }


    // Start is called before the first frame update
    void Start()
    {
        Button btn = button.GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        // load data here
        //audioSource.Play()
        path = Path.Combine(Application.persistentDataPath, "GPTsystem.txt");
        File.WriteAllText(path, gptPrompt.text);
        string[] temp = File.ReadAllLines(path);
        string[] arrLine = new string[temp.Length - 1];
        for (int i = 0; i <= temp.Length - 2; i++)
        {
            arrLine[i] = temp[i];
        }
        File.WriteAllLines(path, arrLine);
        using (StreamWriter writer = new StreamWriter(path, true))
        {
            writer.WriteLine("Product Name: " + productName.text);
        }
        File.ReadAllText(path);
        Debug.Log(File.ReadAllText(path));
        SceneManager.LoadScene(sceneName);
    }
}
