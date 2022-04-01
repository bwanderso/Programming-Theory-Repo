using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    //ABSTRACTION
    protected float m_currentTime = 0f;
    protected bool m_hasFired = false;


    [SerializeField] protected GameObject m_projectile;

    //ENCAPSULATION
    protected float m_fireDelay = 1f;
    public float FireDelay
    {
        get { return m_fireDelay; }
        set {
            if (value > 0) {
                m_fireDelay = value;
            }
        }
    }


    public void Shoot(Vector3 gunPosition) {
        if (CanFire() ) {
            CreateVolley( gunPosition );
        }

    }

    protected bool CanFire() {
        if (!m_hasFired) {
            m_currentTime = 0;
            m_hasFired = true;
            return true;
        }

        if (m_hasFired && m_currentTime < m_fireDelay) {
            m_currentTime += Time.deltaTime;
        } else {
            m_hasFired = false;
        }

        return false;
    }

    protected virtual void CreateVolley(Vector3 userPosition) {
        GameObject clone = Instantiate( m_projectile, userPosition, m_projectile.transform.rotation );


        Projectile projectile = clone.GetComponent<Projectile>();
        projectile.MoveProjectile();

    }
}


//----------DEPRECATED BUT KEPT

//protected IEnumerator WaitForRefire(Vector3 userPosition) {
//    while ( true ) { 
//        Debug.Log( "Weapon Waiting for Refire: " + m_fireDelay );
//        CreateVolley( userPosition );
//        yield return new WaitForSeconds( m_fireDelay );
//    }
//}