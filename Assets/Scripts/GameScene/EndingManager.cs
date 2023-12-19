public class EndingManager
{
    // エンディング情報リスト(仮)、後々外部ファイルに保存するかも
    public static EndingList endingList;
    public static Ending chooseEnding(Chara chara, Action[] actions)
    {
        Ending result = new Ending();
        // actions: 0:投げつけ　1:勉強　2:話しかけ　3:外出 4:投薬　5:水やり

        // 全振り系
        // 筋力
        if (checkOnlyAction(actions, 0, true))
        {
            result = endingList.endings[12];
            result.cleared = true;
            return result;
        }
        // 知力
        if (checkOnlyAction(actions, 1, true))
        {
            result = endingList.endings[13];
            result.cleared = true;
            return result;
        }
        // メンタル
        if (checkOnlyAction(actions, 2, true))
        {
            result = endingList.endings[14];
            result.cleared = true;
            return result;
        }
        // お出かけ
        if (checkOnlyAction(actions, 3, false))
        {
            result = endingList.endings[18];
            result.cleared = true;
            return result;
        }
        // 投薬
        if (checkOnlyAction(actions, 4, true))
        {
            if (chara.getHp() >= 50)    // HP高い
            {
                result = endingList.endings[15];
                result.cleared = true;
                return result;
            }
            else    // HP低い
            {
                result = endingList.endings[16];
                result.cleared = true;
                return result;
            }
        }

        // MAX系
        // 全MAX
        if (chara.getMaxPower() == chara.getMaxPower() &&
            chara.getIntelligent() == chara.getMaxIntelligent() &&
            chara.getMental() == chara.getMaxMental())
        {
            result = endingList.endings[19];
            result.cleared = true;
            return result;
        }
        // 筋力MAX
        if (chara.getPower() == chara.getMaxPower())
        {
            result = endingList.endings[2];
            result.cleared = true;
            return result;
        }
        // 知力MAX
        if (chara.getIntelligent() == chara.getMaxIntelligent())
        {
            result = endingList.endings[5];
            result.cleared = true;
            return result;
        }
        // メンタルMAX
        if (chara.getMental() == chara.getMaxMental())
        {
            result = endingList.endings[8];
            result.cleared = true;
            return result;
        }
        // 好感度MAX
        if (chara.getFriendly() == chara.getMaxFriendly())
        {
            result = endingList.endings[9];
            result.cleared = true;
            return result;
        }

        // Min系
        // HP min
        if (chara.getHp() == 0)
        {
            result = endingList.endings[17];
            result.cleared = true;
            return result;
        }
        // 好感度min
        if (chara.getFriendly() == chara.getMinFriendly())
        {
            result = endingList.endings[10];
            result.cleared = true;
            return result;
        }

        // 特殊枠
        // 全ステータス同じ
        if (chara.getPower() == chara.getIntelligent() && chara.getPower() == chara.getMental())
        {
            result = endingList.endings[11];
            result.cleared = true;
            return result;
        }

        // 比較系
        // 筋力
        if (chara.getPower() >= chara.getIntelligent() && chara.getPower() >= chara.getMental())
        {
            if (chara.getFriendly() >= 50)      // 好感度判定
            {
                result = endingList.endings[0];
                result.cleared = true;
                return result;
            }
            else
            {
                result = endingList.endings[1];
                result.cleared = true;
                return result;
            }
        }
        // 知力
        if (chara.getIntelligent() >= chara.getPower() && chara.getIntelligent() >= chara.getMental())
        {
            if (chara.getFriendly() >= 50)
            {
                result = endingList.endings[3];
                result.cleared = true;
                return result;
            }
            else
            {
                result = endingList.endings[4];
                result.cleared = true;
                return result;
            }
        }
        // メンタル
        if (chara.getMental() >= chara.getPower() && chara.getMental() >= chara.getPower())
        {
            if (chara.getFriendly() >= 50)
            {
                result = endingList.endings[6];
                result.cleared = true;
                return result;
            }
            else
            {
                result = endingList.endings[7];
                result.cleared = true;
                return result;
            }
        }

        return result;
    }

    // エンディングリストの代入(GameDirectorのファイル読み込みの部分に実行)
    public static void setEngindList(EndingList endings)
    {
        endingList = endings;
    }

    // クリアエンディング情報を外部ファイルに保存
    public static void saveEndingList()
    {
        EndingIO.saveEnding(endingList);
    }

    // 全振りチェック（水やりOKかという条件付き）
    static bool checkOnlyAction(Action[] actions, int onlyActionId, bool ignoreWater)
    {
        bool result = true;
        // 水やりが許容なら水やりをチェックしない
        int checkUntil = ignoreWater ? actions.Length - 1 : actions.Length;
        for (int i = 0; i < checkUntil; ++i)
        {
            if (i == onlyActionId)  // チェックしたいid時
                if (actions[i].times > 0) continue;
                else return false;  // 水やりしかした場合に対応するため
            if (actions[i].times > 0) return false;
        }
        return result;
    }
}
