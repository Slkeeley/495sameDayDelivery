using UnityEngine;

namespace SameDayDelivery.Controls
{
    public class
        BasicCameraFollow : MonoBehaviour //THIS IS A PLACEHOLDER SCRIPT TO HAVE A BASIC CAMERA FOLLOW FOR TESTING PURPOSES
    {
        public GameObject following;

        // Start is called before the first frame update
        void Start()
        {
            transform.position = new Vector3(following.transform.position.x, transform.position.y,
                following.transform.position.z); //make sure camera starts at x and z coords of target obj
        }


        void LateUpdate()
        {
            transform.position = new Vector3(following.transform.position.x, transform.position.y,
                following.transform.position.z); //keep upadting if the object moves
        }
    }
}
