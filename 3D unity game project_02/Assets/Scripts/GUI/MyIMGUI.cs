using UnityEngine;
using System.Collections;
using UnityEditor;

public class MyIMGUI : EditorWindow
{
    // Переменные хранения текста полей
    private string[] textMass = { "Hello World", "Hello World" };

    // Переключатель
    private bool toggleBool = true;

    // Выбранный тулбар, имена тулбаров
    private int toolbarInt = 0;
    private string[] toolbarStrings = { "Toolbar1", "Toolbar2", "Toolbar3", "Toolbar4" };

    // Многострочный тулбар, Имена тулбаров
    private int selectionGridInt = 0;
    private string[] selectionStrings = { "Grid 1", "Grid 2", "Grid 3", "Grid 4" };

    // Значения горизонтального и вертикаольного слайдеров
    private float hSliderValue = 0.0f;
    private float vSliderValue = 0.0f;

    // Значения горизонтального и вертикаольного скроллеров
    private float hScrollbarValue;
    private float vScrollbarValue;

    // Размер Скролящегося окна и его содержимое
    private Vector2 scrollViewVector = Vector2.zero;
    private string innerText = "I am inside the ScrollView";

    // Отрисовка окошка
    private Rect windowRect = new Rect(Screen.width / 2 - 90, Screen.height / 2 - 100, 180, 175);

    // Выбранный тулбар
    private int selectedToolbar = 0;
    
    [MenuItem("Инструменты/Окна/MyIMGUI 2")]
    public static void ShowMyWindow()
    {
        // Отрисовываем окно для данного класса, не прикреплённое с именем
        GetWindow(typeof(MyIMGUI), false, "MyIMGUI");
    }

    void OnGUI()
    {
        // Пока нажата, выводит какое-то 
        if (GUI.RepeatButton(new Rect(25, 20, 100, 30), "RepeatButton"))
            Debug.Log("Button pressed right now");
        // Записывание в массив и отрисовка текста
        textMass[0] = GUI.TextField(new Rect(25, 55, 100, 30), textMass[0]);
        textMass[1] = GUI.TextArea(new Rect(25, 90, 100, 30), textMass[1]);

        // Записывания и отрисовка переключателя
        toggleBool = GUI.Toggle(new Rect(25, 150, 100, 30), toggleBool, "Toggle");

        // Отрисовка и запись тулбара и многострочного тулбара
        toolbarInt = GUI.Toolbar(new Rect(150, 25, 250, 30), toolbarInt, toolbarStrings);
        selectionGridInt = GUI.SelectionGrid(new Rect(550, 25, 300, 60), selectionGridInt, selectionStrings, 2);

        //  Отрисовка и запись вертикального и горизонтального слайдеров
        hSliderValue = GUI.HorizontalSlider(new Rect(25, 190, 100, 30), hSliderValue, 0.0f, 10.0f);
        vSliderValue = GUI.VerticalSlider(new Rect(130, 190, 100, 30), vSliderValue, 10.0f, 0.0f);

        //  Отрисовка и запись вертикального и горизонтального скроллеров
        hScrollbarValue = GUI.HorizontalScrollbar(new Rect(25, 250, 100, 30), hScrollbarValue, 1.0f, 0.0f, 10.0f);
        vScrollbarValue = GUI.VerticalScrollbar(new Rect(130, 250, 100, 30), vScrollbarValue, 1.0f, 10.0f, 0.0f);

        //  Отрисовка и запись Скролл вьюшечки
        scrollViewVector = GUI.BeginScrollView(new Rect(25, 300, 100, 100), scrollViewVector, new Rect(0, 0, 400, 400));
        innerText = GUI.TextArea(new Rect(0, 0, 400, 400), innerText);
        GUI.EndScrollView();

        BeginWindows();
        windowRect = GUI.Window(0, windowRect, WindowFunction, "Pause");
        EndWindows();
        
        // Отрисовка и запись выбранного тулбара с обратной связью
        selectedToolbar = GUI.Toolbar(new Rect(550, 300, 200, 30), selectedToolbar, toolbarStrings);

        // вывод сообщений
        if (GUI.changed)
        {
            Debug.Log("GUI was changed");

            switch (selectedToolbar)
            {
                case 0:
                    Debug.Log("First button was active");
                    break;
                case 1:
                    Debug.Log("Second button was active");
                    break;
                case 2:
                    Debug.Log("Third button was active");
                    break;
            }
        }
    }

    // Отрисовка панели с кнопками и выводом сообщений
    void WindowFunction(int windowID)
    {
        if (GUI.Button(new Rect(windowRect.width / 2 - 80, 30, 160, 30), "Continue"))
            Debug.Log("Continue");
        if (GUI.Button(new Rect(windowRect.width / 2 - 80, 65, 160, 30), "Restart"))
            Debug.Log("Restart");
        if (GUI.Button(new Rect(windowRect.width / 2 - 80, 100, 160, 30), "Settings"))
            Debug.Log("Settings");
        if (GUI.Button(new Rect(windowRect.width / 2 - 80, 135, 160, 30), "Exit"))
            Debug.Log("Exit");
        GUI.DragWindow();
    }
}










