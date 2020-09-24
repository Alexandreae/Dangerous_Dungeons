using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ataque_Espada : MonoBehaviour
{
    public GameObject critical;
    public Vector3 pos_crit;
    // Start is called before the first frame update
    void Start()
    {
        print("oioioi");
        print(GameManager.prepping);
        if (GameManager.prepping != true) {
            GameManager.vida_monstro = GameManager.vida_monstro - GameManager.ataque_player;
            Invoke("destruir",.4f);

        } else {
            Instantiate(critical, pos_crit, Quaternion.identity);
            GameManager.vida_monstro = GameManager.vida_monstro - GameManager.ataque_player * 2;
            Invoke("destruir",.4f);
        }
        
    }

    // Update is called once per frame
    void destruir()
    {
        Destroy(gameObject);
    }
}
