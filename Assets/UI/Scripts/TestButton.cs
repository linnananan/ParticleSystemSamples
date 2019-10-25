using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestButton : MonoBehaviour
{
    public Text text;
    public GameObject prefab;
    public InputField fieldX;
    public InputField fieldY;


    private float sliderValue = 1.0f;
    private float maxSliderValue = 10.0f;


    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OnButtonClikHandler()
    {
        text.text = Random.value.ToString();
        GameObject sphere = Instantiate(prefab);

        float x, y;

        try
        {
            x = float.Parse(fieldX.text);
            y = float.Parse(fieldY.text);
            
            Vector3 pos = new Vector3(x, y, 20);
            sphere.transform.position = Camera.main.ScreenToWorldPoint(pos);
            sphere.AddComponent<DestroyObject>();
        }
        catch(System.FormatException e)
        {

        }
    }


}
