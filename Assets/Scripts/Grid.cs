using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Grid : MonoBehaviour
{
    private Color _startColor;
    public Color hoverColor;

    private Renderer _renderer;
    private float _offset = 0.5f;

    private GameObject _turrent;

    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponent<Renderer>();
        _startColor = _renderer.material.color;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (!_turrent)
        {
            GameObject turrentPrefab = BuildManager.instance.GetTurrent();
            if (!turrentPrefab) return;
            _turrent = Instantiate(turrentPrefab, transform.position + Vector3.up * _offset, Quaternion.identity);
        }
        else
        {
            Debug.Log("can't build on a existing turrent currently");
        }
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        _renderer.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        // if (EventSystem.current.IsPointerOverGameObject())
        //     return;
        _renderer.material.color = _startColor;
    }

    // Update is called once per frame
    void Update()
    {
    }
}