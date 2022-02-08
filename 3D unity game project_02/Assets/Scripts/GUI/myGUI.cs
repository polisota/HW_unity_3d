using UnityEditor;
using UnityEngine;

public class myGUI : EditorWindow
{
    private string _message;
    private Rect _buttonRect;
    private Rect _boxRect;
    private Rect _menuBoxRect;
    
    public GUISkin test;
    public Texture2D _icon;
    
    private float _menuBoxWidth = 200f;
    private float _menuBoxHeight = 140f;
    
    [MenuItem("Инструменты/Окна/myGUI 1")]
    public static void ShowMyWindow()
    {
        // Отрисовываем окно для данного класса, не прикреплённое с именем
        GetWindow(typeof(myGUI), false, "MyGUI");
    }
#if UNITY_EDITOR
    void OnGUI()
    {
        var halfWithScreen = Screen.width / 2;
        var halfHeightScreen = Screen.height / 2;
        
        GUI.skin = test;
        _menuBoxRect =
            new Rect(
                halfWithScreen - (_menuBoxWidth / 2),
                halfHeightScreen - (_menuBoxHeight / 2),
                _menuBoxWidth,
                _menuBoxHeight
                );

        // отрисовка панели с текстом
        GUI.Box(_menuBoxRect, "Main Menu");

        bool pressOpen = GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 - 35, 180, 30), "Open");
        // Отрисовка кнопок с выводом сообщений
        if (pressOpen)
            _message = "Open";
        if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 + 0, 180, 30), "Save"))
            _message = "Save";
        if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 + 35, 180, 30), "Load"))
            _message = "Load";

        GUI.Label(new Rect(220, 10, 100, 30), _message);        
      
        //Угловые панели
        GUI.Box(new Rect(0, 0, 100, 50), "Top-left");
        GUI.Box(new Rect(Screen.width - 100, 0, 100, 50), "Top-right");
        GUI.Box(new Rect(0, Screen.height - 50, 100, 50), "Bottom-left");
        GUI.Box(new Rect(Screen.width - 100, Screen.height - 50, 100, 50), "Bottom-right");

        // Иконка в панели
        GUI.Box(new Rect(10, Screen.height / 2 - 125, 100, 100), _icon);

        var content = new GUIContent("Text", _icon, "Time");
        // Иконка в панели с текстом
        GUI.Box(new Rect(10, Screen.height / 2, 100, 100), content);        

        // Группа GUI
        GUI.BeginGroup(new Rect(Screen.width / 2 - 25, 10, 200, 200));
            GUI.Label(new Rect(0, 0, 50, 20), "Hello");
            GUI.Label(new Rect(0, 25, 50, 20), "World!");
        GUI.EndGroup();
    }
#endif
}
