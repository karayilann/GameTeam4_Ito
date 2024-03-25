using UnityEngine;

namespace _Project.Scripts.CharacterScripts
{
    public class PlayerMovement : MonoBehaviour
    {
        public float MoveSpeed;
        private Vector3 firstPosition;
        private Vector3 lastPosition; // Yapılan kaydırma miktarı
        
        
        void Update()
        {
            PlayerRun();
            PlayerSwipe();
        }
        
        public void PlayerRun()
        {
            Vector3 translation = new Vector3(MoveSpeed * Time.deltaTime,0,0);
            transform.Translate(translation);
        }

        public void PlayerSwipe()
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began) // Dokunma evresi hangi aşamada
                {
                    firstPosition = transform.position;
                    lastPosition = transform.position;
                    Debug.Log("Başladı " +firstPosition);
                    //
                }

                if (touch.phase == TouchPhase.Ended)
                {
                    lastPosition = transform.position;
                    Debug.Log("Bitti " + lastPosition);
                }
                
            }
            
            // aradaki farkın mutlak değeri alınarak yapılan yöndeki değere atanacak
            
        }
        
    }
}
