using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class ModalMove : MonoBehaviour
{
    public float moveSpeed = 1.2f;
    public Transform targetRight;
    public Transform targetLeft;

    public Transform TargetRightTop;
    public Transform TargetLeftTop;

    public Transform TargetOriganal;

    public Transform TargetLeftHorizontal;
    public Transform TargetRightHorizontal;

    public float stoppingDistance = 0.1f;  // khoảng cách dừng lại

    public bool isMusic;

    bool IstargetRight;
    // bool IsTargetRightHorizontal;

    bool IstargetLeft;
    //bool IsTargetLeftHorizontal;

    public static bool isFiling;
    public GameObject botbia;

    private void Start()
    {
        if (UIManager.Instance.CharacterType == 0)
        {
            botbia.SetActive(true);
        }
        if (UIManager.Instance.CharacterType != 0)
        {
            botbia.SetActive(false);
        }
        isMusic = true; 
        isFiling = false;
        
        //right
        IstargetRight = false;
        //IsTargetRightHorizontal = false;

        //left
        IstargetLeft = false;
        // IsTargetLeftHorizontal = false;

    }
    void Update()
    {

        if (isFiling == false)
        {
            if (isMusic)
            {
                TestMusic.Instance.Play("WaterUp");
                isMusic= false; 
            }
            
            modalMoveBefore();
        }
        if (isFiling == true)
        {
            modalMoveAfter();
        }
    }
    public virtual void modalMoveBefore()
    {
        
        moveToWards(TargetOriganal, moveSpeed);
       
        if (Vector2.Distance(transform.position, TargetOriganal.position) < 0.01f)
        {
            isFiling = true;
        }
      
    }
    public void modalMoveAfter()
    {
        Vector3 acceleration = Input.acceleration;
        if (acceleration.y < 0)
        {
          

            //Angle positive
            if (acceleration.x >= 0.5 && acceleration.x < 1 && IstargetRight == false)
            {

                moveLerp(targetRight);
                TestMusic.Instance.playUpdate("HeavySwallow");
                if (transform.position.y < targetRight.position.y)
                {
                    IstargetRight = true;
                }
            }
            if (acceleration.x > -1 && acceleration.x <= -0.5 && IstargetLeft == false)
            {

                moveLerp(targetLeft);
                TestMusic.Instance.playUpdate("HeavySwallow");
                if (transform.position.y < targetLeft.position.y)
                {
                    IstargetLeft = true;
                }
            }
        }
        else
        {
            {
                //Angle positive
                if (acceleration.x >= 0.7f && acceleration.x < 1 /*&& IsTargetRightHorizontal == false*/)
                {

                    TestMusic.Instance.playUpdate("HeavySwallow");
                    moveLerp(TargetRightHorizontal);
                 
                }
                if (acceleration.x >= 0f && acceleration.x < 0.7f)
                {
                    TestMusic.Instance.playUpdate("HeavySwallow");
                    moveLerp(TargetRightTop);
                  
                }
                //Angle negative
                if (acceleration.x >= -1 && acceleration.x < -0.7 /*&& IsTargetLeftHorizontal == false*/)
                {
                    TestMusic.Instance.playUpdate("HeavySwallow");
                    moveLerp(TargetLeftHorizontal);
               
                }
                if (acceleration.x >= -0.7f && acceleration.x <= 0f)
                {
                    TestMusic.Instance.playUpdate("HeavySwallow");
                    moveLerp(TargetLeftTop);
                }
            }
    }
}
    public void moveLerp(Transform target)
    {
        transform.position = Vector3.Lerp(transform.position, target.position, 1.6f* Time.deltaTime);
    }
    public virtual void moveToWards(Transform target,float speed)
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
}

