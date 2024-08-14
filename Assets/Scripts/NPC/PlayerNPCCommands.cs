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
            for (int i = 0; i < NPCs.Count; i++)
            {
                if (NPCs[i].GetState() < NPCState.Charging)  // NPC can be sent forward for an action
                {
                    NPCs[i].DirectNPC();
                    break;  // Only 1 NPC directed at a time, like launching Pikmin
                }
            }
        }
        else if (Input.GetButtonDown("Fire2"))
        {
            for (int i = 0; i < NPCs.Count; i++)
            {
                if (NPCs[i].GetState() > NPCState.Following)  // NPC can be called back
                {
                    Debug.Log("Directed NPC found");

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
