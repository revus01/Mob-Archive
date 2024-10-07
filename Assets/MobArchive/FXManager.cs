using UnityEngine;

namespace MobArchive
{
    public class FXManager
    {
        private static FXManager _instance;

        public static FXManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new FXManager();
                }
                return _instance;
            }
        }

        public void PlayFX()
        {
            
        }
    }
}