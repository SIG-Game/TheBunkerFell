using UnityEngine;
using System.Collections.Generic;

public class PlayerNPCCommands : MonoBehaviour
{
    private List<NPCMovement> NPCs;

    private void Start()
    {
        NPCs = new List<NPCMovement>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            NPCMovement directableNPC = NPCs.Find(x => x.GetState() < NPCState.Charging);  // an NPC can be sent forward for an action
            directableNPC?.DirectNPC();
        }
        else if (Input.GetButtonDown("Fire2"))
        {
            for (int i = 0; i < NPCs.Count; i++)
            {
                if (NPCs[i].GetState() > NPCState.Following)  // NPC can be called back
                {
                    NPCs[i].CallNPC();
                }
            }
        }
    }

    public void AddNPC(NPCMovement _npc)  // Player found NPC to control
    {
        NPCs.Add(_npc);
    }

    public void RemoveNPC(NPCMovement _npc)  // Player lost control of NPC
    {
        NPCs.Remove(_npc);
    }
}
