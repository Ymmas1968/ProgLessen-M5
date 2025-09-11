using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    // Functie om een bal te maken met kleur en positie
    private GameObject CreateBall(Color c, Vector3 pos)
    {
        GameObject ball = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        ball.transform.position = pos;

        // Geef de bal een kleur
        Material mat = ball.GetComponent<Renderer>().material;
        mat.color = c;

        return ball;
    }

    // Functie om een random kleur te genereren
    private Color GetRandomColor()
    {
        float r = Random.Range(0f, 1f);
        float g = Random.Range(0f, 1f);
        float b = Random.Range(0f, 1f);
        return new Color(r, g, b);
    }

    void Start()
    {
        // Maak 100 ballen met random kleur en positie
        for (int i = 0; i < 100; i++)
        {
            Vector3 pos = new Vector3(
                Random.Range(-10f, 10f),  // X
                Random.Range(1f, 10f),    // Y (hoogte)
                Random.Range(-10f, 10f)   // Z
            );

            GameObject ball = CreateBall(GetRandomColor(), pos);
           
            // Add physics so it falls with gravity
            Rigidbody rb = ball.AddComponent<Rigidbody>();
            rb.useGravity = true;
            rb.mass = 1f; // optional, controls weight

            // Verwijder de bal na 3 seconden
            Destroy(ball, 10f);
        }
    }
}
