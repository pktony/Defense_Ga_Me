using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
    protected SphereCollider coll;
    protected Rigidbody rigid;
    protected ParticleSystem explosionParticle;
    protected GameObject model;

    [SerializeField] protected ProjectileData projectileData;
    protected Vector3 destination;
    protected Vector3 direction;
    private float attackPower;

    protected const float explosionDistance = 0.2f;

    protected bool isExploded = false;

    public float Vel => projectileData.flySpeed;

    protected virtual void Awake()
    {
        explosionParticle = transform.GetChild(1).GetComponentInChildren<ParticleSystem>();
        explosionParticle.gameObject.SetActive(false);

        coll = GetComponent<SphereCollider>();
        coll.enabled = false;
        rigid = GetComponent<Rigidbody>();
        model = transform.GetChild(0).gameObject;

        Destroy(this.gameObject, 3f);
    }

    public void InitializeProjectile(Vector3 destination, float attackPower, bool isAngled = false)
    {
        this.attackPower = attackPower;
        this.destination = destination;
        direction = destination - transform.position;
        direction = direction.normalized;

        if (!isAngled)
        {
            transform.LookAt(destination);
        }
    }

    protected virtual void Update()
    {
        if (!isExploded)
        {
            Fly();

            if ((transform.position - destination).sqrMagnitude <
                explosionDistance * explosionDistance)
            {
                Explode();
            }
        }
    }

    private void Fly()
    {
        transform.position += projectileData.flySpeed * Time.deltaTime * direction;
    }

    protected void Explode()
    {
        isExploded = true;
        model.SetActive(false);
        rigid.velocity = Vector3.zero;
        rigid.isKinematic = true;
        coll.enabled = true;
        StartCoroutine(DisableCollider());
        explosionParticle.gameObject.SetActive(true);
        float duration = explosionParticle.main.duration;
        Destroy(this.gameObject, duration);
    }

    private IEnumerator DisableCollider()
    {
        yield return new WaitForSeconds(0.3f);
        coll.enabled = false;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            enemy.GetAttack(attackPower);
        }
    }
}
