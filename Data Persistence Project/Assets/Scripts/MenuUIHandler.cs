using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif
using TMPro;
using UnityEngine.UI;

public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField inputField;
    public TextMeshProUGUI bestScoreText;

    private void Start()
    {
        bestScoreText.text = SaveManager.Instance.LoadBestScore();
    }

    public void StartNew()
    {
        SaveManager.Instance.PlayerName = inputField.GetComponent<TMP_InputField>().text;
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else 
        Application.Quit();
#endif
    }
}