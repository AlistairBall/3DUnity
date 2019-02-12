using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AI : MonoBehaviour {

    public Transform Enemy;
    public GameObject[] Path;
    public Transform player;

    public Image basicHealthBar;
    public Image specialHealthBar;

    public float rotationDamping = 2f;

    public Projectile projectilePrefab;
    public Transform projectileSpawnPoint;

    public int basicHealth;
    public int specialHealth;

    public GameObject Spawner;

    int rotationSpeed = 80;
    private float speed = 0.2f;
    int currentWaypoint = 0;
    float accuracyWaypoint = 4.0f;
   

    public float shotInterval = 1f;
 
 private float shotTime = 0;

    private
    bool Getem = false;
    bool stop = false;
    bool isDead = false;

    Animator anim;

    // Use this for initialization
    void Start () {

        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 direction = player.position - this.transform.position;

        float angle = Vector3.Angle(direction, Enemy.up);

   

        Debug.Log(basicHealth + "/" + specialHealth);
        
      

        if (Getem == false)
        {
            direction = Path[currentWaypoint].transform.position - transform.position;
            this.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);
            this.transform.Translate(0, 0, Time.deltaTime * speed);
            anim.SetInteger("State", 1);
            transform.position = Vector3.MoveTowards(transform.position, Path[currentWaypoint].transform.position, 0.2f);
        }


        //
        if (Getem == true && (Time.time - shotTime) > shotInterval)
        {
            anim.SetInteger("State", 2);

            //transform.LookAt(player);
            LookAtTarget();

            shotTime = Time.time;
            Vector3 offset = new Vector3(0.0f, 0.7f, 0.0f);
            Instantiate(projectilePrefab, transform.position + (player.position - transform.position).normalized + offset, Quaternion.LookRotation(player.position - transform.position));
            
        }
    

        
    

        if (gameObject.tag == "basicEnemy" && basicHealth == 0)
        {
            anim.SetInteger("State", 3);
            shotInterval = 100;
            Destroy(gameObject, 2);
            speed = 0;

            Invoke("DropSpawner", 1.999999999f);
                
            
        }

        if (gameObject.tag == "specialEnemy" && specialHealth == 0)
        {
            anim.SetInteger("State", 3);
            shotInterval = 100;
            Destroy(gameObject, 2);
            speed = 0;

            Invoke("DropSpawner", 1.9999f);
        }

        if (Vector3.Distance(Path[currentWaypoint].transform.position, transform.position) < accuracyWaypoint)
        {
            currentWaypoint = Random.Range(0, Path.Length);


            //currentWaypoint++;
            //if(currentWaypoint >= Path.Length )
            //{
            //  currentWaypoint = 0;
            //}
        }
    }

    void OnCollisionEnter(Collision c)
    {
        //Destroy(c.gameObject);

        if (c.gameObject.tag == "Projectile" || c.gameObject.tag == "Pellet" && gameObject.tag == "basicEnemy" && basicHealth > 0)
        {
            basicHealth--;
            basicHealthBar.fillAmount = basicHealthBar.fillAmount - 0.333f;
            if (Getem == true)
            {
                anim.SetInteger("State", 4);
            }
            else
            {
                anim.SetInteger("State", 5);
            }
                    


        }


        if (gameObject.tag == "specialEnemy" &&  c.gameObject.tag == "Projectile" || c.gameObject.tag == "Pellet" &&  specialHealth > 0)
        {
            specialHealth--;
            specialHealthBar.fillAmount = specialHealthBar.fillAmount - 0.2f;
            if (Getem == true)
            {
                anim.SetInteger("State", 4);
            }
            else
            {
                anim.SetInteger("State", 5);
            }
        }

         
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            anim.SetInteger("State", 2);
           
            Getem = true;

         

        }

        if (other.gameObject.tag == "Hide")
        {
            Getem = false;
        }

  
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            anim.SetInteger("State", 1);
            Getem = false;
        }


    }

    void DropSpawner()
    {

        Instantiate(Spawner, transform.position, Quaternion.identity);
        Spawner.SetActive(true);
    }

    void LookAtTarget()
    {

      //  transform.LookAt(player.position);

        Vector3 dir = player.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed).eulerAngles;
        transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);

    }

}
