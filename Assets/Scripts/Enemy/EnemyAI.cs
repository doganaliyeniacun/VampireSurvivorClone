using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed = 4;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindWithTag("Player") != null)
        {
            Vector3 playerPosition =
                GameObject.FindWithTag("Player").transform.position;
            Vector2 direction = playerPosition - transform.position;

            FollowPlayer (direction, playerPosition);
            MoveDirection (direction);
        }
    }

    //Following player positions
    private void FollowPlayer(Vector2 direction, Vector3 playerPosition)
    {
        transform.position =
            Vector2
                .MoveTowards(this.transform.position,
                playerPosition,
                speed * Time.deltaTime);
    }

    private void MoveDirection(Vector2 direction)
    {
        if (direction.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (direction.x > 0)
        {
            spriteRenderer.flipX = false;
        }
    }
}
