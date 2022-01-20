using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float fSpeed = 10.0f;

    Rigidbody rRigidbody;
    Vector3 vMovement;
    float fHorizontal;

    // Start is called before the first frame update
    void Start()
    {
        rRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        fHorizontal = Input.GetAxisRaw("Horizontal");
    }

    void FixedUpdate()
    {
        vMovement.Set(fHorizontal, 0.0f, 0.0f);
        vMovement = vMovement.normalized * fSpeed * Time.deltaTime;
        rRigidbody.MovePosition(transform.position + vMovement);
    }
}
