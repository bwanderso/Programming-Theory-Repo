using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveProjectile() {
        Rigidbody bulletRB = GetComponent<Rigidbody>();
        bulletRB.AddForce( Vector3.forward * m_Speed );
    }
}
