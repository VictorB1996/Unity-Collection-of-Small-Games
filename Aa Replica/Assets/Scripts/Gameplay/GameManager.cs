using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool isGameEnded = false;

    private Animator animator;

    public Rotator rotator;
    public SpawnPin spawnPin;
    public Score score;
    
    public int nextSceneLoad;
    

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //End the game when the pin collides with another one
    public void EndGame()
    {
        if(isGameEnded)
            {
                return; //If game is already over, return out of the function
            }
        else
        {
            isGameEnded = true;
            animator.SetTrigger("GameOver");
            rotator.enabled = false;
            spawnPin.enabled = false;
            score.enabled = false;
            if(!animator.GetCurrentAnimatorStateInfo(0).IsName("GameOver"))
                {
                    rotator.rotatorAnimator.SetTrigger("GameOver");
                }

            
        }
    }


    //Pass the level when score reaches 0
    public void LevelPassed()
    {
        if(Score.score == 0)
        {
            animator.SetTrigger("LevelPassed");
            Debug.Log("Level Passed");
            rotator.enabled = false;
            spawnPin.enabled = false;
            score.enabled = false;
            
            //Move to the next level
            SceneManager.LoadScene(nextSceneLoad);

            //Setting Int for Index
            if(nextSceneLoad > PlayerPrefs.GetInt("levelAt"))
            {
                PlayerPrefs.SetInt("levelAt", nextSceneLoad);
            }
        }
    }

}
