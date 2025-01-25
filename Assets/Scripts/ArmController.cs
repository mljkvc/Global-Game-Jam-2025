﻿using System.Collections;
using UnityEngine;

public class ArmController : MonoBehaviour
{
    public float speed = 1f;
    private Vector3 targetPosition;
    bool flag = false;
    bool flagCobra = false;
    public static ArmController instance {

        get; private set;
    }


    void Awake()
    {
        if (instance == null) { 
            instance = this;
        }
    }

    IEnumerator delay()
    {
        yield return new WaitForSeconds(0.2f);
        flag = false;
        flagCobra = false;
    }

    void Start()
    {
        targetPosition = new Vector3(transform.position.x, -1f, transform.position.z);
    }

    void Update()
    {
        if (flag)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, 12 * -speed * Time.deltaTime);
            return;
        }
        if (flagCobra)
           {
               transform.position = Vector3.MoveTowards(transform.position, targetPosition,40 *  -speed * Time.deltaTime);

           }
        else { transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime); }

    }
    public void MoveHandDown()
    {
        flag = true;
        StartCoroutine(delay());
        Debug.Log("mikac");
        // Pomeraj ruku prema dole sa određenom brzinom
        Debug.Log("HandDown metoda se poziva. Trenutna pozicija: " + transform.position);

       // transform.position -= new Vector3(0, 3f,0);
        Debug.Log(" NAKON HandDown metoda se poziva. Trenutna pozicija: " + transform.position);

    }
    public void MoveHandDownCobra()
    {
        flagCobra = true;
        StartCoroutine(delay());
        Debug.Log("mikac");
        // Pomeraj ruku prema dole sa određenom brzinom
        Debug.Log("HandDown metoda se poziva. Trenutna pozicija: " + transform.position);

        // transform.position -= new Vector3(0, 3f,0);
        Debug.Log(" NAKON HandDown metoda se poziva. Trenutna pozicija: " + transform.position);

    }
}
