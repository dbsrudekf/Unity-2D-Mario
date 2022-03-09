using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    GameObject Player;
    static public Camera instance;
    private void Awake()
    {
        if(instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        Player = GameObject.Find("Mario");
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 PlayerPos = Player.transform.position;

        transform.position = new Vector3(PlayerPos.x, transform.position.y, transform.position.z);
    }
}
