using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Tabtale.TTPlugins;

public class GameManager : MonoBehaviour
{
    public PlayerMovement playerMovement;
    private void Awake()
    {
        // Initialize CLIK Plugin
        TTPCore.Setup();
        // Your code here
        playerMovement.initialized = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void RestartButton()
    {
        SceneManager.LoadScene(0);
    }
}
