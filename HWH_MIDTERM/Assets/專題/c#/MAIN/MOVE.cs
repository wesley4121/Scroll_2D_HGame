﻿using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;

public class MOVE : MonoBehaviour
{
    public static Flowchart s_PlayerFlowChartMoveSwitch;
    public static bool PlayerRun;
    public static bool PlayerWalk;
    public static bool PlayerIdle;
    public static float PlayerMoveBanlance;
    public float movespeed;
    public float runspeed;
    public int idlewait = 2;
    private Transform m_Transform;
    private Vector2 moveDir;
    private Animator m_animator;
    private Rigidbody2D m_rigidbody2D;

    void Start()
    {
        PlayerIdle = true;
        m_Transform = GetComponent<Transform>();
        runspeed = 2;
        movespeed = 1;
        m_animator = GetComponent<Animator>();
        m_rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        
            m_rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;



            if (Input.GetKey(KeyCode.RightArrow))            //右移動
            {
                PlayerIdle = false;
                PlayerWalk = true;
                m_Transform.localScale = new Vector3(-1f, 1f, 1f);
                moveDir.x = movespeed;
            }

            if (Input.GetKey(KeyCode.LeftArrow))            //左移動
            {
                PlayerIdle = false;
                PlayerWalk = true;
                m_Transform.localScale = new Vector3(1f, 1f, 1f);
                moveDir.x = -movespeed;
            }



            if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.LeftShift))            //右跑
            {
                PlayerRun = true;
                PlayerWalk = false;
                PlayerIdle = false;
                PlayerMoveBanlance += 1 * Time.deltaTime;
                moveDir.x = runspeed * 3F;
            }
            else if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.LeftShift))            //左跑
            {
                PlayerRun = true;
                PlayerWalk = false;
                PlayerIdle = false;
                PlayerMoveBanlance += 1 * Time.deltaTime;
                moveDir.x = -runspeed * 3F;
            }
            else
            {
                PlayerRun = false;
            }



            if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))            //左右停止移動
            {
                PlayerRun = false;
                PlayerIdle = true;
                PlayerWalk = false;
                PlayerMoveBanlance = 0;
                moveDir = Vector2.zero;


            }
            moveDir.y = m_rigidbody2D.velocity.y;
            m_rigidbody2D.velocity = moveDir;
            /* else
             {
                 if (PlayerWalk)
                 {
                     PlayerIdle = true;
                     PlayerRun = false;
                     PlayerWalk = false;
                 }
                 else if (PlayerRun)
                 {
                     PlayerIdle = true;
                     PlayerRun = false;
                     PlayerWalk = false;
                 }

                 m_rigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
                 moveDir.x = 0;
             }*/


        }


}
