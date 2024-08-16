using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Variables private 



    // Variables Public 



    // Methods

    public void LoadeSpiel()
    {
        SceneManager.LoadScene("Spiele");
    }

    public void LoadeMatheLvl()
    {
        SceneManager.LoadScene("MatheAufgaben");
    }
}
