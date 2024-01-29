using UnityEngine;

public class Turrent : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject fireEffectPrefab;
    public Transform rotateBase;
    public Transform firePoint;
    public float attackRange = 10f;

    public float reloadTime = 1f;

    // 炮塔旋转速度，不同的炮塔类型可能不同，有的炮塔可能没有旋转速度
    public float rotateSpeed = 10f;

    public GameObject target;
    private float _fireCD = 0;
    private string _enemyTag = "Enemy";

    // Start is called before the first frame update
    void Start()
    {
        _fireCD = reloadTime;
        InvokeRepeating("UpdateTarget", 0f, 0.2f);
    }

    // 周期性调用用以更新目标，不同类型的炮塔具有不同的索敌逻辑
    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(_enemyTag);
        float minDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy && minDistance <= attackRange)
        {
            target = nearestEnemy;
        }
        else
        {
            target = null;
        }
    }

    // Update is called once per frame
    // 寻找当前是否已经锁定目标，如果有目标则向其方向旋转，并尝试开炮
    void Update()
    {
        _fireCD = 0 > _fireCD - Time.deltaTime ? 0 : _fireCD - Time.deltaTime;
        if (!target) return;
        Vector3 dir = target.transform.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(rotateBase.rotation, lookRotation, Time.deltaTime * rotateSpeed).eulerAngles;
        rotation.x = 0;
        rotation.z = 0;
        rotateBase.rotation = Quaternion.Euler(rotation);
        AttempFire();
    }

    void AttempFire()
    {
        if (_fireCD > 0) return ;
        // 判断炮塔是否旋转到位，如果已经旋转到位则直接开火
        Vector3 dir = (target.transform.position - transform.position).normalized;
        Vector3 rotateDir = rotateBase.forward;
        if(Vector3.Dot(dir, rotateDir) > 0.9)
        {
            var fireTransform = firePoint.transform;
            GameObject bullet = (GameObject)Instantiate(bulletPrefab, fireTransform.position, fireTransform.rotation);
            bullet.GetComponent<Bullet>().Seek(target);
            _fireCD = reloadTime;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, attackRange);
    }
}