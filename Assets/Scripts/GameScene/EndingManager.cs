public class EndingManager
{
    // エンディング情報リスト(仮)、後々外部ファイルに保存するかも
    public static EndingList endingList;
    public static Ending chooseEnding(Chara chara, Action[] actions) {
        Ending result = new Ending();

        if (chara.getMaxPower() == chara.getMaxPower() && 
            chara.getIntelligent() == chara.getMaxIntelligent() &&
            chara.getMental() == chara.getMaxMental()) {
            result = endingList.endings[19];
            result.cleared = true;
            return result;
        }
        if (chara.getPower() == chara.getMaxPower()) {
            result = endingList.endings[2];
            result.cleared = true;
            return result;
        }
        if (chara.getIntelligent() == chara.getMaxIntelligent()) {
            result = endingList.endings[5];
            result.cleared = true;
            return result;
        }
        if (chara.getMental() == chara.getMaxMental()) {
            result = endingList.endings[8];
            result.cleared = true;
            return result;
        }
        if (chara.getFriendly() == chara.getMaxFriendly()) {
            result = endingList.endings[9];
            result.cleared = true;
            return result;
        }
        if (chara.getHp() == 0) {
            result = endingList.endings[17];
            result.cleared = true;
            return result;
        }
        if (chara.getFriendly() == chara.getMinFriendly()) {
            result = endingList.endings[10];
            result.cleared = true;
            return result;
        }
        if (chara.getPower() == chara.getIntelligent() && chara.getPower() == chara.getMental()) {
            result = endingList.endings[11];
            result.cleared = true;
            return result;
        }
        if (actions[0].times >= 20) {
            result = endingList.endings[12];
            result.cleared = true;
            return result;
        }
        if (actions[1].times >= 20) {
            result = endingList.endings[13];
            result.cleared = true;
            return result;
        }
        if (actions[2].times >= 20) {
            result = endingList.endings[14];
            result.cleared = true;
            return result;
        }
        if (actions[3].times >= 20) {
            result = endingList.endings[18];
            result.cleared = true;
            return result;
        }
        if (actions[4].times >= 20) {
            if (chara.getHp() >= 50)
            {
                result = endingList.endings[15];
                result.cleared = true;
                return result;
            }
            else {
                result = endingList.endings[16];
                result.cleared = true;
                return result;
            }
        }
        if (chara.getPower() >= chara.getIntelligent() && chara.getPower() >= chara.getMental()) {
            if (chara.getFriendly() >= 50)
            {
                result = endingList.endings[0];
                result.cleared = true;
                return result;
            }
            else {
                result = endingList.endings[1];
                result.cleared = true;
                return result;
            }
        }
        if (chara.getIntelligent() >= chara.getPower() && chara.getIntelligent() >= chara.getMental()) {
            if (chara.getFriendly() >= 50)
            {
                result = endingList.endings[3];
                result.cleared = true;
                return result;
            }
            else {
                result = endingList.endings[4];
                result.cleared = true;
                return result;
            }
        }
        if (chara.getMental() >= chara.getPower() && chara.getMental() >= chara.getPower()) {
            if (chara.getFriendly() >= 50) {
                result = endingList.endings[6];
                result.cleared = true;
                return result;
            }
            else {
                result = endingList.endings[7];
                result.cleared = true;
                return result;
            }
        }

        return result;
    }

    public static void setEngindList(EndingList endings) {
        endingList = endings;
    }
}
