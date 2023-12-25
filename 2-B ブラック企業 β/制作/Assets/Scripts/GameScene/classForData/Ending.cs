using System;
using System.Collections.Generic;

[System.Serializable]
public class Ending
{
    public int id;
    public string name;
    public string[] description;
    public bool cleared;
    public string hint;

    public Ending(int id = 0, string name = "“ä‚ÌA•¨", string[] description = null, bool cleared = false, string hint = "") {
        this.id = id;
        this.name = name;
        this.description = description;
        if(this.description == null)
            this.description = new string[]{"–ó‚Ì•ª‚©‚ç‚È‚¢‹¥–\‚ÈA•¨‚Å‚ ‚é", "GH", "¶‘ÔŒnƒsƒ‰ƒ~ƒbƒh‚Ì’¸“_‚ğŒN—Õ‚·‚é", "‚â‚ª‚Äl—Ş‚ğ‚àH‚×s‚­‚µ‚½‚Ì‚Å‚ ‚Á‚½"};
        this.cleared = cleared;
    }
}

[System.Serializable]
public class EndingList {
    public List<Ending> endings;

    public EndingList() {
        endings = new List<Ending>();
    }
}
