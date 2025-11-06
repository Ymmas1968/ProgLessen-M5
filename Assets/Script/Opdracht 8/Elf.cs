using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class Elf : EnemyParent
{
    private Renderer rend;

    private void Start()
    {
        moveSpeed = 5f;  // Snel
        health = 2;      // Weinig levens
        rend = GetComponentInChildren<Renderer>();
        StartCoroutine(ToggleVisibility());
    }

    private IEnumerator ToggleVisibility()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);
            rend.enabled = false;
            yield return new WaitForSeconds(0.5f);
            rend.enabled = true;
        }
    }
}