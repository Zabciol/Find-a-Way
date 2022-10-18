using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox_Movements : MonoBehaviour
{

    Animator anim;
    CharacterController _Char;
    private float gravityValue = -9.81f;
    bool left;
     bool right;
    // Start is called before the first frame update
    void Start()
    {
        _Char = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        left = Input.GetKey(KeyCode.A);
        right = Input.GetKey(KeyCode.D);
        anim.SetFloat("running" , y);
        anim.SetBool("Left" , left);
        anim.SetBool("Right" , right);

        //Vector3 movement = new Vector3(x, 0,y);
        //movement.y += gravityValue* Time.deltaTime;
       // _Char.Move(movement * Time.deltaTime);
    }
}
