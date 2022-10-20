using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
    // Start is called before the first frame update
     public GameObject NextLevel;
    // Start is called before the first frame update
     public static UI_Manager Instance;

     
    void Start()
    {
        NextLevel =  GameObject.Find("PlayBtn");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void nextLevel() {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
}
