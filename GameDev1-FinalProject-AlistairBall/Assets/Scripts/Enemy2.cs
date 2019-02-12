using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{


    public Transform PlayerPos;
    public Transform Home;
    

    private bool Getem = false;




    private
    
    bool stop = false;
   
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Getem == true && stop == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, PlayerPos.transform.position, 0.5f);
        }
        else if (Getem == false && stop == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, Home.transform.position, 0.7f);
        }

        Debug.Log(Getem);
     
    }

    void OnDestroy()
    {
       
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Getem = true;
        }

        if(other.gameObject.tag == "Hide")
        {
            Getem = false;
        }

        //if (other.gameObject.tag == "Stop")
        //{
        //    stop = true;
        //}
        //else
        //{
        //    stop = false;
        //}
        
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Getem = false;
        }

        
    }
}
