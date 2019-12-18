using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour
{
    public Canvas pauseScreen;
    public Canvas keysUI;

    public Text text;

    bool paused = false;
    bool notRun = false;
    bool upDown = false;

    public void Start()
    {
        StartCoroutine(SizeHandler());
    }

    public IEnumerator SizeHandler()
    {
        for (;;)
        {
            if (paused)
            {
                while (!upDown)
                {
                    text.fontSize += 1;
                    if (text.fontSize >= 185)
                    {
                        upDown = true;
                    }
                    yield return null;
                }
                while (upDown)
                {
                    text.fontSize -= 1;
                    if (text.fontSize <= 135)
                    {
                        upDown = false;
                    }
                    yield return null;
                }
            }
            yield return null;
        }
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            paused = TogglePause();
        }
        if (paused && !notRun)
        {
            notRun = true;
            pauseScreen.gameObject.SetActive(true);
            keysUI.gameObject.SetActive(false);
        }
        else if (!paused)
        {
            pauseScreen.gameObject.SetActive(false);
            keysUI.gameObject.SetActive(true);
        }
    }
    private bool TogglePause()
    {
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
            notRun = false;
            return false;
        }
        else
        {
            Time.timeScale = 0f;
            notRun = false;
            return true;
        }
    }
}
