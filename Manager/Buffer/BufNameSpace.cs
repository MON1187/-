using Unity.VisualScripting;

public class BufNameSpace
{
    /// <summary>
    /// DeBuffer
    /// </summary>
    public const string down_str   = nameof(down_str);         //쇠약
    public const string down_hel   = nameof(down_hel);         //치유 감소
    public const string down_spd   = nameof(down_spd);         //감속
    public const string bleeding   = nameof(bleeding);         //출혈 
    public const string down_dmg   = nameof(down_dmg);         //피해약화
    public const string down_def   = nameof(down_def);         //방어력 약화

    public const string vulnerable = nameof(vulnerable);       //취약
    public const string poison     = nameof(poison);           //독
    public const string panic      = nameof(panic);            //패닉
    public const string disheveled = nameof(disheveled);       //흐트러짐
    public const string stiffness  = nameof(stiffness);        //경직
    public const string ChangePosition    = nameof(ChangePosition);      //경독

    /// <summary>
    /// Buffer
    /// </summary>
    public const string up_str = nameof(up_str);                //용기
    public const string up_spd = nameof(up_spd);                //신속
    public const string up_def = nameof(up_def);                //방어력 강화
    public const string up_dmg = nameof(up_dmg);                //피해 강화
    public const string up_hel = nameof(up_hel);                //흡수체질

    public const string sap             = nameof(sap);      //수액
    public const string imperishability = nameof(imperishability);  //불멸
    public const string rage            = nameof(rage);     //격노
}
