using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySphere : MonoBehaviour
{

    void Start()
    {
        Invoke("Destroy", 3);
    }
    void Update()
    {
        
    }
    private void Destroy()
    {
        GameObject.Destroy(this.gameObject);
    }
}
