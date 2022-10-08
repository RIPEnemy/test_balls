using UnityEngine;

namespace Game
{
    public class PlayerBall : Ball
    {
        private readonly float DIRECTION_MIN = -1.0f;
        private readonly float DIRECTION_MAX = 1.0f;

        private float time;
        private Vector3 direction;
        private float speed;

        /// <summary>
        /// Invoke to construct the ball.
        /// </summary>
        public override void Construct(BallsSettings settings)
        {
            base.Construct(settings);

            RandomizeMovement();
        }

        private void Update()
        {
            time += Time.deltaTime;

            if (time >= SETTINGS.DirectionAndSpeedRandomizeTime)
            {
                time = 0.0f;

                RandomizeMovement();
            }

            Move();

            State = GenerateState();
        }

        private void RandomizeMovement()
        {
            speed = Random.Range(SETTINGS.MinSpeed, SETTINGS.MaxSpeed);

            direction = new Vector3(
                Random.Range(DIRECTION_MIN, DIRECTION_MAX),
                0.0f, // prevent movement by Y axis
                Random.Range(DIRECTION_MIN, DIRECTION_MAX)
            );
        }

        protected override void Move()
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                transform.position + direction,
                speed * Time.deltaTime
            );
        }

        private BallState GenerateState()
        {
            return new BallState(direction, speed, transform.position);
        }
    }
}