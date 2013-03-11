#region LICENSE
// Copyright 2005 David Hudson (jendave@yahoo.com)
// This file is part of SimpleGame.
//
// SimpleGame is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
//
// SimpleGame is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with SimpleGame; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
#endregion LICENSE

using System;
using System.Collections;
using SdlDotNet;

namespace SdlDotNetExamples.SimpleGame
{
    /// <summary>
    /// Summary description for Sector.
    /// </summary>
    public class Sector
    {
        Sector[] neighbors;
        //EventManager eventManager;

        /// <summary>
        /// 
        /// </summary>
        public Sector()
        {
            this.neighbors = new Sector[4];
        }

        /// <summary>
        /// 
        /// </summary>
        public bool MovePossible(Direction direction)
        {
            if (this.neighbors[(int)direction] != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="direction"></param>
        /// <returns></returns>
        public Sector GetNeighbors(Direction direction)
        {
            return this.neighbors[(int)direction];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="sector"></param>
        public void SetNeighbors(Direction direction, Sector sector)
        {
            this.neighbors[(int)direction] = sector;
        }
    }
}
