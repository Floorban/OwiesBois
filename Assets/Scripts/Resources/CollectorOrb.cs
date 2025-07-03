using UnityEngine;

public class CollectorOrb : MonoBehaviour{
    [SerializeField] int Money=0;
    // Update is called once per frame
    private void Start() {
        
    }
    void Update(){
        
    }
    private void OnTriggerEnter(Collider collision) {
        if (collision.transform.tag=="Collectable"){
            // play animation
            Money += collision.gameObject.GetComponent<HumanScript>().GetValue();
            Destroy(collision.gameObject);
        }
    }

}
