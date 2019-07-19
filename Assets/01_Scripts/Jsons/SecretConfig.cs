using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Secret {
    /// <summary>
    /// 角色类型
    /// </summary>
    public string type { get; set; }
    /// <summary>
    /// 技能类型
    /// </summary>
    public List<Skill> skill { get; set; }
}

public class Skill
{
    /// <summary>
    /// 秘籍id
    /// </summary>
    public string id { get; set; }
    /// <summary>
    /// 秘籍名称
    /// </summary>
    public string name { get; set; }
    /// <summary>
    /// 秘籍描述
    /// </summary>
    public string desc { get; set; }
}


public class Root
{
    public List<Secret> secretData { get; set; }
}
