using UnityEngine;

public class AnimationBackground : MonoBehaviour
{
    public float speed = 20f;
    public float directionChangeInterval = 100f;

    private float timer;
    private int currentDirection = 1;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= directionChangeInterval)
        {
            currentDirection = Random.Range(-1, 2);
            timer = 0f;
        }

        transform.Translate(Vector3.right * speed * currentDirection * Time.deltaTime);
    }
}