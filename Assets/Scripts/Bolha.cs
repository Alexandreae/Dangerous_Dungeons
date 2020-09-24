using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolha : MonoBehaviour
{

    public float wait = 1f;
    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.defending = true;
    }

    // Update is called once per frame
    void Update()
    {
       timer += Time.deltaTime;
       if (timer > wait)
       {
           timer = 0;
           GameManager.defending = false;
           Destroy(gameObject);
       }
    }
}
