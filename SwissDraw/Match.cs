using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwissDraw
{
    public class Match
    {
        private int person1;
        private int person2;
        
        private int result;// result 1:Person1の勝ち　2:Person2の勝ち　0:決着がついていない　他:エラー

        public int Person1 { get => person1; set => person1 = value; }
        public int Person2 { get => person2; set => person2 = value; }
        public int Result { get => result; set => result = value; }

        public Match(int i,int j)
        {
            person1 = i;//1
            person2 = j;//10
            result = 0;
        }

        public static Match[] MakeMatch(Dictionary<int, Person> persons, Match[] results)//1 くじ番号をkeyに,personをvalueに設定したdictionary 2 今までの対戦が格納されたmatchの配列
                                       //くじ番号 人の情報 
        {
            /*
            int count_person = persons.Count;//人数

            var sorted = persons.OrderBy((x) => x.Key); //昇順
            */
            
            // personsのkeyのみ取り出す くじ
            int[] keys = GetKeyArray(persons); //1 3 5 8 10 30

            // 配列を初期化する
            int matchCount = keys.Length / 2;
            //                                        ↑
            Match[] matches = MakeMatch1(matchCount, keys, results);
                                         　//3               //0
            return matches;
        }

        // 「対戦していない」「同じチームじゃない」「勝ち数が同じ」で対戦
        public static Match[] MakeMatch1(int matchCount, int[] keys, Match[] results)
        {                                     //3        1 3 5 8 10 30         0
            Match[] matches = new Match[matchCount];

            for (int i = 0; i < matchCount; i++)
            {
                // 最小のくじ番号を取得する(使われていないこと)
                int minKey = getMinimumKey(keys, matches);

                // 対応する対戦相手のくじ番号を取得する（使われていない、対戦していない、同じチームじゃない、勝ち数が同じ）
                int versusKey = getVersusKey1(minKey, keys, matches, results);
                                              //1  1 3 5 8 10 30  3[]     0

                // versusKey < 0なら、対戦相手は見つからなかったため、nullを返す
                if (versusKey < 0)
                {
                    return null;
                }

                //条件をゆるくして対戦相手を探す

                //対戦を保存する
                matches[i] = new Match(minKey, versusKey);
            }
            return matches;
        }

        // personsのkeyを取り出して配列にする
        public static int[] GetKeyArray(Dictionary<int, Person> persons)
        {
            return persons.Keys.ToArray();
        }

        // 最小のくじ番号を取得する(使われていないこと)
        private static int getMinimumKey(int[] keys, Match[] matches)
        {
            throw new NotImplementedException();
        }

        // 対応する対戦相手のくじ番号を取得する
        //（使われていない、対戦していない、同じチームじゃない、勝ち数が同じ）
        private static int getVersusKey1(int minKey, int[] keys, Match[] matches, Match[] results)
                                             //1    1 3 5 8 10 30          3[]              0
        {
            int getVersus = 0;
            int min = minKey;
            int[] Lots = keys;

            //勝ち数計算メソッド呼び出し



            return getVersus;
        }
        //（使われていない、対戦していない勝ち数が同じ）
        private static int getVersusKey2(int minKey, int[] keys, Match[] matches, Match[] results)
        {
            throw new NotImplementedException();
        }
        //（使われていない、対戦していない）
        private static int getVersusKey3(int minKey, int[] keys, Match[] matches, Match[] results)
        {
            throw new NotImplementedException();
        }

        //マージ
        public static Match[] MergeMatch(Match[] results1, Match[] results2)//1 今までの対戦が格納されたmatchの配列 2 今回の対戦が格納されたmatchの配列
        {
            return results1; //第一引数に第二引数を結合させたmatchの配列
        }

    }

}
