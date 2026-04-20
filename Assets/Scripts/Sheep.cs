using UnityEngine;

public class Sheep : MonoBehaviour
{

    public GameObject explosion;
    public float runSpeed;
    public float gotHayDestroyDelay;
    private bool hitByHay;
    public float dropDestroyDelay; 
    private Collider myCollider; 
    private Rigidbody myRigidbody;
    private SheepSpawner sheepSpawner;
    private bool loselife = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myCollider = GetComponent<Collider>();
        myRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * runSpeed * Time.deltaTime);
    }
    private void HitByHay()
    {
        sheepSpawner.RemoveSheepFromList(gameObject);
        hitByHay = true; 
        runSpeed = 0; 
        GameObject e = Instantiate(explosion, transform.position, Quaternion.identity);
        e.transform.localScale = new Vector3(3,3,3);
        Destroy(gameObject, gotHayDestroyDelay); 
    }
    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Hay") && !hitByHay) 
        {
            Destroy(other.gameObject);
            ScoreManager.instance.AddPoint();
            HitByHay(); 
        }
        else if (other.CompareTag("DropSheep") && !loselife)
        {
            loselife = true;
            LifeManagment.instance.LoseLife();
            Drop();
        }
        

    }
    private void Drop()
    {
        sheepSpawner.RemoveSheepFromList(gameObject);
        myRigidbody.isKinematic = false; 
        myCollider.isTrigger = false; 
        Destroy(gameObject, dropDestroyDelay); 
    }
    public void SetSpawner(SheepSpawner spawner)
    {
        sheepSpawner = spawner;
    }

}
