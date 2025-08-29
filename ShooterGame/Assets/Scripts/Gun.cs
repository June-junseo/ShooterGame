using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform firePosition;

    public ParticleSystem gunEffect;
    public ParticleSystem hitEffect;

    private LineRenderer lineRenderer;

    private float fireDistance = 50f;

    private int damage = 10;
    private float shotInterval= 0.15f;
    private float lastShotTime;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();

        lineRenderer.positionCount = 2;
        lineRenderer.enabled = false;
    }

    private void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= lastShotTime + shotInterval)
        {
            Shot();
            lastShotTime = Time.time;
        }
    }
    private void Shot()
    {
        RaycastHit hit;

        Vector3 hitPosition = Vector3.zero;

        if (Physics.Raycast(firePosition.position, firePosition.forward, out hit, fireDistance))
        {
            hitPosition = hit.point;

            var target = hit.collider.GetComponent<IDamageable>();
            if (target != null)
            {
                target.OnDamage(damage, hit.point, hit.normal);
            }

            if (gunEffect != null)
            {
                Instantiate(gunEffect, hit.point, Quaternion.LookRotation(hit.normal));
            }

            if(hitEffect != null)
            {
                Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
            }
        }
        StartCoroutine(ShotEffect(hitPosition));
    }

    private IEnumerator ShotEffect(Vector3 hitPosition)
    {
        gunEffect.Play();

        lineRenderer.enabled = true;
        lineRenderer.SetPosition(0, firePosition.position);

        lineRenderer.SetPosition(1, hitPosition);

        yield return new WaitForSeconds(0.2f);

        lineRenderer.enabled = false;


    }


}
