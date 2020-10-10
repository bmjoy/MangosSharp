﻿// 
// Copyright (C) 2013-2020 getMaNGOS <https://getmangos.eu>
// 
// This program is free software. You can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation. either version 2 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY. Without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program. If not, write to the Free Software
// Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
// 

using System;
using Mangos.Common.Enums.Misc;

namespace Mangos.World.Handlers
{
    [AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = true)]
    public class ChatCommandAttribute : Attribute
    {
        public ChatCommandAttribute(string cmdName, string cmdHelp = "No information available.", AccessLevel cmdAccess = AccessLevel.GameMaster)
        {
            this.cmdName = cmdName;
            this.cmdHelp = cmdHelp;
            this.cmdAccess = cmdAccess;
        }

        public string cmdName { get; set; } = "";
        public string cmdHelp { get; set; } = "No information available.";
        public AccessLevel cmdAccess { get; set; } = AccessLevel.GameMaster;
    }
}