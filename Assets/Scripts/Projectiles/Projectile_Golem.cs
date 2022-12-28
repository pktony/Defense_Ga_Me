using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Golem : Projectile_Angled_Mine
{
    private bool isLanded = false;
    [SerializeField]
    private float healAmount = 10f;

    protected override void Update()
    {
        if (!isExploded && !isLanded)
        {
            transform.Rotate(rotationSpeed * Time.deltaTime * transform.right);
            if (transform.position.y < 0f)
            {
                isLanded = true;
                transform.SetPositionAndRotation(
                    new Vector3(transform.position.x, 0f, transform.position.z),
                    Quaternion.identity);
                rigid.isKinematic = true;
                rigid.useGravity = false;
                rigid.constraints = RigidbodyConstraints.FreezeAll;
                coll.enabled = true;
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Golem"))
        {
            SkilledGolem golem = other.GetComponent<SkilledGolem>();
            golem.Heal(healAmount);
            Explode();
        }
    }

}
