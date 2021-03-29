using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Text countText;
    private int count;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        setCountText();
    }

    // Update is called once per frame
    void Update()
    {

    }
    
   private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        
        //if(moveVertical!=0)
        //    print(moveVertical);

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        GetComponent<Rigidbody>().AddForce(movement*speed*Time.deltaTime);
    }

   private void OnTriggerEnter(Collider other)
   {
       if (other.gameObject.tag == "PickUp")
       {
           other.gameObject.SetActive(false);
           count++;
           setCountText();
           
           //other.gameObject.transform.position = new Vector3(Random.Range(-10.0f, 10.0f), 1.0f, Random.Range(-10.0f, 10.0f));
           //other.gameObject.SetActive(true);
       }
   }
   
   void setCountText()
   {
       countText.text = "Count:" + count;
   }
}
