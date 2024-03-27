using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Project.Scripts.CharacterScripts
{
    public class PlayerMovement : MonoBehaviour
    {
        public float MoveSpeed;
        public float CharacterSwipeAmount; // 
        public float ScreenDragVaue;  // This variable created for set the slide value. Must use with Screen.Height
        
        private Vector3 _firstPosition;
        private Vector3 _lastPosition; // Yapılan kaydırma miktarı

        private Touch _swipeTouch;

        void Update()
        {
            PlayerRun();
            PlayerSwipeController();
        }

        private void PlayerRun()
        {
            Vector3 _runRight = new Vector3(MoveSpeed * Time.deltaTime, 0, 0);
            transform.Translate(_runRight);
        }

        private void PlayerSwipeController()
        {
            if (Input.touchCount > 0)
            {
                _swipeTouch = Input.GetTouch(0);

                switch (_swipeTouch.phase)
                {
                    case TouchPhase.Began:
                        _firstPosition = _swipeTouch.position;
                        _lastPosition = _swipeTouch.position;
                        break;
                    
                    case TouchPhase.Moved:
                        _lastPosition = _swipeTouch.position;
                        break;
                    
                    case TouchPhase.Ended:
                    {
                        if (Mathf.Abs(_lastPosition.y - _firstPosition.y) > ScreenDragVaue)
                        {
                            if (_lastPosition.y > _firstPosition.y)
                            {
                                //Yukarı kaydırma yazılacak
                                Debug.Log("Up Swipe");
                                PlayerSwipe();
                            }
                            else
                            {
                                //Aşağı kaydırma yazılacak
                                Debug.Log("Down Swipe");
                                PlayerSwipe();
                            }
                        }

                        break;
                    }
                }
            }
        }

        private void PlayerSwipe()
        {
            var _characterMoveDirection = new Vector3(0,CharacterSwipeAmount * Time.deltaTime,0);
            transform.Translate(_characterMoveDirection);
        }
        
        
    }
}