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
        int x = Random.Range((int)(-ScreenBounds.x), (int)(ScreenBounds.x+1));
        int y = Random.Range((int)(-ScreenBounds.y), (int)(ScreenBounds.y+1));
        return new Vector3(x, y, 0);
    }


}
