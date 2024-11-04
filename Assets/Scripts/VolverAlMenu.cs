using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VolverAlMenu : MonoBehaviour
{
    public void Return()
    {
        SceneManager.LoadScene("Scenes/Start");
    }
}
