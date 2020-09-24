using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Critical : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("destruir",.4f);
    }

    void destruir()
    {
        Destroy(gameObject);
    }
}
