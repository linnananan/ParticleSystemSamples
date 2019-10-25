using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Rigidbody rb;
    public int count;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        Debug.Log("onStart");
    }

    void Update()
    {
        count++;
        //Debug.Log(count);
        //Destroy(gameObject);
        DestroyImmediate(gameObject);
        Debug.Log("UpdateDestroy");
    }

    private void OnDestroy()
    {
        Debug.Log("onDestroy");
    }

    private void FixedUpdate()
    {
        rb.AddForce(Vector3.up);
    }

    private void LateUpdate()
    {
        //Debug.Log(count);
    }

    //private void OnBecameInvisible()
    //{
    //    //this.gameObject.GetComponent<Renderer>().enabled = false;
    //}
    //private void OnBecameVisible()
    //{
    //    //Debug.Log("visible");
    //    enabled = false;//使这个脚本不执行
    //}

    private void Awake()
    {
        Debug.Log("awake");
    }

    private void OnEnable()
    {
        Debug.Log("onEnable");
    }


}
