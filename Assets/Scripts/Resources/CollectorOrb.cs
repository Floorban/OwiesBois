using UnityEngine;

public class CollectorOrb : MonoBehaviour{

    // Update is called once per frame
    void Update(){
        
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.transform.tag=="Collectable"){
            // play animation

        }
    }
}
