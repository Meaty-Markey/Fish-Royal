using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aimovement : MonoBehaviour
{
    public static float movespeed = 1f;
    private float up, down, left, right;

    public Rigidbody2D rb;

    public void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        currentTime = countdownTimer;
        #region dont look at this bitch
        left = GameObject.Find("WallLeft").transform.position.x;
        right = GameObject.Find("WallRight").transform.position.x;
        up = GameObject.Find("WallUp").transform.position.y;
        down = GameObject.Find("Floor").transform.position.y;
        #endregion

       // for(int i = 0; i <= 10; i++)
       //  Instantiate(gameObject);
    }

    float countdownTimer = 3f;
    float currentTime;
    public void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= countdownTimer)
        {
            StartCoroutine(Move(new Vector3(UnityEngine.Random.Range(left, right), UnityEngine.Random.Range(down, up), 0)));
            currentTime = 0;           
        }
    }

    public IEnumerator Move(Vector3 newpos)
    {        
        var timeSinceStart = 0f;
        while(true)
        {
            timeSinceStart += Time.deltaTime;
            transform.transform.position = Vector3.Lerp(transform.position, newpos, (timeSinceStart / 2) * movespeed);
            if (transform.position == newpos)
                yield break;
            yield return null;
        }     

    }
 
}
