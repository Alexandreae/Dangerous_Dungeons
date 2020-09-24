using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("destruir",4f);
    }

    void destruir()
    {
        GameManager.sel_musica = 0;
        GameManager.call_musica = true;
        SceneManager.LoadScene("Intro");
        Destroy(gameObject);
    }
}