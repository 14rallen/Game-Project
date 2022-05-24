using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private float speed = 50;
    private bool isRunning = false;
    private float collisionDistance = 4f;

    private new Rigidbody rigidbody;
    private SpriteRenderer sprites;

    public Animator animations;
    public Menus menus;
    public LevelManager levelManager;
    //public ExperiencePopUp experiencePopUp;
    //public SkillManager skillManager;
    private const string animationRunningName = "running";
    private const string animationIdleName = "idle";
    private GameObject global;
    private Controls controls;
    public PlayerCollider PlayerCollider;
    private IDialoguable dialogue;

    void Start()
    {
        levelManager = gameObject.GetComponentInChildren<LevelManager>();
        //experiencePopUp = new ExperiencePopUp();
        rigidbody = GetComponent<Rigidbody>();
        sprites = GetComponent<SpriteRenderer>();
        //speed *= GlobalValues.global_Speed;
        animations.Play(animationIdleName);
        global = GameObject.Find("Global");
        controls = global.GetComponent<Controls>();
    }

    void Update()
    {
        if(controls.x)
        {
            //experiencePopUp.GainExp(13,23,40);
            levelManager.GainExperience(120);
            //levelManager.LevelUp();
            //Debug.Log("Player level is " + levelManager.Level);
        }

        if(controls.inventory)
        {
            menus.OpenMenus();
        }
        if (controls.quests)
        {
            menus.OpenMenus(MenusType.Quests);
        }
        if(controls.skills)
        {
            menus.OpenMenus(MenusType.Skills);
        }
        if(controls.interact)
        {
            if(GameManager.GetDialoguable() != null)
            {
                dialogue = GameManager.GetDialoguable();
                dialogue.BeginDialogue();
            }
        }
    }

    public SkillManager GetSkillManager()
    {
        return this.GetComponentInChildren<SkillManager>();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        float moveHorizontal = controls.horizontal_Direction;
        float moveVertical = controls.vertical_Direction;

        if(controls.shift_press)
        {
            speed = 10;
        }
        else
        {
            speed = 50;
        }

        Vector3 direction = new Vector3(controls.horizontal_Direction, 0, controls.vertical_Direction);
        Vector3 castX;
        Vector3 castZ;

        float dirX = 0;
        float dirZ = 0;

        if(controls.horizontal_Direction > 0)
        {
            dirX = 1;
        }
        else if(controls.horizontal_Direction < 0)
        {
            dirX = -1;
        }
        else
        {
            dirX = 0;
        }

        if (controls.vertical_Direction > 0)
        {
            dirZ = 1;
        }
        else if (controls.vertical_Direction < 0)
        {
            dirZ = -1;
        }
        else
        {
            dirZ = 0;
        }

        castX = new Vector3(dirX, 0, 0);
        castZ = new Vector3(0, 0, dirZ);

        direction.Normalize();
        //Vector3 offSet = new Vector3(transform.position.x + (controls.horizontal_Direction * 7), transform.position.y, transform.position.z + (controls.vertical_Direction * 7));
        Debug.DrawRay(transform.position, transform.TransformDirection(direction * 60));
        Debug.DrawRay(transform.position, transform.TransformDirection(castX * 60));
        Debug.DrawRay(transform.position, transform.TransformDirection(castZ * 60));

        bool directionCast = Physics.Raycast(transform.position, direction, collisionDistance);
        bool xCast = Physics.Raycast(transform.position, castX, collisionDistance);
        bool zCast = Physics.Raycast(transform.position, castZ, collisionDistance);

        if ((moveHorizontal != 0 || moveVertical != 0) && !(xCast || zCast))
        {
            isRunning = true;
            Vector3 movement = new Vector3(moveHorizontal * speed * Time.deltaTime, 0, moveVertical * 75 * Time.deltaTime);

            rigidbody.transform.position += movement;
            rigidbody.transform.position.Normalize();

            animations.Play(animationRunningName);

            if(moveHorizontal < 0)
            {
                sprites.flipX = true;
                PlayerCollider.TransformCollider(DirectionType.Left);
            }
            else if(moveHorizontal > 0)
            {
                sprites.flipX = false;
                PlayerCollider.TransformCollider(DirectionType.Right);
            }

            if(moveVertical < 0)
            {
                PlayerCollider.TransformCollider(DirectionType.Down);
            }
            else if(moveVertical > 0)
            {
                PlayerCollider.TransformCollider(DirectionType.Up);
            }
        }
        else
        {
            isRunning = false;
            animations.Play(animationIdleName);
        }
    }
}
