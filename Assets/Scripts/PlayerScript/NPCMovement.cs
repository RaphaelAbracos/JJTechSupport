using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class NPCMovement: MonoBehaviour {
     
     // Private Variables
     private Vector3 waypointAtual;
     private int wpElegido;
     
	 [SerializeField]
	 private GameObject[] waypoints;

	 [SerializeField]
	 private float waitTime;
     // @ public variables
     public float speed;
     
     // @ Arrays
     private ArrayList listWaypoints = new ArrayList();
     
     // @ Comportamento
     private bool walk = true;

	 [SerializeField]
	 private bool isLoop = false;
     
     void Start () {
         // @ Agregamos las posiciones de los waypoints a la lista
         foreach (GameObject waypoint in waypoints){
             listWaypoints.Add(waypoint.transform.position);
         }
         
         // @ Definimos el primer waypoint al cual dirigirse
         waypointAtual = (Vector3) listWaypoints[0];
     }
     
     
     void Update () {
         comprobarDistancia();
         if (walk)
             Walk ();
         else {
             StartCoroutine(Wait());
         }
 
     }
     
     void Walk(){
         //GetComponent<Animation>().CrossFade ("walk");
         moveNPCTowards (waypointAtual);
     }
     
     IEnumerator Wait(){
        // GetComponent<Animation>().CrossFade ("idle");
         yield return new WaitForSeconds (waitTime);
         walk = true;
     }
     
 
     void comprobarDistancia(){
         // Elegimos un waypoint nuevo cuando ya se acerco lo suficiente al actual
         if (Vector3.Distance (transform.position, waypointAtual) < 2.0f)
             selectNewWaypoint();
     }
     
     void selectNewWaypoint(){
         if (++wpElegido == listWaypoints.Count && isLoop){
		  wpElegido = 0;
		 }
		 
		
         waypointAtual = (Vector3) listWaypoints[wpElegido];
 
         walk = false;
     }
     
     void moveNPCTowards(Vector3 waypointAtual){

         Vector3 direccion = waypointAtual - transform.position;
         
         Vector3 movimiento = direccion.normalized * speed * Time.deltaTime;
         
         transform.LookAt(waypointAtual);
         transform.position = transform.position + movimiento;
         
     }
     
 
         
 }