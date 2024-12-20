using UnityEngine;

namespace Utilities
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour {
        public static T Instance { get; private set; }
        protected virtual void Awake() => Instance = this as T;

        protected virtual void OnApplicationQuit() {
            Instance = null;
            Destroy(gameObject);
        }
    }

    public class SingletonPersistent<T> : Singleton<T> where T : MonoBehaviour
    {
        protected override void Awake() {
            base.Awake();
            DontDestroyOnLoad(gameObject);
        }
    }
    
}