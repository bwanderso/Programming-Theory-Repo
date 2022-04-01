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

// REFACTOR TO USE COROUTINES!

    public virtual void Shoot(Vector3 userPosition) {
        Debug.Log( "Weapon Shoot: " + this.name );
        //CreateVolley(userPosition);

        if (!m_hasFired) {
            CreateVolley( userPosition );
            m_hasFired = true;
            m_currentTime = 0;
            Debug.Log( "Weapon - Fire!" );
        }

        if (m_hasFired) {
            if (m_currentTime < m_fireDelay) {
                m_currentTime += Time.deltaTime;
                Debug.Log( "Weapon - waiting for refire" );

            }
            else {
                m_hasFired = false;
                Debug.Log( "Weapon - refire time reset" );
            }
        }
    }

    protected IEnumerable WaitForRefire(Vector3 userPosition) {
        Debug.Log( "Weapon Waiting for Refire: " + m_fireDelay );
        CreateVolley( userPosition );
        yield return new WaitForSeconds( m_fireDelay );
    }


// END REFACTOR

    protected virtual void CreateVolley(Vector3 userPosition) {
        GameObject clone = Instantiate( m_projectile, userPosition, m_projectile.transform.rotation );


        Projectile projectile = clone.GetComponent<Projectile>();
        projectile.MoveProjectile();

    }
}
