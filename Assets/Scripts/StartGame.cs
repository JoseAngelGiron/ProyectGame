using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void StartGameplay()
    {
        Debug.Log("Cambio de escena a Game iniciado");
        SceneManager.LoadScene("Scenes/Project");
    }
}
