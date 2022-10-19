using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox_Interactions : MonoBehaviour
{
    // Start is called before the first frame update
   public GameObject ParticleToSpawn;
    void Start()
    {
    }

    // Update is called once per frame
   private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Food")
        {
            //Instantiate(ParticleToSpawn, other.transform.position, other.transform.rotation);
            Debug.Log("Collide With Food");
            other.gameObject.SetActive(false);
            GameManager.Instance.FoodColect();
        }
        if(other.gameObject.tag == "CarDrive")
        {
            Debug.Log("Collide With Car");
            UI_Manager.Instance.YouLoseDisplay();
        }
       


    }
}
