using UnityEngine;

public class Astroid : MonoBehaviour
{
    [SerializeField] Asteroid_SO Asteroid_SO_;
    private static GameObject PlayerShip;

    char AsteroidType;

    void Awake()
    {
        PlayerShip = GameObject.Find("PlayerShip");
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

            GameObject astroid = Instantiate(smallAstroid, new Vector3(x, y, z), Quaternion.identity, this.transform);
            astroid.GetComponent<MeshCollider>().enabled = false;
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

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerRespawn>().EnablePlayer(false);
        }

        if (collision.gameObject.tag == "Bullet")
        {
            PlayerShip.GetComponent<PlayerScore>().IncreasePlayerScore(this.AsteroidType);
            
            collision.collider.enabled = false;
            Destroy(collision.gameObject);
        }
        
        if (this.AsteroidType != 'C')
        {
            for (int i=0; i<2; ++i)
            {
                if (this.transform.childCount <= 0)
                    continue;
                
                Transform astroidTransform = this.transform.GetChild(0);

                astroidTransform.GetComponent<MeshCollider>().enabled = true;

                astroidTransform.GetComponent<Rigidbody>().velocity = Random.onUnitSphere * GetSpeed() * 2;
                astroidTransform.GetComponent<Rigidbody>().angularVelocity = Random.onUnitSphere * GetSpeed() * 7;

                astroidTransform.SetParent(null);
            }
        }
        
        Destroy(this.gameObject);
    }

}
