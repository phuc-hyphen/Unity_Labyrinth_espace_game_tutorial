using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
    public TMP_Text bestScore;
    public void Start()
    {
        LoadBestScore();
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
#if UNITY_EDITOR // If we are in the Unity Editor ( # = directive)
        UnityEditor.EditorApplication.isPlaying = false; // Stop playing the game
#else // If we are not in the Unity Editor
        Application.Quit(); // Quit the game
#endif
    }
    public void LoadBestScore()
    {
        if (PlayerPrefs.HasKey("bestScore"))
            bestScore.text = "Best score: " + PlayerPrefs.GetInt("bestScore").ToString() + "s";
        else
            bestScore.text = "No best score yet";
    }
}
