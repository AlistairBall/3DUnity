using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using System;



[RequireComponent(typeof(CharacterController))]
public class PlayerControler : MonoBehaviour
{
    // Var
    private float speed;
    private float rotationSpeed;
    private float jumpHeight;
    private float gravity;
    private float MaxStamina;
    private float CurrStamina;

    public Image healthBar;
    public GameObject shovelIcon;
    public GameObject goldKeyIcon;
    public GameObject silverKeyIcon;

    public Text AmmoText;
    public Text Notification;


    private bool isSprinting = false;
    private Vector3 moveDirection = Vector3.zero;
    private bool sMoveType;
    private CharacterController cc;
    public bool inBush;
    private bool hasGoldKey = false;
    private bool hasShovel = false;
    private bool hasSilverKey = false;

    public bool hasRifle;
    public bool hasShotgun;

	public int health;
    public int pistolAmmo;
    public int rifleAmmo;
    public int shotgunAmmo;
    public Stack Weapons;

   // public Projectile projectilePrefab;
   // public Transform projectileSpawnPoint;
    public GameObject AK47;
    public GameObject Handgun;
    public GameObject Shotgun;
    public GameObject shovelWaypoint;
    public GameObject goldKeyWaypoint;
    public GameObject silverKeyWaypoint;

    public GameObject[] Enemies;
    public GameObject enemyGameObject;
    // Initialization ( On Create )
    void Start ()
    {
        MaxStamina = 75;
        CurrStamina = MaxStamina;
        speed = 8;
        rotationSpeed = 6;
        jumpHeight = 15;
        gravity = 9.8f;
        Weapons = new Stack();
        inBush = false;

        silverKeyWaypoint.SetActive(false);
        goldKeyWaypoint.SetActive(false);
        shovelWaypoint.SetActive(false);

        hasRifle = false;
        hasShotgun = false;



        if (Enemies == null)
        {
            Enemies = GameObject.FindGameObjectsWithTag("basicEnemy");
           
        }

       

        cc = GetComponent<CharacterController>();
        if (!cc) gameObject.AddComponent<CharacterController>();

    

    }
	
	// Update is called once per frame
	void Update ()
    {
        
        

        if (isSprinting == false)
        {
            try
            {
                StartCoroutine("GainStamina");
            }

            catch(Exception e)
            {
                Debug.LogWarning(e);
            }
        }
		

		// hit ESC to unlock mouse and use cursor
		if (Input.GetKey(KeyCode.Escape)) {Screen.lockCursor = false;}
		else
		{
			Screen.lockCursor = true;
			// mouse position on the x axis
			transform.Rotate(0, Input.GetAxis("Mouse X") * rotationSpeed, 0);
		}


        RaycastHit hit;

     //  Debug.DrawRay(transform.position, transform.forward * 5.0f, Color.red);

       // if (Physics.Raycast(transform.position, transform.forward, out hit, 5.0f))
       //{
       //    Debug.Log(hit.collider.name);
       //}

  
        


      

        //----------------------------Controls--------------------------------------------------------------

      //  Debug.Log(projectileSpawnPoint.position);
      

        

        if (Input.GetKeyDown(KeyCode.Q))
        {
            SceneManager.LoadScene("StartMenu", 0);
            Cursor.visible = true;
            Screen.lockCursor = false;


        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Handgun.SetActive(true);
            AmmoText.text = "Ammo: Infinite";
            AK47.SetActive(false);
            Shotgun.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && hasRifle == true)
        {
            Handgun.SetActive(false);
            AK47.SetActive(true);
            AmmoText.text = "Ammo :" + rifleAmmo.ToString();
            Shotgun.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && hasShotgun == true)
        {
            Handgun.SetActive(false);
            AK47.SetActive(false);
            Shotgun.SetActive(true);
            AmmoText.text = "Ammo :" + shotgunAmmo.ToString();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            try
            {
               
                speed = 15;
                isSprinting = true;
                StartCoroutine("Stamina");
            }
            catch (Exception e)
            {
                Debug.LogWarning(e);
            }


        }

        if(health<= 0)
        {
            Notification.text = "GAME OVER";

            Screen.lockCursor = false;
            Cursor.visible = true;
            SceneManager.LoadScene("StartMenu", 0);
        }




        //---------------COntrole END-------------------------------

        if (CurrStamina < 0)
        {
            CurrStamina = 0;
        }






        float curSpeed = Input.GetAxis("Vertical") * speed;
        cc.SimpleMove(transform.forward * curSpeed);
		curSpeed = Input.GetAxis("Horizontal") * speed * 2;
		cc.SimpleMove(transform.right * curSpeed);


        // Jump
        if (cc.isGrounded)
		{
			moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));

            //float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
            //float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;
            //   target.transform.Rotate(vertical, horizontal, 0);
            if (Screen.lockCursor)
            {
              
               
                transform.Rotate(0, Input.GetAxis("Mouse X") * rotationSpeed, 0);
                
            }

           

            moveDirection = transform.TransformDirection(moveDirection);

			moveDirection *= speed;

