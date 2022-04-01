using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody m_rigidbody;

    private Weapon m_weapon;
    [SerializeField] private float playerSpeed;
    private float m_gunOffshotPosition = 3f;

    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleMove();
        HandleShoot();
    }

    private void HandleShoot() {
        if (Input.GetKey(KeyCode.Space)) {
            if (m_weapon != null) {

                //Fire weapon slightly ahead of current player's position
                m_weapon.Shoot( GetGunOffsetPosition() );
            }
        }
    }

    private Vector3 GetGunOffsetPosition() {
        return ( Vector3.forward * m_gunOffshotPosition ) + transform.position;
    }

    private void HandleMove() {
        float horizontalMoveDirection = Input.GetAxis( "Horizontal" );
        float verticalMoveDirection = Input.GetAxis( "Vertical" );

        Vector3 moveDirection = new Vector3( horizontalMoveDirection, 0, verticalMoveDirection  ).normalized;


        transform.Translate( moveDirection * playerSpeed * Time.deltaTime );
    }

    private void OnTriggerEnter(Collider other) {

        // If we ran over a weapon, equip it and destroy the GO
        if ( other.CompareTag( "Weapon" ) ) {
            m_weapon = other.GetComponent<Weapon>();
            
        } else {
            Debug.Log( "Player triggered" );
        }
    }
}
