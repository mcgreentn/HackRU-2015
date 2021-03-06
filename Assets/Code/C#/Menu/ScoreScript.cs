﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {

    public GameObject title;
    public GameObject base1;
    public GameObject time;
    public GameObject collect;
    public GameObject coins;
    public GameObject total;
    public GameObject next;

    Rigidbody2D titleRB;
    Rigidbody2D base1RB;
    Rigidbody2D timeRB;
    Rigidbody2D collectRB;
    Rigidbody2D coinsRB;
    Rigidbody2D totalRB;
    Rigidbody2D nextRB;

    public Text titleText;
    public Text baseText;
    public Text timeText;
    public Text collectText;
    public Text coinsText;
    public Text totalText;
    public Text nextText;

  //  public AudioSource boom;
    
    public static float timeScore;
    public static float collectScore;
    public static float coinScore;
    public static float baseScore;

    public float speed = 200;

    float titleStop = Mathf.Round((float)(Screen.height - 40 * (Screen.height / 220.0)));
    float baseStop = Mathf.Round((float)(Screen.width - 175 * (Screen.width / 220.0)));
    float timeStop = Mathf.Round((float)((Screen.width - 150 * (Screen.width / 220.0))));
    float collectStop = Mathf.Round((float)(Screen.width - 150 * (Screen.width / 220.0)));
    float coinStop = Mathf.Round((float)(Screen.width - 150 * (Screen.width / 220.0)));
    float nextStop = Mathf.Round((float)(Screen.width - 35 * (Screen.width / 220.0)));
    float totalStop = Mathf.Round((float)(Screen.width - 175 * (Screen.width / 220.0)));

    // AudioSource sourcer;
    // Use this for initialization
    void Start () {
        title.transform.position = new Vector3(title.transform.position.x, title.transform.position.y - Screen.height, 0);
        base1.transform.position = new Vector3(base1.transform.position.x - Screen.width, base1.transform.position.y, 0);
        time.transform.position = new Vector3(time.transform.position.x - Screen.width - 50, time.transform.position.y, 0);
        collect.transform.position = new Vector3(collect.transform.position.x - Screen.width - 100, collect.transform.position.y, 0);
        coins.transform.position = new Vector3(coins.transform.position.x - Screen.width - 150, coins.transform.position.y, 0);
        total.transform.position = new Vector3(total.transform.position.x - Screen.width - 250, total.transform.position.y, 0);
        next.transform.position = new Vector3(next.transform.position.x + Screen.width, next.transform.position.y, 0);

        titleRB = title.GetComponent<Rigidbody2D>();
        base1RB = base1.GetComponent<Rigidbody2D>();
        timeRB = time.GetComponent<Rigidbody2D>();
        collectRB = collect.GetComponent<Rigidbody2D>();
        coinsRB = coins.GetComponent<Rigidbody2D>();
        totalRB = total.GetComponent<Rigidbody2D>();
        nextRB = next.GetComponent<Rigidbody2D>();

        float totals = 0;

        baseText.text = "" + baseScore;

        timeText.text = "" + timeScore;

        collectText.text = "" + collectScore;
        
        coinsText.text = "" + coinScore;

        totals = baseScore + timeScore + collectScore + coinScore;
        totalText.text = "" + totals;

       // sourcer = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update () {

        checkTitle();
        checkBase();
        checkTime();
        checkCollect();
        checkCoins();
        checkTotal();
        checkNext();
	
	}

    void checkTitle()
    {
        if (title.transform.position.y < titleStop)
        {
            Vector2 moveVel = titleRB.velocity;
            moveVel.y = 20 * speed;
            titleRB.velocity = moveVel;
        }
        else
        {
            titleRB.velocity = new Vector2(0,0);
          //  sourcer.Play();
        }
    }
    void checkBase()
    {
        if (base1.transform.position.x < baseStop)
        {
            Vector2 moveVel = base1RB.velocity;
            moveVel.x = 20 * speed;
            base1RB.velocity = moveVel;
        }
        else
        {
            base1RB.velocity = new Vector2(0, 0);
           // sourcer.Play();
        }
    }

    void checkTime()
    {
        if (time.transform.position.x < timeStop)
        {
            Vector2 moveVel = timeRB.velocity;
            moveVel.x = 20 * speed;
            timeRB.velocity = moveVel;
        }
        else
        {
            timeRB.velocity = new Vector2(0, 0);
          //  sourcer.Play();
        }
    }

    void checkCollect()
    {
        if (collect.transform.position.x < collectStop)
        {
            Vector2 moveVel = collectRB.velocity;
            moveVel.x = 20 * speed;
            collectRB.velocity = moveVel;
        }
        else
        {
            collectRB.velocity = new Vector2(0, 0);
           // sourcer.Play();
        }
    }

    void checkCoins()
    {
        if (coins.transform.position.x < coinStop)
        {
            Vector2 moveVel = coinsRB.velocity;
            moveVel.x = 20 * speed;
            coinsRB.velocity = moveVel;
        }
        else
        {
            coinsRB.velocity = new Vector2(0, 0);
         //   sourcer.Play();
        }
    }

    void checkTotal()
    {
        if (total.transform.position.x < totalStop)
        {
            Vector2 moveVel = totalRB.velocity;
            moveVel.x = 20 * speed;
            totalRB.velocity = moveVel;
        }
        else
        {
            totalRB.velocity = new Vector2(0, 0);
     //       sourcer.Play();
        }
    }

    void checkNext()
    {
        if (next.transform.position.x > nextStop)
        {
            Vector2 moveVel = nextRB.velocity;
            moveVel.x = -1 * 20 * speed;
            nextRB.velocity = moveVel;
        }
        else
        {
            nextRB.velocity = new Vector2(0, 0);
        //    sourcer.Play();
        }
    }
}