			if (Input.GetButtonDown("Jump"))
				moveDirection.y = jumpHeight;
		}

		// Apply gravity
		moveDirection.y -= gravity * Time.deltaTime;
		cc.Move(moveDirection * Time.deltaTime);


		//update end
	}

    public void QuitGame()
    {
        // quite  game in editor
#if UNITY_EDITOR
       
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }


    IEnumerator Stamina()
    {
        for (float f = CurrStamina; f <= MaxStamina && f >= 1; f--)

        {
            if (Input.GetKeyUp(KeyCode.LeftShift)){
                f = CurrStamina;
                isSprinting = false;
                break;
            }
            
            else 
            { 
                CurrStamina--;
               // Debug.Log(CurrStamina + "/" + MaxStamina);
                yield return new WaitForSeconds(.1f);
            }
        }
        speed = 8;
        isSprinting = false;
    }

    IEnumerator GainStamina()
    {
        for (float g = CurrStamina; g < MaxStamina && g >= 0; g++)

        {
            CurrStamina++;
         //   Debug.Log(CurrStamina + "/" + MaxStamina);


           
            if (CurrStamina > MaxStamina)
            {
                CurrStamina = MaxStamina;
                break;
            }
            yield return new WaitForSeconds(.5f);

        }
       
    }

    void OnTriggerEnter (Collider other)
    {
        if( gameObject.tag == "Player" && other.gameObject.tag == "PickUpHP" )
        {

            if (health == 200)
            {
                healthBar.fillAmount = 1.0f;
            }
            else if (health >= 150)
            {
                health = 200;
                healthBar.fillAmount = 1.0f;
                Destroy(other.gameObject);
            }
            else
            {
                //Debug.Log(other.gameObject.name);
                health += 50;
                healthBar.fillAmount = healthBar.fillAmount + 0.25f;
                Destroy(other.gameObject);
            }
        }

        if (gameObject.tag == "Player" && other.gameObject.tag == "ShovelPickup")
        {
            //Debug.Log(other.gameObject.name);
            hasShovel = true;
            shovelIcon.SetActive(true);
            shovelWaypoint.SetActive(true);
            Destroy(other.gameObject);
            Notification.text = "Go to the West Wall and dig to Escape!";
            Invoke("ClearNotificationtext", 6);
            
        }

        if (gameObject.tag == "Player" && other.gameObject.tag == "GoldKeyPickup")
        {
            //Debug.Log(other.gameObject.name);
            hasGoldKey = true;
            goldKeyIcon.SetActive(true);
            goldKeyWaypoint.SetActive(true);
            Destroy(other.gameObject);
            Notification.text = "Get to the North Gate to Escape!";
            Invoke("ClearNotificationtext", 6);
          
        }


        if (gameObject.tag == "Player" && other.gameObject.tag == "SilverKeyPickup")
        {
            //Debug.Log(other.gameObject.name);
            hasSilverKey = true;
            silverKeyIcon.SetActive(true);
            silverKeyWaypoint.SetActive(true);
            Destroy(other.gameObject);
            Notification.text = "Go to the Docks and get on a Boat to Escape!!";
            Invoke("ClearNotificationtext", 6);
          
        }



     

		if(other.gameObject.tag == "PickUpRifle" && gameObject.tag == "Player")
        {
            if(hasRifle == false)
            {
                hasRifle = true;

                Handgun.SetActive(false);
                AK47.SetActive(true);
                Shotgun.SetActive(false);

                rifleAmmo = 150;
                AmmoText.text = "Ammo: " + rifleAmmo.ToString();
                AddRifleAmmoText();

                Destroy(other.gameObject);


            }
            else 

            rifleAmmo += 50;
        
                Destroy(other.gameObject);
            
        }

        if (other.gameObject.tag == "PickUpShotgun" && gameObject.tag == "Player")
        {
            if (hasShotgun == false)
            {
                hasShotgun = true;

                Handgun.SetActive(false);
                AK47.SetActive(false);
                Shotgun.SetActive(true);

                shotgunAmmo = 20;
                AmmoText.text = "Ammo: " + shotgunAmmo.ToString();
                AddShotgunAmmoText();

                Destroy(other.gameObject);


            }
            else

            shotgunAmmo += 10;
           
            Destroy(other.gameObject);

        }

        if (other.gameObject.tag == "Hide")
        {
            // Enemy enemyScript = enemyGameObject.GetComponent<Enemy>();

            // enemyScript.Getem = true;

             inBush = true;

        }

        if (other.gameObject.tag == "EndGameShovel" && hasShovel == true )
        {
            Notification.text = "Congratulations! You escaped!";
            Invoke("QuitGame", 5);
        }
        else if(other.gameObject.tag == "EndGameShovel" && hasShovel == false)
        {
            Notification.text = "Comeback when you have something to dig under this hole with!";
            Invoke("ClearNotificationtext", 6);
        }

        if (other.gameObject.tag == "EndGameSilverKey" && hasSilverKey == true)
        {
            Notification.text = "Congratulations! You escaped!";
            Invoke("QuitGame", 5);
        }
        else if (other.gameObject.tag == "EndGameSilverKey" && hasSilverKey == false)
        {
            Notification.text = "Comeback when you have a silver key to sail away!";
            Invoke("ClearNotificationtext", 6);
        }

        if (other.gameObject.tag == "EndGameGoldKey" && hasGoldKey == true)
        {
            Notification.text = "Congratulations! You escaped!";
            Invoke("QuitGame", 5);
        }
        else if (other.gameObject.tag == "EndGameGoldKey" && hasGoldKey == false)
        {
            Notification.text = "Comeback when you have a gold key to unlock this gate!";
            Invoke("ClearNotificationtext", 6);
        }
    }

    void OnTriggerExit( Collider other)
    {
        if(other.gameObject.tag == "Hide")
        {
            inBush = false;
        }
    }

    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag == "Projectile" || c.gameObject.tag == "Pellet")
        {
            health -= 10;

            healthBar.fillAmount = healthBar.fillAmount - 0.05f;
        }
    }

  

    void AddRifleAmmoText()
    {
        AmmoText.text = "Ammo: " + rifleAmmo.ToString();
    }

    void AddShotgunAmmoText()
    {
        AmmoText.text = "Ammo: " + shotgunAmmo.ToString();
    }

    void ClearNotificationtext()
    {
        Notification.text = "";
    }

}