using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClikGenerateSphere : MonoBehaviour
{
    public Canvas canvas;
    public GameObject prefab;
    public InputField inputX;
    public InputField inputY;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void GenerateSphere()
    {
        GameObject sphere = Instantiate(prefab);
        try
        {
            float x = float.Parse(inputX.text);
            float y = float.Parse(inputY.text);
            float z = canvas.planeDistance;
            Vector3 pos = new Vector3(x, y, z);
            sphere.transform.position = Camera.main.ScreenToWorldPoint(pos);
        }
        catch (System.FormatException)
        {

        }
        
    }
    
}
