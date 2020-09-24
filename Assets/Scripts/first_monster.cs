using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class first_monster : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.create_monster = true;
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
