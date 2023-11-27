public class EndingManager
{
    // エンディング情報リスト(仮)、後々外部ファイルに保存するかも
    public static Ending[] endingList = { new Ending(1, "天才サボテン君", new string[] { "IQ200のサボテン君。","いつか世界に名を馳せるかも。" }, false) };
    public static Ending chooseEnding(Chara chara) {
        Ending result = new Ending();
        // 仮の条件（元々は知力MAX） α版では動作確認のため仮の数値でテストします
        if(chara.getIntelligent() >= 200)     // >= chara.getMaxIntelligent())
            result = endingList[0];
        result.cleared = true;
        return result;
    }
}
