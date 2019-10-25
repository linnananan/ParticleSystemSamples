using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;
using System.Xml.Serialization;
using System.IO;

[InitializeOnLoad]
public class FXLabStarter : EditorWindow
{
    static FXLabStarter()
    {
        EditorApplication.update += RunOnce; 
    }

    private const string Version = "1.2.0";

    private Vector2 scrollPosition;
    private bool displayProDirective;
    private static WWW checkVersion;
    private static FXLabVersion latestVersion;

    static void CheckVersion()
    {
        if (checkVersion == null)
            checkVersion = new WWW("http://www.dras.biz/FXLab/GetVersion");

        if (!checkVersion.isDone)
            return;
        EditorApplication.update -= CheckVersion;

        try
        {
            var serializer = new XmlSerializer(typeof(FXLabVersion));
            using (var stream = new MemoryStream(checkVersion.bytes))
            {
                latestVersion = (FXLabVersion)serializer.Deserialize(stream);
                if (latestVersion.Version != Version)
                {
                    if (EditorPrefs.HasKey("FXLabVersion") && EditorPrefs.GetString("FXLabVersion") == latestVersion.Version)
                        return;

                    DisplayDialog("FXLab Update Available", false);
                }
            }
        }
        catch
        {
        }
    }

    static void RunOnce()
    {
        EditorApplication.update -= RunOnce;

        var startTime = System.Diagnostics.Process.GetCurrentProcess().StartTime;

        if (FXLab.NeedsFXLabProDirective)
        {
            if (!EditorPrefs.HasKey("FXLabProCheckTime") || EditorPrefs.GetString("FXLabProCheckTime") != startTime.ToString())
                DisplayDialog("FXLab & Unity Pro", true);
            EditorPrefs.SetString("FXLabProCheckTime", startTime.ToString());
        }
        else
        {
            if (!EditorPrefs.HasKey("FXLabUpdateCheckTime") || EditorPrefs.GetString("FXLabUpdateCheckTime") != startTime.ToString())
                EditorApplication.update += CheckVersion;
            EditorPrefs.SetString("FXLabUpdateCheckTime", startTime.ToString());
        }
    }

    private static void DisplayDialog(string title, bool displayProDirective)
    {
        var window = (FXLabStarter)EditorWindow.GetWindow(typeof(FXLabStarter), true);
        window.title = title;
        window.displayProDirective = displayProDirective;
        window.maxSize = window.minSize = new Vector2(400, 170);
    }

    void OnGUI()
    {
        if (displayProDirective)
            DisplayProDirectiveInfo();
        else if (latestVersion != null)
            DisplayVersionInfo();
    }

    private void DisplayVersionInfo()
    {
        scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition);

        EditorGUILayout.LabelField("Current Version;", Version);
        EditorGUILayout.LabelField("New Version:", latestVersion.Version);
        EditorGUILayout.Separator();
        EditorGUILayout.LabelField("Changes:");

        var lines = latestVersion.ChangeLog.Split('\n');
        foreach (var line in lines)
            EditorGUILayout.LabelField("", line.Trim());

        EditorGUILayout.Separator();
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("Ok"))
        {
            Close();
        }
        if (GUILayout.Button("Dont show again"))
        {
            Close();
            EditorPrefs.SetString("FXLabVersion", latestVersion.Version);
        }
        EditorGUILayout.EndHorizontal();


        EditorGUILayout.EndScrollView();
    }

    private void DisplayProDirectiveInfo()
    {
        if (FXLab.NeedsFXLabProDirective)
            EditorGUI.HelpBox(new Rect(10, 10, position.width - 20, position.height - 20), "Unity Pro and FXLab detected!\n\nYou can enable native RenderTexture support for FXLab which gives you an huge performance boost.\n\nGo into the Other Settings panel of the Player Settings, you will see the Scripting Define Symbols textbox.\n\nAdd:\nFXLAB_PRO\n\nSeparate multiple symbols by semicolons.", MessageType.Info);
        else
        {
            EditorGUI.HelpBox(new Rect(10, 10, position.width - 20, position.height - 20), "Unity Pro and FXLab detected!\n\nYou can now use native RenderTexture with FXLab.", MessageType.Info);
        }
    }
}
