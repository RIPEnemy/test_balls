using UnityEngine;
using System;

namespace Game
{
    public class BallsSpawnManager : MonoBehaviour
    {
        [Header("General")]
        [SerializeField]
        private Transform _spawnPoint = null;
        [SerializeField]
        private BallsSettings _ballsSettings = null;

        [Header("Prefabs")]
        [SerializeField]
        private PlayerBall _playerBallPrefab = null;
        [SerializeField]
        private DuplicateBall _duplicateBallPrefab = null;

        [Header("Controls")]
        [SerializeField]
        private KeyCode _respawnKeyCode = KeyCode.R;

        private Ball playerBall;

        private void Start()
        {
            playerBall = Spawn(_playerBallPrefab);
        }

        private Ball Spawn(Ball prefab)
        {
            Ball newBall = Instantiate(prefab);

            MoveToSpawnPoint(newBall);

            newBall.Construct(_ballsSettings);

            return newBall;
        }

        /// <summary>
        /// Return ball to spawn point.
        /// </summary>
        /// <param name="ball">Reference to ball.</param>
        public void MoveToSpawnPoint(Ball ball)
        {
            if (ball == null)
                throw new ArgumentNullException(nameof(ball));

            ball.transform.position = _spawnPoint.transform.position;
        }

        private void Update()
        {
            if (!Input.GetKeyUp(_respawnKeyCode))
                return;

            MoveToSpawnPoint(playerBall);

            Spawn(_duplicateBallPrefab);
        }
    }
}