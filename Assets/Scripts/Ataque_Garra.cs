using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Ataque_Garra : MonoBehaviour
{
    private AudioSource as_audio;
    public AudioClip defesa;
    public AudioClip ataque;
    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.defending != true) {
            GameManager.vida = GameManager.vida - GameManager.ataque_monstro;
            as_audio = GetComponent<AudioSource>();
            as_audio.PlayOneShot(ataque,1f);
        } else {
            as_audio = GetComponent<AudioSource>();
            as_audio.PlayOneShot(defesa,1f);
        }
        Invoke("destruir",.4f);
    }

    // Update is called once per frame
    void destruir()
    {
        Destroy(gameObject);
    }
}

