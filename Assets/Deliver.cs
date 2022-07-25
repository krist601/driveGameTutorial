using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deliver : MonoBehaviour{
    bool hasPackage;
    [SerializeField] float destroyDelay = 0.5f;
    [SerializeField] Color32 packageColor2 = new Color32(255, 0, 0, 255);
    [SerializeField] Color32 noPackageColor2 = new Color32(22, 233, 10, 255);
    SpriteRenderer spriteRenderer;

    private void Start(){
        hasPackage = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void OnCollisionEnter2D(Collision2D other){
        Debug.Log("Ouch!");
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Package" && hasPackage == false){
            Debug.Log("Pick the package up!");
            Destroy(other.gameObject, 0.0f);
            hasPackage = true;
            spriteRenderer.color = packageColor2;
        }else if(other.tag == "Package" && hasPackage == true){
            Debug.Log("Already have a package!");
        }else if (other.tag == "Customer" && hasPackage == true){
            Debug.Log("Package delivered!");
            hasPackage = false;
            spriteRenderer.color = noPackageColor2;
            Destroy(other.gameObject, destroyDelay);
        }else if(other.tag == "Customer" && hasPackage == false){
            Debug.Log("Don't have a package D:!");
        }
    }
}
