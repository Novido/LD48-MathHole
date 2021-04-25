using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public GameObject HowToPanelObject;

    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Return()
    {
        HowToPanelObject.SetActive(false);
    }

    public void ShowHowTo()
    {
        HowToPanelObject.SetActive(true);
    }
}
