///////////////////////////////////////////////////////////
//  Party.cs
//  Implementation of the Class Party
//  Generated by Enterprise Architect
//  Created on:      28-Apr-2014 10:13:37 PM
//  Original author: Gsimmons
///////////////////////////////////////////////////////////

using System;

namespace Mazegame.Entity
{
    public class Party
    {
        private Boolean moveable;
        public Mazegame.Entity.Location m_Location;
        public Mazegame.Entity.Character m_Character;

        public Party()
        {
        }

        public Boolean Moveable
        {
            get { return moveable; }
            set { moveable = value; }
        }
    } //end Party
} //end namespace Entity