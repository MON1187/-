using static BufNameSpace;
public class ManagerBuf
{
    /// <summary>
    /// This is the buff(id), strength, and time to be given to the target.
    /// </summary>
    /// <param name="targetBody"></param>
    /// <param name="id"></param>
    /// <param name="value"></param>
    /// <param name="time"></param>
    /// <returns></returns>
    public static StatusEffect GetBuf(GetBufBody targetBody, string id, int value,float time)
    {
        switch(id)
        {
            //Buufer
            case up_str:
                return new AttackBuffer(time, targetBody.gameObject, value);
            case up_def:
                return new DefenseBuffer(time, targetBody.gameObject, value);
            case rage:
                return new BufferController.Rage(time, targetBody.gameObject, value,3);


            //Debuffer
            case down_str:      //¼è¾à
                return new AttackDebuffer(time, targetBody.gameObject, value);
            case vulnerable:    //Ãë¾à
                return new VulnerableDebuffer(time, targetBody.gameObject, value);
            case down_spd:
                return new DebufferController.LowSpeed(time, targetBody.gameObject, value);
            default:
            return default;
        }
    }
}

