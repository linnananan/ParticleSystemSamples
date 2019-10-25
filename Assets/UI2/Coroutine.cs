using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coroutine : MonoBehaviour
{
    //使用c#的迭代器实现协程功能
    IEnumerator WaitAndPrint()
    {
        yield return new WaitForSeconds(5);
        print("WaitAndPrint" + Time.time);
    }

    //www就是网络工具类,Unity用于从网络上下载需要的文件,包括音频,视频,图片等文件的工具类
    //在www加载完后继续执行
    IEnumerator TestWWW()
    {
        string url = "https://ss2.bdstatic.com/70cFvnSh_Q1YnxGkpoWK1HF6hhy/it/u=1345734636,1096966958&fm=26&gp=0.jpg";
        WWW www = new WWW(url);
        yield return www;
    }

    IEnumerator Start()
    {
        print("Starting" + Time.time);
        //链接协程,先执行waitAndPrint
        yield return StartCoroutine(WaitAndPrint());
        print("Done" + Time.time);
    }

    void Update()
    {
        
    }

    //每帧被调用,多次用来回应GUI事件.
    //布局和重绘事件先被执行
    //接下来是为每一次的输入事件执行布局和键盘、鼠标事件
    private void OnGUI()
    {
        
    }

}
