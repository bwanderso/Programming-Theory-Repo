using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//INHERITANCE
public class Shotgun : Weapon
{
    private float m_angleSpread = 20f;

    // Start is called before the first frame update
    void Start()
    {
        m_fireDelay = 1f;
    }

    //POLYMORPHISM
    protected override void CreateVolley(Vector3 gunPosition) {
        CreateSpread(gunPosition);
    }

    private void CreateSpread(Vector3 gunPosition) {
        Quaternion leftSpread = m_projectile.transform.rotation * Quaternion.Euler( new Vector3(0, 0, m_angleSpread ));
        Quaternion rightSpread = m_projectile.transform.rotation * Quaternion.Euler( new Vector3( 0, 0, -m_angleSpread ) );

        CreateParticle( gunPosition, leftSpread );
        CreateParticle( gunPosition, m_projectile.transform.rotation );
        CreateParticle( gunPosition, rightSpread );
    }

    private void CreateParticle(Vector3 gunPosition, Quaternion angle) {
        GameObject clone = Instantiate( m_projectile, gunPosition, angle );

        Projectile projectile = clone.GetComponent<Projectile>();
        projectile.MoveProjectile();
    }
}
