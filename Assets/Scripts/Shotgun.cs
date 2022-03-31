using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{
    private float m_angleSpread = 20f;

    // Start is called before the first frame update
    void Start()
    {
        base.FireDelay = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override IEnumerable CreateVolley(Vector3 userPosition) {
        CreateSpread(userPosition);

        yield return new WaitForSeconds( base.FireDelay );
    }

    private void CreateSpread(Vector3 userPosition) {
        
        Quaternion leftSpread = m_projectile.transform.rotation * Quaternion.Euler( Vector3.up * -m_angleSpread );
        Quaternion rightSpread = m_projectile.transform.rotation * Quaternion.Euler( Vector3.up * m_angleSpread );

        CreateParticle( userPosition, leftSpread );
        CreateParticle( userPosition, m_projectile.transform.rotation );
        CreateParticle( userPosition, rightSpread );
    }

    private void CreateParticle(Vector3 userPosition, Quaternion angle) {
        Projectile clone = Instantiate( m_projectile, userPosition, angle );
        clone.MoveProjectile();
    }
}
