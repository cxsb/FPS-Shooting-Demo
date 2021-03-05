using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A2
{
    public class InitiativeEquipment : Equipment, IInitiativeEquipment
    {
        public InitiativeEquipment()
        {
            isInitiative = true;
        }

        virtual public void FunctionBtnInput(Character character, BtnType btnType, BtnInputType btnInputType)
        {

        }
    }

    public interface IInitiativeEquipment {
        void FunctionBtnInput(Character character, BtnType btnType, BtnInputType btnInputType);
    }
}