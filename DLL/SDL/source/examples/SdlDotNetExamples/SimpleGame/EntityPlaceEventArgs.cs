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

namespace SdlDotNetExamples.SimpleGame
{
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    public class EntityPlaceEventArgs : EventArgs
    {
        Entity entity;
        /// <summary>
        /// 
        /// </summary>
        public EntityPlaceEventArgs(Entity entity)
        {
            this.entity = entity;
        }

        /// <summary>
        /// 
        /// </summary>
        public Entity Entity
        {
            get
            {
                return this.entity;
            }
        }
    }
}
