using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuToggle : MonoBehaviour
{
    public PauseMenuUi mainMenu;
    private bool showCanvas = false;

    private void OnEnable()
    {
        ToggleMenu(showCanvas);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleMenu(!showCanvas);
        }
    }

    private void ToggleMenu(bool show)
    {
        if (show)
        {
            Time.timeScale = 0;
            mainMenu.gameObject.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            mainMenu.gameObject.SetActive(false);
        }

        this.showCanvas = show;
    }
}
