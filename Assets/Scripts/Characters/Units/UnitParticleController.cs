using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitParticleController : MonoBehaviour
{
    private ParticleSystem attackParticle;

    private void Awake()
    {
        attackParticle = transform.GetChild(0).GetComponent<ParticleSystem>();
        attackParticle.gameObject.SetActive(false);
    }

    public void UseParticle(Vector3 position)
    {
        attackParticle.transform.parent = null;
        attackParticle.transform.position = position;
        attackParticle.gameObject.SetActive(true);
    }

    public void ReturnParitcle()
    {
        attackParticle.transform.parent = this.transform;
        attackParticle.gameObject.SetActive(false);
    }

}
