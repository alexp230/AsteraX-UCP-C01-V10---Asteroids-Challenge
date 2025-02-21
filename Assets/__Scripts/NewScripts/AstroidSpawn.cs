using UnityEngine;

public class AstroidSpawn : MonoBehaviour
{
    private const float ASTROID_SPAWN_TIMER = 3f;

    [SerializeField] private Asteroid_SO Asteroid_SO_;
    private Vector3 ScreenBounds;
    private float AstroidSpawnTimer = 0f;

    void Start()
    {
        ScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, this.transform.position.z));
    }

    void FixedUpdate()
    {
        AstroidSpawnTimer += Time.deltaTime;
        if (AstroidSpawnTimer >= ASTROID_SPAWN_TIMER)
        {
            AstroidSpawnTimer = 0f;
            Instantiate(Asteroid_SO_.GetAstroid(), GetRandomPosition(), Quaternion.identity);
        }
    }

    private Vector3 GetRandomPosition()
    {
        float x = Random.Range(-ScreenBounds.x-1f, ScreenBounds.x+1);
        float y = Random.Range(0, 2) == 0 ? -ScreenBounds.y-1f : ScreenBounds.y+1f;
        return new Vector3(x, y, 0);
    }


}
