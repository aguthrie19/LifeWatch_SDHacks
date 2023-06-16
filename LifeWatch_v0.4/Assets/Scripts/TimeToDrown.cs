using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeToDrown : MonoBehaviour {

    private float timer;
    private bool timeOnce = false;
    private bool stage1 = false;
    private bool stage2 = false;
    private bool stage3 = false;
    private bool stage4 = false;
    private bool stage5 = false;
    private bool stage6 = false;
    private bool stage7 = false;
    private bool stage8 = false;
    private GameObject drown1;
    private GameObject drown2;
    private GameObject mover;
    private GameObject back;
    public float thrust = -60.0f;
    //private MeshRenderer colorDrown1;
    //private MeshRenderer colorDrown2;
    private AudioSource source;
    public AudioClip splashDrown;
    public AudioClip underwater;

    // Use this for initialization
    void Start () {
        timer = 15.0f;
        drown1 = GameObject.Find("CubeDrown");
        drown2 = GameObject.Find("CubeDrown2");
        mover = GameObject.Find("CubeMove");
        back = GameObject.Find("CubeBack");
        mover.GetComponent<Rigidbody>().AddForce(10, 0, -10);
        back.GetComponent<Rigidbody>().AddForce(-10, 0, -10);
        source = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        
        if (timer >= 0.0f)
        {
            timer -= Time.deltaTime;
            //colorDrown1 = drown1.GetComponent<MeshRenderer>();
            //colorDrown2 = drown2.GetComponent<MeshRenderer>();
            //guiText.guiText = timerl.ToString("F");
        }
        else if (timer <= 0.0f && !timeOnce)
        {
            timeOnce = true;
            timer = 0.0f;
            back.GetComponent<Rigidbody>().AddForce(5, 0, 3);
            back.GetComponent<Rigidbody>().detectCollisions = false;
        }

        // FIRST DROWNER

        if (timer <= 12.0f && !stage1)
        {
            //Debug.Log("Drowning");
            drown1.GetComponent<Rigidbody>().AddForce(0, thrust, 0);
            source.PlayOneShot(underwater);
            stage1 = true;
            //colorDrown1.material.SetColor("_Color", Color.yellow);
            //source.PlayOneShot(splashDrown);
        }
        if (timer <= 11.5f && !stage2)
        {
            drown1.GetComponent<Rigidbody>().AddForce(0, -thrust, 0);
            stage2 = true;
        }
        
        if (timer <= 9.0f && !stage3)
        {
            //colorDrown1.material.SetColor("_Color", Color.red);
            drown1.GetComponent<Rigidbody>().AddForce(0, thrust*2, 0);
            source.PlayOneShot(splashDrown);
            stage3 = true;
        }
        if (timer <= 7.5f && !stage4 && drown1.transform.rotation.x >= 0.00f)
        {
            //colorDrown1.material.SetColor("_Color", Color.red);
            drown1.GetComponent<Rigidbody>().AddForce(0, -thrust*2, 0);
            Destroy(drown1);
            //drown1.transform.position = new Vector3(-4f, -10f, 0f);
            stage4 = true;
        }
        else if (timer <= 6.0f && !stage4)
        {
            drown1.transform.Rotate(0.0f, 140.0f, 0.0f);
            drown1.GetComponent<Rigidbody>().position = new Vector3(-2.3f, 1.92f, 2.0f);
            drown1.GetComponent<Rigidbody>().isKinematic = true;
            drown1.GetComponent<Rigidbody>().detectCollisions = false;
            //drown1.GetComponent<Rigidbody>().rotation = new Vector3(0.0f, 120.0f, 0.0f);
            //drown1.transform.Rotate(0.0f, 120.0f, 0.0f);
            stage4 = true;
        }

        // ************
        // SECOND DROWNER
        // **************
        if (timer <= 8.0f && !stage5)
        {
            //Debug.Log("Drowning");
            drown2.GetComponent<Rigidbody>().AddForce(0, thrust, 0);
            source.PlayOneShot(underwater);
            stage5 = true;
            //colorDrown1.material.SetColor("_Color", Color.yellow);
            //source.PlayOneShot(splashDrown);
        }
        if (timer <= 7.5f && !stage6)
        {
            drown2.GetComponent<Rigidbody>().AddForce(0, -thrust, 0);
            stage6 = true;
        }

        if (timer <= 5.0f && !stage7)
        {
            //colorDrown1.material.SetColor("_Color", Color.red);
            drown2.GetComponent<Rigidbody>().AddForce(0, thrust * 2, 0);
            source.PlayOneShot(splashDrown);
            stage7 = true;
        }
        if (timer <= 3.5f && !stage8 && drown2.transform.rotation.x >= 0.00f)
        {
            //colorDrown1.material.SetColor("_Color", Color.red);
            drown2.GetComponent<Rigidbody>().AddForce(0, -thrust * 2, 0);
            Destroy(drown2);
            //drown1.transform.position = new Vector3(-4f, -10f, 0f);
            stage8 = true;
        }
        else if (timer <= 3.0f && !stage8)
        {
            drown2.transform.Rotate(0.0f, 180.0f, -10.0f);
            drown2.GetComponent<Rigidbody>().position = new Vector3(-1.9f, 1.60f, -1.6f);
            drown2.GetComponent<Rigidbody>().isKinematic = true;
            drown2.GetComponent<Rigidbody>().detectCollisions = false;
            //drown2.transform.Rotate(0.0f, 120.0f, 0.0f);
            stage8 = true;
        }


        /*
        if (timer <= 1.5f && !stage3)
        {
            colorDrown2.material.SetColor("_Color", Color.yellow);
            //source.PlayOneShot(splashDrown);
            stage3 = true;
        }
        if (timer <= 0.8f && !stage4)
        {
            colorDrown2.material.SetColor("_Color", Color.red);
            //source.PlayOneShot(splashDrown);
            stage4 = true;
        }
        */
    }
}
