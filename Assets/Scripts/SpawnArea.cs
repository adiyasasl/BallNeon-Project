using System.Collections.Generic;
using UnityEngine;

public class SpawnArea : MonoBehaviour
{
    [Header("Spawn Components")]
    [SerializeField]
    private Collider2D colliderBound;

    [Header("Spawn Properties")]
    [SerializeField]
    private Transform enemyParent;
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private int amountEnemy = 10;
    [SerializeField]
    private float minDistance = 5f;

    void Start()
    {
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        List<Vector2> posList = new List<Vector2>();
        int maxAttempts = 50;

        for (int i = 0; i < amountEnemy; i++)
        {
            Vector2 position;
            bool validPosition;

            int attempts = 0;

            do
            {
                validPosition = true;
                position = GetRandomPosition();

                foreach (Vector2 existingPos in posList)
                {
                    if (Vector2.Distance(position, existingPos) < minDistance)
                    {
                        validPosition = false;
                        break;
                    }
                }

                attempts++;

            } while (!validPosition && attempts < maxAttempts);

            if (!validPosition)
            {
                Debug.LogWarning("Failed to find valid spawn position");
                continue;
            }

            posList.Add(position);

            GameObject enemy = Instantiate(enemyPrefab, position, Quaternion.identity);
            enemy.transform.SetParent(enemyParent);
        }

    }

    public Vector2 GetRandomPosition()
    {
        var bound = colliderBound.bounds;

        var randomX = Random.Range(bound.min.x, bound.max.x);
        var randomY = Random.Range(bound.min.y, bound.max.y);

        var pos = new Vector2(randomX, randomY);

        return pos;
    }
}
