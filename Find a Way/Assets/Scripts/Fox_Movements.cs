using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox_Movements : MonoBehaviour
{

    Animator anim;
    CharacterController _Char;
    private float gravityValue = -20.81f;
    bool left;
    bool right;
    bool sault;
    bool jump;
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
        sault = Input.GetKey(KeyCode.Q);
        jump = Input.GetKey(KeyCode.Space);
        anim.SetFloat("running" , y);
        anim.SetBool("Left" , left);
        anim.SetBool("Right" , right);
        anim.SetBool("Sault" , sault);
        anim.SetBool("Jump" , jump);

        Vector3 movement = new Vector3(0, 0,0);
        movement.y += gravityValue* Time.deltaTime;
       _Char.Move(movement * Time.deltaTime);
    }
}
