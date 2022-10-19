using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    public GameObject PauseUI;
    public static UI_Manager Instance;

     private void Awake() {
        Instance = this;
        PauseUI =  GameObject.Find("ButtonPause");
    }
    // Start is called before the first frame update
    void Start()
    {
         PauseUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(PauseUI.activeInHierarchy)
            {
                Resume();
            }
            else
            {
                PauseUI.SetActive(true);
                Time.timeScale = 0;
            }
         }
    }

    public void Resume(){
        PauseUI.SetActive(false);
        Time.timeScale = 1;
    }
}
