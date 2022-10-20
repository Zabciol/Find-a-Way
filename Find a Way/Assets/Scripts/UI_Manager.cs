using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_Manager : MonoBehaviour
{
    public GameObject PauseUI;
    public GameObject YouLoseText;
    public TextMeshProUGUI Timer;
    public TextMeshProUGUI YouWonText;
    public float time;
    float seconds;
    float minutes;

    public static UI_Manager Instance;

     private void Awake() {
        Instance = this;
        PauseUI =  GameObject.Find("ButtonPause");
        YouLoseText = GameObject.Find("YouLoseTEXT");
        YouWonText = GameObject.Find("YouWonText").GetComponent<TextMeshProUGUI>();
    }
    // Start is called before the first frame update
    void Start()
    {
         PauseUI.SetActive(false);
         YouLoseText.SetActive(false);

         Timer = GameObject.Find("Timer").GetComponent<TextMeshProUGUI>();
         time = 30;
         YouWonText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        TimeUpdate();
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

    public void YouLoseDisplay(){
        Time.timeScale = 0;
        YouLoseText.SetActive(true);
    }

    public void YouWonDisplay(){
        Time.timeScale = 0;
        YouWonText.text = "YOU WON";
    }


    public void TimeUpdate(){
        if(time > 0)
        {
            time -= Time.deltaTime;
            TimeDisplay(time);
        }
        else{
            YouLoseText.SetActive(true);
            Time.timeScale = 0;
            Timer.text = "00:00";
        }
    }

    public void  TimeDisplay(float time)
    {
        seconds = Mathf.FloorToInt(time % 60);
        minutes = Mathf.FloorToInt(time / 60);
        string TimeFixed = string.Format("{0:00}:{1:00}",minutes,seconds);
        Timer.text = TimeFixed;   
    }

    public void AddTime() {
        time+= 10;
    }
    
}

