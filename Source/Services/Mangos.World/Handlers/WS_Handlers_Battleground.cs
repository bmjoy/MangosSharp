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

using System.Collections.Generic;
using Mangos.Common.Enums.Global;
using Mangos.Common.Enums.Unit;
using Mangos.Common.Globals;
using Mangos.World.Globals;
using Mangos.World.Server;

namespace Mangos.World.Handlers
{
    public class WS_Handlers_Battleground
    {
        public void On_CMSG_BATTLEMASTER_HELLO(ref Packets.PacketClass packet, ref WS_Network.ClientClass client)
        {
            if (packet.Data.Length - 1 < 13)
                return;
            packet.GetInt16();
            ulong GUID = packet.GetUInt64();
            WorldServiceLocator._WorldServer.Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_BATTLEMASTER_HELLO [{2:X}]", client.IP, client.Port, GUID);
            if (WorldServiceLocator._WorldServer.WORLD_CREATUREs.ContainsKey(GUID) == false)
                return;
            if ((WorldServiceLocator._WorldServer.WORLD_CREATUREs[GUID].CreatureInfo.cNpcFlags & NPCFlags.UNIT_NPC_FLAG_BATTLEFIELDPERSON) == 0)
                return;
            if (WorldServiceLocator._WS_DBCDatabase.Battlemasters.ContainsKey(WorldServiceLocator._WorldServer.WORLD_CREATUREs[GUID].ID) == false)
                return;
            byte BGType = WorldServiceLocator._WS_DBCDatabase.Battlemasters[WorldServiceLocator._WorldServer.WORLD_CREATUREs[GUID].ID];
            if (WorldServiceLocator._WS_DBCDatabase.Battlegrounds.ContainsKey(BGType) == false)
                return;
            if (WorldServiceLocator._WS_DBCDatabase.Battlegrounds[BGType].MinLevel > client.Character.Level || WorldServiceLocator._WS_DBCDatabase.Battlegrounds[BGType].MaxLevel < client.Character.Level)
            {
                WorldServiceLocator._Functions.SendMessageNotification(ref client, "You don't meet Battleground level requirements");
                return;
            }

            // DONE: Send list
            var response = new Packets.PacketClass(OPCODES.SMSG_BATTLEFIELD_LIST);
            try
            {
                response.AddUInt64(client.Character.GUID);
                response.AddInt32(BGType);

                // If BGType = 6 Then          'Arenas
                // response.AddInt8(5)     'Unk
                // response.AddInt32(0)    'Unk
                // Else
                List<int> Battlegrounds = WorldServiceLocator._WorldServer.ClsWorldServer.Cluster.BattlefieldList(BGType);
                response.AddInt8(0);                     // Unk
                response.AddInt32(Battlegrounds.Count);  // Number of BG Instances
                foreach (int Instance in Battlegrounds)
                    response.AddInt32(Instance);
                // End If

                client.Send(ref response);
            }
            finally
            {
                response.Dispose();
            }
        }

        public void On_MSG_BATTLEGROUND_PLAYER_POSITIONS(ref Packets.PacketClass packet, ref WS_Network.ClientClass client) // Not finished yet.. long ways to go!
        {
            packet.GetUInt32();
        }

        // Not Implement:
        // MSG_BATTLEGROUND_PLAYER_POSITIONS
        // MSG_PVP_LOG_DATA
        // CMSG_AREA_SPIRIT_HEALER_QUERY
        // CMSG_AREA_SPIRIT_HEALER_QUEUE
        // CMSG_REPORT_PVP_AFK

    }
}