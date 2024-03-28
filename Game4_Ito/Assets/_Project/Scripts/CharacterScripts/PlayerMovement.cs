using System.Collections;
using System.Collections.Generic;
using _Project.Runtime.Core.Singleton;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Project.Scripts.CharacterScripts
{
    public class PlayerMovement : SingletonBehaviour<PlayerMovement>
    {
        public float MoveSpeed;
        public float CharacterSwipeAmount;
        public float SpeedIncreaseTimer;
        public float SpeedRiseFactor;
        public float AnimationRiseFactor;
        
        private float _screenDragValue; 
        public float ScreenPercentage;  //Minimum drag ratio on screen

        public Animator RunningAnimation;
        
        private Vector3 _firstPosition;
        private Vector3 _lastPosition; 

        private Touch _swipeTouch;

        public Color PlayerColor;

        public List<Color> _playerColors = new List<Color>() ;
        
        private void Awake()
        {
            var screenwWidthPercent = Screen.width / 100;
            _screenDragValue = screenwWidthPercent * ScreenPercentage;
        }
        
        private void Start()
        {
            InvokeRepeating("IncreaseMovementSpeed",0f,SpeedIncreaseTimer);
            SetPlayerColor();
        }


        void Update()
        {
            PlayerRun();
            PlayerSwipeController();
        }

        private void PlayerRun()
        {
            Vector3 _runRight = new Vector3(0, 0, MoveSpeed * Time.deltaTime);
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
                        if (Mathf.Abs(_lastPosition.y - _firstPosition.y) > _screenDragValue)
                        {
                            if (_lastPosition.y > _firstPosition.y)
                            {
                                PlayerSwipe(1);
                                PlayerRotate(1);
                            }
                            else
                            {
                                PlayerSwipe(1);
                                PlayerRotate(-1);
                            }
                        }

                        break;
                    }
                }
            }
        }

        
        /// <summary>
        /// Character's up and swipe method
        /// </summary>
        /// <param name="direction"></param>
        private void PlayerSwipe(int direction)
        {
            var _characterMoveDirection = new Vector3(0,CharacterSwipeAmount * direction,0);
            transform.Translate(_characterMoveDirection);
        }

        
        /// <summary>
        /// Function that rotates the character
        /// </summary>
        /// <param name="RotateDirection"></param>
        private void PlayerRotate(int RotateDirection)
        {
            var _CharacterRotation = new Vector3(RotateDirection * 180, RotateDirection * -180, 0);
            transform.Rotate(_CharacterRotation);
        }
        
        
        /// <summary>
        /// This coroutine created for increase run speed with time
        /// </summary>
        /// <returns></returns>
        private void IncreaseMovementSpeed()
        {
            MoveSpeed += SpeedRiseFactor;
            RunningAnimation.speed += AnimationRiseFactor;
        }
        
        /// <summary>
        /// Sets player color
        /// </summary>
        private void SetPlayerColor()
        {
            PlayerColor = _playerColors[Random.Range(0, 4)];
        }
        
        private void OnTriggerEnter(Collider other)
        {
            ICollisionable component = other.GetComponent<ICollisionable>();
            IObstacle obstacle = other.GetComponent<IObstacle>();

            if (component != null)
            {
                component.OnTriggerEvent();
                component = null;
            }
            
            if (obstacle != null)
            {
                var obstacleColor = obstacle.GetObstacleColor();

                if (PlayerColor != obstacleColor)
                {
                    Debug.Log("Game End");
                }
                
            }
            
        }
    }
}