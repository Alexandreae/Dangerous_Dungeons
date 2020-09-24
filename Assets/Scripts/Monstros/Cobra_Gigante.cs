using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cobra_Gigante : MonoBehaviour
{

    public int vida = 5;
    public int ataque = 5;
    public float cd_atk = 5;
    public float dur_atk = 0.7f;
    public GameObject Atk_anim;
    private Vector3 position;
    public Vector3 pos_inicial;
    public Vector3 pos_player;
    public float speed = 1.0f; //how fast it shakes
    public float amount = 1.0f; //how much it shakes
    private float timer = 0;
    private float wait = 0;
    private bool prepping = false;
    private bool attacking = false;
    private bool waiting = true;
    private bool certo = false;

    void Start()
    {
        GameManager.ataque_monstro = ataque;
        GameManager.vida_monstro = vida;
        position = transform.position;
        wait = Random.Range(-(cd_atk*0.4f),(cd_atk*0.4f)) + cd_atk;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.vida_monstro <= 0) {
            Destroy(gameObject);
        }
        if (certo == false) {
            position.x = position.x - 0.1f;
            transform.position = position;
            if (transform.position.x <= pos_inicial.x) {
                certo = true;
            }
        }

        GameManager.prepping = prepping;
        timer += Time.deltaTime;
        if (waiting == true && timer >= wait) {
            wait = Random.Range(-(dur_atk*0.4f),(dur_atk*0.4f)) + dur_atk;
            timer = 0;
            waiting = false;
            prepping = true;

        }
        if (prepping == true) {
            position.x = pos_inicial.x + Mathf.Sin(Time.time * speed) * amount;
            transform.position = position;
            if (timer >= wait) {
                prepping = false;
                attacking = true;
            }
        }

        if (attacking == true) {
            transform.position = pos_inicial;
            wait = Random.Range(-(cd_atk*0.4f),(cd_atk*0.4f)) + cd_atk;
            timer = 0;
            attacking = false;
            waiting = true;
            Instantiate(Atk_anim, pos_player, Quaternion.identity);
        }


    }

}
