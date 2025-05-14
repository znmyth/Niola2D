using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // اضافه کردن مدیریت صحنه‌ها

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;

    public void quit()
    {
        Application.Quit();
    }

    public void restart() // تغییر نام متد به Restart
    {
        Time.timeScale = 1f; // از حالت توقف خارج شود
        SceneManager.LoadScene("level1"); // بارگذاری مرحله 1
    }

    void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pauseMenu.activeSelf)
            {
                Time.timeScale = 0f;
                pauseMenu.SetActive(true);
                Cursor.visible = true;
            }
            else
            {
                Time.timeScale = 1f;
                pauseMenu.SetActive(false);
                Cursor.visible = false;
            }
        }
    }
}
