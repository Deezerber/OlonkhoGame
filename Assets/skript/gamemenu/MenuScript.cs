using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject levelChanger;
    public GameObject settingsButton;


    public void OnClickStart()
    {
        
        levelChanger.SetActive(true);

    }
    public void levelBttns(int level)
    {
        SceneManager.LoadScene(level);
    }

    public void settingsClick()
    {

        settingsButton.SetActive(true);

    }
}
