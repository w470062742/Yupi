﻿using Yupi.Emulator.Messages;


namespace Yupi.Emulator.Game.Pets.Composers
{
     public class RespectPetNotificationComposer
    {
     public static void GenerateMessage(Pet pet)
        {
            SimpleServerMessageBuffer simpleServerMessageBuffer = new SimpleServerMessageBuffer(PacketLibraryManager.OutgoingHandler("PetRespectNotificationMessageComposer"));
            simpleServerMessageBuffer.AppendInteger(1);
            simpleServerMessageBuffer.AppendInteger(pet.VirtualId);
            pet.SerializeInventory(simpleServerMessageBuffer);
            pet.Room.SendMessage(simpleServerMessageBuffer);
        }
    }
}