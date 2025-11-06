using UnityEngine;

public class EnemyParent : MonoBehaviour
{
    [SerializeField] protected float moveSpeed = 2f;
    [SerializeField] protected int health = 3;

    private bool movingRight = true;

    void Update()
    {
        Walk();
    }

    protected virtual void Walk()
    {
        float direction = movingRight ? 1 : -1;
        transform.Translate(Vector3.right * direction * moveSpeed * Time.deltaTime);

        // Laat de enemy van richting veranderen bij randdetectie (optioneel)
        if (transform.position.x > 10f) movingRight = false;
        if (transform.position.x < -10f) movingRight = true;
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            health--;
            Destroy(collision.gameObject);
            if (health <= 0)
            {
                Destroy(gameObject);
            }

            Debug.Log("Hoi");
        }
    }
}