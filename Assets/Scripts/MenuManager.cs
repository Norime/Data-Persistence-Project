using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuManager : MonoBehaviour
{
    public int bestScore;
    public GameObject InputName;
    public TextMeshProUGUI BestScoreText;
    public void Start()
    {
        GameManager.Instance.LoadBestScore();
        InputName = GameObject.Find("PlayerName Input");
        BestScoreText.text = "Best Score: " + GameManager.Instance.BestScorePlayerName + " " + GameManager.Instance.BestScore;
        //var u = GameObject.Find("PlayerName Input").GetComponent<TMP_InputField>().text;
    }
    public void UpdatePlayerName(string playerName)
    {

        GameManager.Instance.playerName = playerName;
    }

    public void LoadGame()
    {
        string playerName = InputName.GetComponent<TMP_InputField>().text;
        if(playerName != "")
        {
            UpdatePlayerName(playerName);
            SceneManager.LoadScene(1);
        }
        else
        {
            Debug.Log("Enter valid name");
        }
    }

    public void Exit()
    {
        GameManager.Instance.SaveBestScore();
        //MainManager.Instance.SaveColor();
        #if UNITY_EDITOR
                EditorApplication.ExitPlaymode();
        #else
                Application.Quit();
        #endif
    }
}
