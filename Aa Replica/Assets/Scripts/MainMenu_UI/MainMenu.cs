using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public void GoToLevelSelection()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level_Selection");
    }
}
