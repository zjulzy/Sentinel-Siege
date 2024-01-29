using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DemoEnemy : MonoBehaviour
{
    // 向编辑器公开的路径checkpoint列表
    public Checkpoint[] checkpoints;
    private int _checkpointIndex = 0;
    private Checkpoint _target;
    
    public float speed = 10;

    // Start is called before the first frame update
    void Start()
    {
        _target = checkpoints[0];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = _target.transform.position - transform.position;
        Vector3 delta = dir.normalized * (Time.deltaTime * speed);
        delta.y = 0;
        transform.Translate(delta, Space.World);
        if (Vector3.Distance(transform.position, _target.transform.position) <
            transform.position.y - _target.transform.position.y + 0.1)
        {
            GetNextCheckpoint();
        }
    }

    void GetNextCheckpoint()
    {
        if (_checkpointIndex + 1 < checkpoints.Length)
        {
            _target = checkpoints[++_checkpointIndex];
        }
        else
        {
            Destroy(gameObject);
        }
    }
}