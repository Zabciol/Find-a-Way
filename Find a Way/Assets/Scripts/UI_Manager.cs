using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{
    public GameObject PauseUI;
    public GameObject YouLoseText;
    public GameObject RestartBtn;
    public TextMeshProUGUI Timer;
    public TextMeshProUGUI YouWonText;
    public Animator FadeImageAnimate;
    public Animator FadeBlackAnimate;
    public float time;
    float seconds;
    float minutes;

    public static UI_Manager Instance;

     private void Awake() {
        Instance = this;
        
    }
    // Start is called before the first frame update
    void Start()
    {
        PauseUI =  GameObject.Find("ButtonPause");
        YouLoseText = GameObject.Find("YouLoseTEXT");
        RestartBtn = GameObject.Find("RestartBtn");
        YouWonText = GameObject.Find("YouWonText").GetComponent<TextMeshProUGUI>();
        PauseUI.SetActive(false);
        YouLoseText.SetActive(false);
        RestartBtn.SetActive(false);
        Timer = GameObject.Find("Timer").GetComponent<TextMeshProUGUI>();
        time = 30;
        YouWonText.text = "";
        RestartBtn.SetActive(false);
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
                RestartBtn.SetActive(true);
                Time.timeScale = 0;
            }
         }
         
    }

    public void Resume(){
        PauseUI.SetActive(false);
        RestartBtn.SetActive(falses);
        Time.timeScale = 1;
    }

    public void YouLoseDisplay(){
        Time.timeScale = 0;
        YouLoseText.SetActive(true);
        RestartBtn.SetActive(true);
    }

    public void YouWonDisplay(){
        YouWonText.text = "YOU WON";
        Time.timeScale = 0;
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
    public void RemoveTime() {
        time-= 5;
    }

    public void Restart() {
         SceneManager.LoadScene(1, LoadSceneMode.Single);
         Time.timeScale = 1;
    }
    
    public void FadeIn() {
        FadeImageAnimate.Play("");
    }
}

