using Solid.Dependency;
using UnityEngine;

namespace Solid
{
    public class Switch : MonoBehaviour
    {
        //public Door door;
        //public Robot robot;
        public GameObject switchTransform;
        public ISwitchable client;

        private void Start()
        {
            client = switchTransform.GetComponent<ISwitchable>();
            Debug.Log(client);
        }
        public void Toggle()
        {
            if (client.IsActive)
            {
                client.Deactivate();
            }
            else
            {
                client.Activate();
            }
        }
    }
}
