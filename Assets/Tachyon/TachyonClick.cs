﻿using UnityEngine;

public class TachyonClick : MonoBehaviour
{
    public SimpleCounter tachyons;
    public GameObject glowspereBurst;
    [SerializeField] private float tachyonsPerClick = 1f;
    [SerializeField] private float scaleTime = 0.2f;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

            if (hit.collider == null) return;

            Add(tachyonsPerClick);
            Destroy(Instantiate(glowspereBurst, transform.position, Quaternion.identity), 2);
        }
    }

    public void Add(float value) => tachyons.count += value;
}
