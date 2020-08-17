using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Onevsone()
    {
        //load scene "Level01" 
        SceneManager.LoadScene("LevelOnevsone");
    }

    public void StartGame()
    {
        //load scene "Level01" 
        SceneManager.LoadScene("LevelKI");
    }
    public void QuitGame()
    {
        // Quit Game
        Application.Quit();
    }
}
