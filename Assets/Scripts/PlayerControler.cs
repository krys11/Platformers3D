using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    // Mes variables
    private CharacterController cc;
    private Animator anim;
    private bool isWalking;
    public float movespeed;
    public float jumpforce;
    public float gravity;
    private Vector3 moveDirection;
    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        // calcul direction
        moveDirection = new Vector3(Input.GetAxis("Horizontal") * movespeed, moveDirection.y, Input.GetAxis("Vertical") * movespeed);
        
        // application de la graviter
        moveDirection.y -= gravity * Time.deltaTime;

        // mise en marche de la direction
        cc.Move(moveDirection * Time.deltaTime);

        // faire sauter le personnage
        if(Input.GetButtonDown("Jump") && cc.isGrounded){
            moveDirection.y = jumpforce;
        }

        // faire regarder le personnage dans la direction il bouge
        if(moveDirection.x != 0 || moveDirection.z != 0){
            isWalking = true;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(moveDirection.x, 0, moveDirection.z)), 0.2f);
        }else{
            isWalking = false;
        }

        anim.SetBool("isWalking", isWalking);
    }
}
