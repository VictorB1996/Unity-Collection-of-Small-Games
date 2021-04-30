using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelection_Manager : MonoBehaviour
{
    public Button[] levelButton;

    // Start is called before the first frame update
    void Start()
    {
        int levelAt = PlayerPrefs.GetInt("levelAt", 2);

        for(int i = 0; i < levelButton.Length; i++)
        {
            if(i + 2 > levelAt)
            {
                levelButton[i].interactable = false;
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
