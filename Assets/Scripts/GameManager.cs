using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int sel_musica = 0; // 0 = main, 1 = floresta
    public static int vida_max = 60;
    public static int vida = 60;
    public static float cd_atk_max = 2;
    public static float cd_atk = 2;
    public static float cd_def_max = 2;
    public static float cd_def = 2;
    public static int ataque_player = 5;
    public static int ataque_monstro;
    public static int vida_monstro = 0;
    public static bool prepping = false;
    public static bool defending = false;
    public static bool player_attacking = false;
    public GameObject monstro1;
    public GameObject monstro2;
    public GameObject monstro3;
    public GameObject boss;
    public GameObject fight;
    public GameObject win;
    public Vector3 pos_monstro;
    public Vector3 pos_fight;
    public static bool create_monster = false;
    private AudioSource as_audio;
    public AudioClip main;
    public AudioClip floresta;
    public AudioClip win_musica;
    private int monster_count;
    private List<GameObject> monstros = new List<GameObject>();
    public static bool win_screen = false;
    public static bool call_musica = false;
    
    //vida_max = 50;
    //vida = vida_max;
    //cd_atk_max = 2;
    //cd_atk = cd_atk_max;
    //cd_def_max = 2;
    //cd_def = cd_def_max;
    //ataque_player = 5;
    //ataque_monstro = 5;
    // Start is called before the first frame update
    void Start()
    {
        monstros.Add(monstro1);
        monstros.Add(monstro2);
        monstros.Add(monstro3);
        musica();
        DontDestroyOnLoad(this.gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        if (call_musica == true) {
            call_musica = false;
            musica();
        }
        if (win_screen == true) {
            win_screen = false;
            create_monster = false;
            victory();
        }
        if (vida_monstro <= 0 && create_monster == true) {
            player_attacking = true;
            create_monster = false;
            Instantiate(fight, pos_fight, Quaternion.identity);
            Invoke("cria_monstro",0.5f);
            Invoke("podeAtacar",2f);
        }

        if (vida <= 0) {
            vida = vida_max;
            sel_musica = 0;
            call_musica = true;
            SceneManager.LoadScene("Intro");
        }
        cd_atk += Time.deltaTime;
        cd_def += Time.deltaTime;
    }

    void podeAtacar() {
        player_attacking = false;
    }
    void cria_monstro() {
        if (monster_count == 9) {
            Instantiate(boss, pos_monstro, Quaternion.identity);
        } else {
            create_monster = true;
            monster_count ++;
            Instantiate(monstros[Random.Range(0,3)], pos_monstro, Quaternion.identity);
        }


    }
    void musica() {
        as_audio = GetComponent<AudioSource>();
        as_audio.Stop();
        if (sel_musica == 0) {
            as_audio.PlayOneShot(main,1f);
        } else if (sel_musica == 1) {
            as_audio.PlayOneShot(floresta,1f);
        }

    }

    void victory() {
        as_audio = GetComponent<AudioSource>();
        as_audio.Stop();
        as_audio.PlayOneShot(win_musica,1f);
        Invoke("musica",4f);
        Instantiate(win, pos_fight, Quaternion.identity);
        // troca de screen
    }
}
