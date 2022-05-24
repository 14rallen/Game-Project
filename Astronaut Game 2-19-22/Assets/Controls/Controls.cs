using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    public float horizontal_Direction;
    public float vertical_Direction;
    public bool inventory;
    public bool quests;
    public bool skills;
    public bool interact;
    public bool tab_press;
    public bool q_press;
    public bool shift_press;
    public bool x;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal_Direction = Input.GetAxis("Horizontal");
        vertical_Direction = Input.GetAxis("Vertical");

        inventory = Input.GetKeyDown(KeyCode.Tab);
        quests = Input.GetKeyDown(KeyCode.Q);
        skills = Input.GetKeyDown(KeyCode.U);
        //interact = Input.GetKeyDown(KeyCode.E);

        interact = Input.GetButtonDown("Activate");

        tab_press = Input.GetKeyDown(KeyCode.Tab);
        q_press = Input.GetKeyDown(KeyCode.Q);
        shift_press = Input.GetKey(KeyCode.LeftShift);

        x = Input.GetKeyDown(KeyCode.X);

    }
}
