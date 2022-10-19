using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{

    int TotalFood;
    int FoodCollected;


    public static GameManager Instance {get; private set;}

     private void Awake(){
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        TotalFood = GameObject.FindGameObjectsWithTag("Food").Length;
         Debug.Log("TotalFood");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FoodColect(){
        FoodCollected++;
        Debug.Log("Food Collected");
    }
}
