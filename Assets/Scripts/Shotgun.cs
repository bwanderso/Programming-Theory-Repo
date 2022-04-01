using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{
    private float m_angleSpread = 20f;

    // Start is called before the first frame update
    void Start()
    {
        m_fireDelay = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void CreateVolley(Vector3 userPosition) {
        CreateSpread(userPosition);
    }

    private void CreateSpread(Vector3 userPosition) {
        
        Quaternion leftSpread = m_projectile.transform.rotation * Quaternion.Euler( Vector3.up * -m_angleSpread );
        Quaternion rightSpread = m_projectile.transform.rotation * Quaternion.Euler( Vector3.up * m_angleSpread );

        CreateParticle( userPosition, leftSpread );
        CreateParticle( userPosition, m_projectile.transform.rotation );
        CreateParticle( userPosition, rightSpread );
    }

    private void CreateParticle(Vector3 userPosition, Quaternion angle) {
        GameObject clone = Instantiate( m_projectile, userPosition, angle );

        Projectile projectile = clone.GetComponent<Projectile>();
        projectile.MoveProjectile();
    }
}
