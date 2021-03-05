using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace A2
{
    public enum BtnInputType
    {
        Down = 1,
        Press = 2,
        Up = 3
    }

    public enum BtnType
    {
        Main1 = 1,
        Main2 = 2,
        Main3 = 2,
        Sub1 = 4,
        Sub2 = 5,
        Sub3 = 6
    }

    public class PlayerController : SingletonMono<PlayerController>
    {
        public Character player;
        
        public float sensitivityX = 10f;
        public float sensitivityY = 10f;
        
        public bool revertY = false;

        void Update()
        {
            PlayerMoveUpdate();
            RotateUpdate();
            PlayerJumpUpdate();
            OperationBtn();
        }

        private void PlayerMoveUpdate()
        {
            float v = Input.GetAxis("Vertical");
            float h = Input.GetAxis("Horizontal");
            bool dash = Input.GetKey(KeyCode.LeftShift);
            player.Move(v, h, dash);
        }

        private void RotateUpdate()
        {
            float rotateX = Input.GetAxis ("Mouse X") * sensitivityX;
            float rotateY = 0;
            if(revertY)
            {
                rotateY = -Input.GetAxis ("Mouse Y") * sensitivityY;
            }
            else
            {
                rotateY = Input.GetAxis ("Mouse Y") * sensitivityY;
            }
            player.Rotate(rotateX, rotateY);
        }

        private void PlayerJumpUpdate()
        {
            if(Input.GetKey(KeyCode.Space)) player.Jump();
        }

        private void OperationBtn()
        {
            if(player.initiativeEquipment == null) return;

            if(Input.GetMouseButtonDown(0)) player.initiativeEquipment.FunctionBtnInput(player,BtnType.Main1,BtnInputType.Down);
            if(Input.GetMouseButtonDown(0)) player.initiativeEquipment.FunctionBtnInput(player,BtnType.Main1,BtnInputType.Press);
            if(Input.GetMouseButtonUp(0)) player.initiativeEquipment.FunctionBtnInput(player,BtnType.Main1,BtnInputType.Up);

            if(Input.GetMouseButtonDown(1)) player.initiativeEquipment.FunctionBtnInput(player,BtnType.Main2,BtnInputType.Down);
            if(Input.GetMouseButtonDown(1)) player.initiativeEquipment.FunctionBtnInput(player,BtnType.Main2,BtnInputType.Press);
            if(Input.GetMouseButtonUp(1)) player.initiativeEquipment.FunctionBtnInput(player,BtnType.Main2,BtnInputType.Up);

            if(Input.GetKeyDown ("r")) player.initiativeEquipment.FunctionBtnInput(player,BtnType.Sub1,BtnInputType.Down);
        }
    }
}