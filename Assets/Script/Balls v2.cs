using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject prefab;
    private float elapsedTime = 0f;

    void Update()
    {

        elapsedTime += Time.deltaTime;

        if (elapsedTime > 1f)
        {

            float r = Random.Range(0f, 1f);
            float g = Random.Range(0f, 1f);
            float b = Random.Range(0f, 1f);
            Color randColor = new Color(r, g, b, 1f);

            CreateBall(randColor);
            elapsedTime = 0f;
        }
    }


    private void CreateBall(Color c)
    {
        GameObject ball = Instantiate(prefab, transform.position, Quaternion.identity);


        var renderer = ball.GetComponent<Renderer>();
        if (renderer != null)
        {
            var material = renderer.material;


            if (material.HasProperty("_Color"))
                material.SetColor("_Color", c);


            if (material.HasProperty("_BaseColor"))
                material.SetColor("_BaseColor", c);
        }


        Destroy(ball, 3f);
    }
}