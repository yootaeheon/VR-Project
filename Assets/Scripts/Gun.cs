using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;

public class Gun : MonoBehaviour
{
    [SerializeField] Transform muzzlePoint;
    [SerializeField] ParticleSystem hitEffect;
    [SerializeField] AudioSource fireSFX;
    [SerializeField] float maxDistance = 500f;

    [SerializeField] public int damage = 1;

    public RaycastHit RaycastHit;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            ShotRay();
            ShotBullet(damage);
        }
    }

    public void ShotRay()
    {
        Ray gunRay = new Ray(muzzlePoint.position, muzzlePoint.forward);
        if (Physics.Raycast(gunRay, out RaycastHit hit, maxDistance))
        {
            Debug.DrawRay(muzzlePoint.position, muzzlePoint.forward * hit.distance, Color.red, 2f);
            RaycastHit = hit;
        }
    }

    public void ShotBullet(int damage)
    {
        ParticleSystem effect = Instantiate(hitEffect, RaycastHit.point, Quaternion.LookRotation(RaycastHit.normal));
        effect.transform.parent = RaycastHit.transform;

        fireSFX.Play();
    }

    private void OnParticleCollision(GameObject other)
    {
        Target target = other.gameObject.GetComponent<Target>();

        if (target != null)
        {
            target.TakeDamage(damage);
        }
    }

}