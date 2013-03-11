#region LICENSE
/*
 * Copyright (C) 2004 - 2007 David Hudson (jendave@yahoo.com)
 *
 * This library is free software; you can redistribute it and/or
 * modify it under the terms of the GNU Lesser General Public
 * License as published by the Free Software Foundation; either
 * version 2.1 of the License, or (at your option) any later version.
 * 
 * This library is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 * Lesser General Public License for more details.
 * 
 * You should have received a copy of the GNU Lesser General Public
 * License along with this library; if not, write to the Free Software
 * Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
 */
#endregion LICENSE

using System;
using System.Runtime.InteropServices;
using System.Globalization;
using System.Reflection;
using System.Resources;

using Tao.Sdl;
using SdlDotNet.Core;

namespace SdlDotNet.Audio
{
    /// <summary>
    /// Contains methods querying the CD drives on the system.
    /// </summary>
    /// <remarks>
    /// This class is initialized when the CDDrive object is first called.
    /// </remarks>
    public static class CDRom
    {
        #region Private fields

        static bool isInitialized = Initialize();

        #endregion 

        #region Public methods

        /// <summary>
        /// Returns true if the CDRom system has been initialized
        /// </summary>
        public static bool IsInitialized
        {
            get { return CDRom.isInitialized; }
        }

        /// <summary>
        /// Closes and destroys this object
        /// </summary>
        /// <remarks></remarks>
        public static void Close()
        {
            Events.CloseCDRom();
        }

        /// <summary>
        /// Starts the CDRom subsystem. 
        /// </summary>
        /// <remarks>
        /// This normally automatically started when 
        /// the CDRom or the CDDrive classes are initialized. 
        /// </remarks>
        public static bool Initialize()
        {
            if ((Sdl.SDL_WasInit(Sdl.SDL_INIT_CDROM))
                == (int)SdlFlag.FalseValue)
            {
                if (Sdl.SDL_Init(Sdl.SDL_INIT_CDROM) != (int)SdlFlag.Success)
                {
                    throw SdlException.Generate();
                }
                return false;
            }
            else
            {
                return true;
            }
        }

        //		/// <summary>
        //		/// Queries if the CDRom subsystem has been intialized.
        //		/// </summary>
        //		/// <remarks>
        //		/// </remarks>
        //		/// <returns>
        //		/// True if CDRom subsystem has been initialized, false if it has not.
        //		/// </returns>
        //		public static bool IsInitialized
        //		{
        //			get
        //			{
        //				if ((Sdl.SDL_WasInit(Sdl.SDL_INIT_CDROM) & Sdl.SDL_INIT_CDROM) 
        //					!= (int) SdlFlag.FalseValue)
        //				{
        //					return true;
        //				}
        //				else 
        //				{
        //					return false;
        //				}
        //			}
        //		}

        /// <summary>
        /// Gets the number of CD-ROM drives available on the system
        /// </summary>
        /// <remarks>
        /// </remarks>
        public static int NumberOfDrives
        {
            get
            {
                int ret = Sdl.SDL_CDNumDrives();
                if (ret == (int)CDStatus.Error)
                {
                    throw SdlException.Generate();
                }
                return ret;
            }
        }

        /// <summary>
        /// Checks if the drive number is valid
        /// </summary>
        /// <param name="index">drive number</param>
        /// <returns>
        /// true is the number is greater than 0 and less 
        /// than the number of drives on the system.
        /// </returns>
        public static bool IsValidDriveNumber(int index)
        {
            if (index >= 0 && index < NumberOfDrives)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Opens a CD-ROM drive for manipulation
        /// </summary>
        /// <param name="index">
        /// The number of the drive to open, from 0 - CDAudio.NumDrives
        /// </param>
        /// <returns>
        /// The CDDrive object representing the CD-ROM drive
        /// </returns>
        /// <remarks>
        /// Opens a CD-ROM drive for manipulation
        /// </remarks>
        public static CDDrive OpenDrive(int index)
        {
            IntPtr cd = Sdl.SDL_CDOpen(index);
            if (!IsValidDriveNumber(index) || (cd == IntPtr.Zero))
            {
                throw SdlException.Generate();
            }
            return new CDDrive(cd, index);
        }

        /// <summary>
        /// Returns a platform-specific name for a CD-ROM drive
        /// </summary>
        /// <param name="index">The number of the drive</param>
        /// <returns>A platform-specific name, i.e. "D:\"</returns>
        /// <remarks>
        /// </remarks>
        public static string DriveName(int index)
        {
            if (!IsValidDriveNumber(index))
            {
                throw new SdlException(Events.StringManager.GetString("IndexOutOfRange", CultureInfo.CurrentUICulture));
            }
            return Sdl.SDL_CDName(index);
        }

        #endregion Public methods
    }
}
