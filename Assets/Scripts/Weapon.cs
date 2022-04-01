using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    protected float m_currentTime = 0f;
    protected bool m_hasFired = false;
    [SerializeField] protected GameObject m_projectile;
    protected int m_maxAmmo = 6;
    public int MaxAmmo
    {
        get {
            return m_maxAmmo;
        }
        set {
            if (value > 0) {
                m_maxAmmo = value;
            }
            else {
                Debug.Log( "Cannot set ammo amount below zero." );
            }
        }
    }
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


    //// Start is called before the first frame update
    //void Start() {

    //}

    //// Update is called once per frame
    //void Update() {

    //}

    public void Shoot(Vector3 userPosition) {
        if (CanFire() ) {
            CreateVolley( userPosition );
        }

    }

    protected bool CanFire() {
        Debug.Log( "CanFire:  CurrentTime: " + m_currentTime + " m_fireDelay: " + m_fireDelay );
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