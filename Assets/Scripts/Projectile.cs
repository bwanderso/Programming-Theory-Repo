using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    //ENCAPSULATION
    private float m_Speed = 500f;
    public float Speed
    {
        get {
            return m_Speed;
        }
        set {
            if (value>0f) {
                m_Speed = value;
            }
            else {
                Debug.Log( "Cannot set speed to a negative number" );
            }
        }
    }

    public void MoveProjectile() {
        Rigidbody bulletRB = GetComponent<Rigidbody>();
        //bulletRB.AddForce( Vector3.forward * m_Speed );
        bulletRB.AddRelativeForce( Vector3.up * m_Speed );
    }

    public void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Ground")) {
            Destroy( gameObject );
        }
    }
}
