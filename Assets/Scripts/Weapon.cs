using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    protected float m_projectileSpeed;
    [SerializeField] protected Projectile m_projectile;
    private int m_maxAmmo = 6;
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
    private float m_fireDelay = 1f;
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
        StartCoroutine( "CreateVolley", userPosition );
    }


    protected virtual IEnumerable CreateVolley(Vector3 userPosition) {
        m_projectile.Speed = m_projectileSpeed;

        Instantiate( m_projectile, userPosition, m_projectile.transform.rotation );
        m_projectile.MoveProjectile();

        yield return new WaitForSeconds( m_fireDelay );

    }
}
