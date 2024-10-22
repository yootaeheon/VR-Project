using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] Transform muzzlePoint;
    [SerializeField] ParticleSystem hitEffect;
    [SerializeField] AudioSource fireSFX;
    [SerializeField] float maxDistance = 500f;
    public GameObject target;

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
        Debug.Log("타겟 확인");
        ParticleSystem effect = Instantiate(hitEffect, RaycastHit.point, Quaternion.LookRotation(RaycastHit.normal));
        effect.transform.parent = RaycastHit.transform;

        if (RaycastHit.collider.CompareTag("Target"))
        {
            Target target = gameObject.GetComponent<Target>();

            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }

        fireSFX.Stop();
        Debug.Log("sound");
        fireSFX.Play(); // action으로 대체

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