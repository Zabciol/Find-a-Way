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
    public GameObject BackToMenuBtn;
    public GameObject BlackBackground;
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
        BackToMenuBtn = GameObject.Find("BackToMenuBtn");
        BlackBackground = GameObject.Find("BlackBackground");
        PauseUI.SetActive(false);
        YouLoseText.SetActive(false);
        RestartBtn.SetActive(false);
        Timer = GameObject.Find("Timer").GetComponent<TextMeshProUGUI>();
        time = 30;
        YouWonText.text = "";
        MenuHide();
    }

    // Update is called once per frame
    void Update()
    {
        TimeUpdate();
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(PauseUI.activeInHierarchy)
            {
                PauseUI.SetActive(false);
                MenuHide();
                Time.timeScale = 1;
            }
            else
            {
                PauseUI.SetActive(true);
                MenuDisplay();
                Time.timeScale = 0;
            }
         }
         
    }

    public void YouLoseDisplay(){
        YouLoseText.SetActive(true);
        MenuDisplay();
    }

    public void YouWonDisplay(){
        YouWonText.text = "YOU WON";
        MenuDisplay();
    }


    public void TimeUpdate(){
        if(time > 0)
        {
            time -= Time.deltaTime;
            TimeDisplay(time);
        }
        else{
            YouLoseText.SetActive(true);
            MenuDisplay();
            Timer.text = "00:00";
        }
    }
    public void MenuDisplay() {
         RestartBtn.SetActive(true);
         BackToMenuBtn.SetActive(true);
         Time.timeScale = 0;
         BlackBackground.SetActive(true);
    }

    public void MenuHide(){
        YouWonText.text = "";
        YouLoseText.SetActive(false);
        RestartBtn.SetActive(false);
        BackToMenuBtn.SetActive(false);
        Time.timeScale = 1;
        BlackBackground.SetActive(false);
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
    public void BackToMenu(){
         SceneManager.LoadScene(0, LoadSceneMode.Single);
         //Time.timeScale = 1;
    }
}

