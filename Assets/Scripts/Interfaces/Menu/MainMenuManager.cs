using System.Collections;
using System.Collections.Generic;

#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
  // References to UI buttons
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _quitButton;

    private void Awake()
    {
        // Set which methods the buttons invoke when pressed
        if (_startButton)
            _startButton.onClick.AddListener(StartGame);
        else
            Debug.Log("No Play button defined.");

        if (_quitButton)
            _quitButton.onClick.AddListener(QuitGame);
        else
            Debug.Log("No Quit button defined.");
    }

    // Método para iniciar el juego
    public void StartGame()=> SceneManager.LoadScene("Game Scene");

    // Método para salir del juego
    public void QuitGame()
    {
        Application.Quit(); // Salir del juego en compilación independiente

        #if UNITY_EDITOR
        // Solo se ejecuta en el editor de Unity
        EditorApplication.ExitPlaymode(); // Detener el modo de juego en el Editor
        #endif
    }
}
