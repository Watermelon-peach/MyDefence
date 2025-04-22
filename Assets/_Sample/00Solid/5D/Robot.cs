using UnityEngine;

namespace Solid
{
    public class Robot : MonoBehaviour, ISwitchable
    {
        private bool isActive;
        public bool IsActive => isActive;
        public void Activate()
        {
            throw new System.NotImplementedException();
        }

        public void Deactivate()
        {
            throw new System.NotImplementedException();
        }
    }

}
