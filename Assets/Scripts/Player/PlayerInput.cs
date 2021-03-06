using UnityEngine;
using Photon.Pun;

namespace Player
{
    //Manages all player input and feeds it to movement script
    public class PlayerInput : MonoBehaviour
    {
        [Header("Keys")]
        public KeyCode trot;
        public KeyCode run, jump, crouch, glide, fly;

        public Creature.Movement move;
        public PlayerManager manager;
        PhotonView pv;

        void Start()
        {
            pv = GetComponent<PhotonView>();
        }

        void Update()
        {
            if (!pv.IsMine) return;

            //Input
            Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

            if (GameStateManager.Instance.paused) move.moveInput = null;
            else move.moveInput = GetInput();
        }

        Creature.MoveInput GetInput()
        {
            return new Creature.MoveInput(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")),
                Input.GetKeyDown(crouch), Input.GetKey(trot), Input.GetKey(run),
                Input.GetKeyDown(jump), Input.GetKeyDown(glide), Input.GetKeyDown(fly),
                Input.GetKey(crouch), Input.GetKey(jump));
        }

    }
}
