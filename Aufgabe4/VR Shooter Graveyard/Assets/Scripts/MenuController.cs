using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void StartBtn()
    {
        SceneManager.LoadScene("SampleScene");

        Debug.Log(" wurde gedr�ckt");
    }

    public void BeendenBtn()
    {
        Application.Quit();
    }
}
