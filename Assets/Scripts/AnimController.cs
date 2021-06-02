using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class AnimController : MonoBehaviour
{

    public void ReplayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ShowMenu()
    {
        SceneManager.LoadScene(0);
    }
}
