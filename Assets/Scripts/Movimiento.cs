using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour {
    public float velocidadInicial = 0;
    public float velocidadFrontal = 10;
    public float velocidadRotacion =50;
  //  public float angle = 0;
   // public int min = -45;
  //  public int max = 45;
    public AudioClip aceleracion;
    public Animator animator;
    public ParticleSystem derrapeDerecha;
    public ParticleSystem derrapeIzquierda;
    Vida vida;
    public Rigidbody _rb;
    //Celular
    public bool derecha = false;
    public bool izquierda = false;
    public bool turbo = false;
    

    void Start () 
    {
        _rb = GetComponent<Rigidbody>();
        vida = GetComponent<Vida>();
        if(gameObject.tag == "Player")
          //  SonidoMotor();

        animator = GetComponent<Animator>();

    }

    void FixedUpdate() 
    {

        
            velocidadRotacion = 100;
            Vector3 newPosition = _rb.position + transform.TransformDirection(0, 0, velocidadFrontal * Time.deltaTime);
            _rb.MovePosition (newPosition);
         
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow )||derecha)
        {


          
              gameObject.transform.Rotate(0, velocidadRotacion * Time.deltaTime, 0);
          //  angle += velocidadRotacion;
            animator.SetBool("derecha", true);
            
        }
        else  if(Input.GetKeyUp(KeyCode.D)||!derecha)
        {
           
            animator.SetBool("derecha", false);
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)||izquierda)
        {
            // angle -= velocidadRotacion;
            gameObject.transform.Rotate(0,- velocidadRotacion * Time.deltaTime, 0);
            animator.SetBool("izquierda", true);
            
        }

        else if (Input.GetKeyUp(KeyCode.A)||!izquierda)
        {
            animator.SetBool("izquierda", false);
            
        }
            
        if (Input.GetKey(KeyCode.A) || izquierda||Input.GetKey(KeyCode.D) || derecha)
        {
            var emission= derrapeDerecha.emission;
            var emission1 = derrapeIzquierda.emission;
            emission.enabled = true;
            
            emission1.enabled = true;
        }
        else
        {
            var emission1 = derrapeDerecha.emission;
            var emission = derrapeIzquierda.emission;
            emission.enabled = false;
            
            emission1.enabled = false;
        }
        
       // transform.position = new Vector3(Mathf.Clamp(transform.position.x, -44f, 55f), Mathf.Clamp(transform.position.y,0f,4f), Mathf.Clamp(transform.position.z,-16f,341f));//para que no se caiga por los laterales
                                                                                                                                        //angle = Mathf.Clamp(angle, min, max);
      //  transform.eulerAngles = new Vector3(0, angle, 0);

    }



    
}

