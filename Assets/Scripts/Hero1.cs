using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero1 : MonoBehaviour
{

    public int vida = 50;
    public int ataque = 5;
    public float cd_atk = 2;
    public float cd_def = 2;
    public float move_speed = 25.0f;
    public GameObject Atk_anim;
    public GameObject Def_anim;
    public Vector3 pos_monstro;
    private Vector3 position;
    private Vector3 pos_inicial;
    private bool anima = false;
    private bool anima2 = false;
    private int contador = 0;
    private int anda_frente = 5;
    private int anda_tras;
    private AudioSource as_audio;

    
    void Start() {
        anda_tras = anda_frente * 2;
        position = transform.position;
        pos_inicial = transform.position;
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown("a") | Input.GetButtonDown("Fire1")) { // ataque
            if ((GameManager.cd_atk > cd_atk) && GameManager.player_attacking == false) {
                GameManager.player_attacking = true;
                anima = true;
                GameManager.cd_atk = 0;
                Instantiate(Atk_anim, pos_monstro, Quaternion.identity);
            } else {
                as_audio = GetComponent<AudioSource>();
                as_audio.Play();
            }

        }
        if (anima == true) { // movimento do ataque
            position += Vector3.right * move_speed;
            transform.position = position;
            contador += 1;
            if (contador == anda_frente) {
                contador = 0;
                anima = false;
                anima2 = true;
            }
        }
        if (anima2 == true) { // retorno do ataque
            position += Vector3.left * move_speed / 2;
            transform.position = position;
            contador += 1;
            print(anda_tras);
            if (contador == anda_tras) {
                contador = 0;
                anima2 = false;
                GameManager.player_attacking = false;
            }
        }

        if (Input.GetKeyDown("d") | Input.GetButtonDown("Fire2")) { // defesa
            if ((GameManager.cd_def > cd_def) && GameManager.player_attacking == false) {
                GameManager.cd_def = 0;
                Instantiate(Def_anim, pos_inicial, Quaternion.identity);
            } else {
                as_audio = GetComponent<AudioSource>();
                as_audio.Play();
            }

        }

    }
}
