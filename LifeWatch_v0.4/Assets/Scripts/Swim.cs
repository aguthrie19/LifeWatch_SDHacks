using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Swim : MonoBehaviour {

    private Vector3 curPos = new Vector3(0.0f, 0.0f, 0.0f);
    //private int direction = 1;
    //private float bobSpeed = 0.4f;
    private float thrust = 0.15f;

    private AudioSource source;
    public AudioClip splish;
    public AudioClip kick;

    private float timer;
    // Use this for initialization
    void Start () {
        //nothing special
        timer = 1.0f;
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update () {
        bobbing();
        //Debug.Log(curPos);
	}
    void bobbing()
    {
        //System.Random rnd = new System.Random();
        //int bob = rnd.Next(1, 10);
        //bob = bob / 10;

        curPos = transform.position;
        //transform.Translate(0, bobSpeed * direction * (Time.deltaTime), 0);

        this.GetComponent<Rigidbody>().AddForce(transform.up * thrust);
        if (curPos[1] > -1.2)
        {
            thrust = -0.8f;
        }
        else if (curPos[1] < -1)
        {
            thrust = 0.15f;
        }
        if (timer >= 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            timer = 3.0f;
            source.PlayOneShot(kick);
            source.PlayOneShot(splish);
        }

    }
}