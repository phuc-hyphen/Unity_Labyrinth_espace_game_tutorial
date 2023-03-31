using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour
{
    public GameObject pauseMenu;
    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController fpsController;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {

            if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
                pauseMenu.SetActive(false);
                fpsController.gameObject.SetActive(true);
            }
            else
            {
                Time.timeScale = 0;
                pauseMenu.SetActive(true);
                fpsController.gameObject.SetActive(false);
            }
        }
    }
}
