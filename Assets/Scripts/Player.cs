using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Animator anim;
    public float jumpforce;
    private Rigidbody2D willyrb2d;
    [SerializeField] private TimeDeltaTime Timer;
    private float positionChange;
    public bool jump = false;
    [SerializeField] public LayerMask WhatIsGround;
    [SerializeField] public Transform isGroundCheck;
    [SerializeField] private float GroundedRadius = .2f;
    public bool isGrounded = true;
    [SerializeField] private float maxJumpTime = 1f;
    private float jumpTimeCounter;
    [HideInInspector]
    public float dashtimer;
    public float maxdashtimer = 4;
    //public ParticleSystem dashEffect;
    public GameObject dasheffect;
    public bool touchjump = false;
    public bool dashtouch = false;
    private int Letouch;
    private int Ritouch;
    public Image dashbar;
    public MenuScripts Menu;
    
    void Start()
    {
        Timer = FindObjectOfType<TimeDeltaTime>();
        willyrb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        dashtimer = 0;
        dashbar.fillAmount = Mathf.Abs(dashtimer / maxdashtimer);
    }
    void Update()
    {
        if (!Menu.isPause)
        {
            for (int i = 0; i < Input.touches.Length; i++)
            {
                if (Input.touches[i].position.x > Screen.width / 2)
                {
                    Letouch = i;
                }
                else { Ritouch = i; }

            }
            if (dashtimer > 0)
            {
                dashbar.fillAmount = Mathf.Abs(dashtimer / maxdashtimer);
            }
            else { dashbar.fillAmount = Mathf.Abs(0); }

            if (!Timer.stop && (Input.GetButtonDown("Fire1") || (Input.touchCount > Ritouch && Input.GetTouch(Ritouch).phase == TouchPhase.Began && Input.touches[Ritouch].position.x < Screen.width / 2)))
            {
                if (dashtimer <= 0)
                {
                    StartCoroutine(Timer.Dash());
                    FindObjectOfType<AudioManager>().Play("Dash");
                    dashtimer = maxdashtimer;
                }
            }
            if (dashtimer > 0)
                dashtimer -= Time.deltaTime;


            isGrounded = Physics2D.OverlapCircle(isGroundCheck.position, GroundedRadius, WhatIsGround);
           

            anim.SetBool("jump", isGrounded);
            if ((Input.GetButtonDown("Jump") || (Input.touchCount > Letouch && Input.GetTouch(Letouch).phase == TouchPhase.Began && Input.touches[Letouch].position.x > Screen.width / 2)) && isGrounded && !Timer.stop)
            {
                jumpTimeCounter = maxJumpTime;
                jump = true;
                FindObjectOfType<AudioManager>().Play("Jump");
            }
            if ((Input.GetButton("Jump") || Input.touchCount > Letouch) && jump && !Timer.stop)
            {
                if (jumpTimeCounter > 0)
                {
                    willyrb2d.velocity = Vector2.up * jumpforce;
                    jumpTimeCounter -= Time.deltaTime;
                }
                else
                {
                    jump = false;
                }
            }
            else { jump = false; }

            if (Timer.isDash == true)
            {
                dasheffect.SetActive(true);

            }
            else
            {
                dasheffect.SetActive(false);
            }
        }
    }
}
    
