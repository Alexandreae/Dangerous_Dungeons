using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fight : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("destruir",2f);
    }

    void destruir()
    {
        Destroy(gameObject);
    }
}