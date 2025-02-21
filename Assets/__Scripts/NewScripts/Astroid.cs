using UnityEngine;

public class Astroid : MonoBehaviour
{
    [SerializeField] Asteroid_SO Asteroid_SO_;

    char AsteroidType;

    void Awake()
    {
        AsteroidType = this.name[9];

        this.transform.LookAt(Vector3.zero);

        this.GetComponent<Rigidbody>().velocity = GetDirection() * GetSpeed();
        this.GetComponent<Rigidbody>().angularVelocity = GetRotation() * GetSpeed() * 10;
    }
    private Vector3 GetDirection()
    {
        Vector3 direction = this.transform.forward;

        direction.x += Random.Range(-0.2f, 0.2f);
        direction.y += Random.Range(-0.2f, 0.2f);

        return direction.normalized;
    }
    private Vector3 GetRotation()
    {
        float x = Random.Range(-5f, 5f);
        float y = Random.Range(-5f, 5f);
        float z = Random.Range(-5f, 5f);
        return new Vector3 (x, y, z);
    }
    private float GetSpeed()
    {
        switch (AsteroidType)
        {
            case 'A': return 1.5f;
            case 'B': return 2.25f;
            case 'C': return 3f;
            default: return 1f;
        }
    }


    void Start()
    {
        SpawnChildren();
    }
    private void SpawnChildren()
    {
        if (AsteroidType == 'C')
            return; 

        GameObject[] childrenAsteroids = new GameObject[] {Asteroid_SO_.GetAstroid((char)(AsteroidType+1)), Asteroid_SO_.GetAstroid((char)(AsteroidType+1))};

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
        {
            this.transform.localPosition = Vector3.zero;
            this.transform.localRotation = Quaternion.identity;
        }
    }

}
