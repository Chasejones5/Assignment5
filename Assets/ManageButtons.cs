using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageButtons : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startWordGame()
    {
        // Reset the score to 0
        PlayerPrefs.SetInt("score", 0);
        SceneManager.LoadScene("wordGame");
    }
    public void LoadStartWordGame()
    {
        SceneManager.LoadScene("wordGameStart");
    }
}
