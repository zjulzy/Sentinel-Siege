using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffectPrefab;
    private GameObject _target;

    public float speed = 100f;

    public void Seek(GameObject target)
    {
        _target = target;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_target)
        {
            Destroy(gameObject);
            return;
        }
        
        Vector3 dir = _target.transform.position - transform.position;
        float distance = speed * Time.deltaTime;
        if (dir.magnitude <= distance)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distance, Space.World);
    }

    void HitTarget()
    {
        Destroy(_target);
        var t = transform;
        GameObject effect = (GameObject)Instantiate(hitEffectPrefab, t.position, t.rotation);
        Destroy(effect, 1f);
        Destroy(gameObject);
    }
}
