using UnityEngine;

public class Astroid : MonoBehaviour
{
    [SerializeField] Asteroid_SO Asteroid_SO_;

    void Awake()
    {
        this.transform.LookAt(Vector3.zero);

        this.GetComponent<Rigidbody>().velocity = GetDirection() * 1.5f;
    }
    private Vector3 GetDirection()
    {
        Vector3 direction = this.transform.forward;

        direction.x += Random.Range(-3f, 3f);
        direction.y += Random.Range(-3f, 3f);

        return direction;
    }


    void Start()
    {
        SpawnChildren();
    }
    private void SpawnChildren()
    {
        char asteroidType = this.name[9];
        if (asteroidType == 'C')
            return; 

        GameObject[] childrenAsteroids = new GameObject[] {Asteroid_SO_.GetAstroid((char)(asteroidType+1)), Asteroid_SO_.GetAstroid((char)(asteroidType+1))};

        Bounds parentBounds = this.GetComponent<Renderer>().bounds;

        foreach (GameObject smallAstroid in childrenAsteroids)
        {
            float x = Random.Range(parentBounds.min.x, parentBounds.max.x);
            float y = Random.Range(parentBounds.min.y, parentBounds.max.y);
            float z = Random.Range(parentBounds.min.z, parentBounds.max.z);

            Instantiate(smallAstroid, new Vector3(x, y, z), Quaternion.identity, this.transform);
        }
    }


    void Update()
    {
        StayAttachToParent();
    }
    private void StayAttachToParent()
    {
        if (this.transform.parent != null)
            this.transform.localPosition = Vector3.zero;
    }

}
