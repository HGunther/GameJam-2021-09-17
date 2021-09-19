using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuMain : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonStartGameClicked(){
        Debug.Log("Start game clicked");
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    public void OnButtonCreditsClicked(){
        Debug.Log("Credits clicked");
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }

    public void OnButtonQuitClicked(){
        Debug.Log("Quit clicked");
        Application.Quit();
    }
}
