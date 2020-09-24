using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{

    public void PlayIntro ()
    {
        GameManager.sel_musica = 1;
        GameManager.call_musica = true;
        SceneManager.LoadScene("Floresta");
    }
    public void QuitGame ()
    {
        Application.Quit();
    }
}
