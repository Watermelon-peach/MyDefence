using UnityEngine;

namespace Solid
{
    public interface ISwitchable
    {
        public bool IsActive { get; }
        public void Activate();
        public void Deactivate();
    }

}
