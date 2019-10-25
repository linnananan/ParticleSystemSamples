using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestFactionData : MonoBehaviour
{
    public static FactionData gFactionData;
    void Start()
    {
        gFactionData = gameObject.AddComponent<FactionData>();
        gFactionData.flag[0] = 1;
        gFactionData.flag[1] = 1;
        gFactionData.flag[2] = 1;
        gFactionData.flag[3] = 1;
        gFactionData.flag[4] = 1;
        //Debug.Log(gFactionData.flag.Length);
    }

    void Update()
    {
        
    }
    private void Reset()
    {
        Debug.Log("reset");
    }
}
