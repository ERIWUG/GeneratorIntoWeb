﻿using GeneratorIntoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorIntoWeb
{
    public static partial class Generator
    {
        /// <summary>
        /// Function that generate and print enum questions,  
        /// </summary>
        /// <param name="mas">array of data</param>
        /// <param name="ogr">integer that used in random (less number)</param>
        /// <param name="amount">integer represent amount of generated questions</param>
        /// <Author>Nichiporuk Viktor</Author>
        /// <summary>
        public static Question[] GenerateEnum(MyData[] mas, int ogr, int amount)
        {
            Random rand = new Random();
            List<int> intTrueAns = new List<int>();
            List<int> intFalseAns = new List<int>();
            List<int> intQuest = new List<int>();
            List<string> ans = new List<string>();
            Question[] questions = new Question[amount];
            int IndAnswer = 0;
            int l = 0;
            string AQQQQ = null;
            string MyHash = "DBNAME-G1-";
            String ANSW1 = "Все перечисленное.";
            String ANSW2 = "Ничего из перечисленного";
            void ParseData(MyData[] mas)
            {
                int i = -1;
                while (i++ < mas.Length - 1)
                {

                    if (mas[i].type == 1)
                    {
                        intQuest.Add(i);
                    }
                    else
                    {
                        if (mas[i].flag && mas[i].type == 2)
                        {
                            intTrueAns.Add(i);
                        }
                        if (!mas[i].flag && mas[i].type == 2)
                        {
                            intFalseAns.Add(i);
                        }
                    }
                }
            }

            void GenerateQuest1(List<int> a, List<int> b, int k)
            {
                ans.Clear();
                int i = a[rand.Next(a.Count)];
                ans.Add(mas[i].text);
                MyHash += $"{i}-";
                while (k-- > 0)
                {
                    int IA = rand.Next(b.Count);
                    var AA = mas[b[IA]];
                    ans.Add(AA.text);
                    MyHash += $"{b[IA]}-";
                    b.RemoveAt(IA);

                }
                ans.Add(ANSW1);
                ans.Add(ANSW2);
                MyHash += $"A1-";
                MyHash += $"A2-";
                questions[l] = new Question(AQQQQ, ans.ToArray(), IndAnswer, MyHash + IndAnswer);
                l++;
            }

            void GenerateQuest(List<int> a, List<int> b, int k)
            {
                int kk = k;
                List<String> ans2 = new List<String>();
                int allOrNo = rand.Next(3);
                if (allOrNo == 0)//если как обчно
                {
                    GenerateQuest1(a, b, k - 2);
                }
                else if (allOrNo == 1)//если все являются
                {
                    while (k-- > 1)
                    {
                        int IA = rand.Next(a.Count);
                        var AA = mas[a[IA]];

                        ans2.Add(AA.text);
                        MyHash += $"{a[IA]}-";
                        a.RemoveAt(IA);
                    }
                    ans2.Add(ANSW1);
                    ans2.Add(ANSW2);
                    MyHash += $"A1-";
                    MyHash += $"A2-";
                    questions[l] = new Question(AQQQQ, ans2.ToArray(), kk, MyHash + (kk));
                    l++;
                }
                else if (allOrNo == 2)//если все не являются
                {
                    while (k-- > 1)
                    {
                        int IA = rand.Next(b.Count);
                        var AA = mas[b[IA]];
                        ans2.Add(AA.text);
                        MyHash += $"{b[IA]}-";
                        b.RemoveAt(IA);
                    }
                    ans2.Add(ANSW1);
                    ans2.Add(ANSW2);
                    MyHash += $"A1-";
                    MyHash += $"A2-";
                    questions[l] = new Question(AQQQQ, ans2.ToArray(), kk + 1, MyHash + (kk + 1));
                    l++;
                }

            }

            ParseData(mas);

            while (amount-- > 0)
            {
                MyHash = "DBNAME-G1-";
                List<int> mT = intTrueAns.Slice(0, intTrueAns.Count);
                List<int> mF = intFalseAns.Slice(0, intFalseAns.Count);
                int k = rand.Next(4, ogr);
                int IQ = rand.Next(intQuest.Count);
                var AQ = mas[intQuest[IQ]];
                MyHash += $"{IQ}-{k + 1}-";
                AQQQQ = AQ.text;
                if (!AQ.flag)
                {
                    GenerateQuest(mF, mT, k);
                }
                else
                {
                    GenerateQuest(mT, mF, k);
                }

            }
            return questions;
        }



        /// <summary>
        /// Function that generate and print enum questions with probability
        /// </summary>
        /// <param name="mas">array of data</param>
        /// <param name="ogr">integer that used in random (less number)</param>
        /// <param name="amount">integer represent amount of generated questions</param>
        /// <Author>Nichiporuk Viktor</Author>
        public static Question[] GenerateEnum(MyDataWithProbability[] mas, int ogr, int amount)
        {
            Random rand = new Random();
            List<int> intTrueAns = new List<int>();
            List<int> intFalseAns = new List<int>();
            List<int> intQuest = new List<int>();
            List<string> ans = new List<string>();
            Question[] questions = new Question[amount];
            int IndAnswer = 0;
            int l = 0;
            string AQQQQ = null;
            string MyHash = "DBNAME-G1-";
            String ANSW1 = "Все перечисленное.";
            String ANSW2 = "Ничего из перечисленного";
            string myHash;

            void ParseData(MyData[] mas)
            {
                int i = -1;
                while (i++ < mas.Length - 1)
                {

                    if (mas[i].type == 1)
                    {
                        intQuest.Add(i);
                    }
                    else
                    {
                        if (mas[i].flag && mas[i].type == 2)
                        {
                            intTrueAns.Add(i);
                        }
                        if (!mas[i].flag && mas[i].type == 2)
                        {
                            intFalseAns.Add(i);
                        }
                    }
                }
            }

            void GenerateQuest1(List<int> a, List<int> b, int k)
            {
                int kk = k;
                ans.Clear();
                int i = a[rand.Next(a.Count)];
                ans.Add(mas[i].text);
                myHash += $"{i}-";
                List<int> appearedAnswers = new List<int>();
                int ca = 0;
                while (k-- > 0 && ca < k)
                {
                    if (b.Count == 0) break;
                    int IA = rand.Next(b.Count);
                    var AA = mas[b[IA]];
                    if (AA.probability != 1)
                    {
                        int c = (int)Math.Round(1 / AA.probability);
                        int rnd = rand.Next(c);
                        if (rnd == 1)
                        {
                            ca++;
                            appearedAnswers.Add(b[IA]);
                            ans.Add(AA.text);
                            myHash += $"{b[IA]}-";
                            b.RemoveAt(IA);
                        }
                        else k++;
                    }
                    else
                    {
                        ca++;
                        appearedAnswers.Add(b[IA]);
                        ans.Add(AA.text);
                        myHash += $"{b[IA]}-";
                        b.RemoveAt(IA);
                    }

                }
                ans.Add(ANSW1);
                ans.Add(ANSW2);
                myHash += $"A1-";
                myHash += $"A2-";
                questions[l] = new Question(AQQQQ, ans.ToArray(), IndAnswer, myHash + IndAnswer);
                l++;
            }

            void GenerateQuest(List<int> a, List<int> b, int k)
            {
                int kk = k;
                List<String> ans2 = new List<String>();
                int allOrNo = rand.Next(3);
                if (allOrNo == 0)//если как обчно
                {
                    GenerateQuest1(a, b, k - 1);
                }
                else if (allOrNo == 1)//если все являются
                {
                    List<int> appearedAnswers = new List<int>();
                    int ca = 0;
                    while (k-- > 1 && ca < k)
                    {
                        if (a.Count == 0) break;
                        int IA = rand.Next(a.Count);
                        var AA = mas[a[IA]];
                        if (AA.probability != 1)
                        {
                            int c = (int)Math.Round(1 / AA.probability);
                            int rnd = rand.Next(c);
                            if (rnd == 1)
                            {
                                ans2.Add(AA.text);
                                myHash += $"{a[IA]}-";
                                ca++;
                                appearedAnswers.Add(a[IA]);
                                a.RemoveAt(IA);
                            }
                            else k++;
                        }
                        else
                        {
                            ans2.Add(AA.text);
                            myHash += $"{a[IA]}-";
                            ca++;
                            appearedAnswers.Add(a[IA]);
                            a.RemoveAt(IA);
                        }


                    }
                    ans2.Add(ANSW1);

                    ans2.Add(ANSW2);
                    myHash += $"A1-";
                    myHash += $"A2-";
                    questions[l] = new Question(AQQQQ, ans2.ToArray(), kk - 3, myHash + (kk - 3));
                    l++;
                }
                else if (allOrNo == 2)//если все не являются
                {
                    int ca = 0;
                    while (k-- > 1 && ca < k)
                    {
                        if (b.Count == 0) break;
                        int IA = rand.Next(b.Count);
                        var AA = mas[b[IA]];
                        if (AA.probability != 1)
                        {
                            int c = (int)Math.Round(1 / AA.probability);
                            int rnd = rand.Next(c);
                            if (rnd == 1)
                            {
                                ca++;
                                ans2.Add(AA.text);
                                myHash += $"{b[IA]}-";
                                b.RemoveAt(IA);
                            }
                            else k++;
                        }
                        else
                        {
                            ca++;
                            ans2.Add(AA.text);
                            myHash += $"{b[IA]}-";
                            b.RemoveAt(IA);
                        }



                    }
                    ans2.Add(ANSW1);
                    ans2.Add(ANSW2);
                    myHash += $"A1-";
                    myHash += $"A2-";
                    questions[l] = new Question(AQQQQ, ans2.ToArray(), kk - 2, myHash + (kk - 2));
                    l++;
                }

            }

            ParseData(mas);

            while (amount-- > 0)
            {
                myHash = MyHash;
                List<int> mT = intTrueAns.Slice(0, intTrueAns.Count);
                List<int> mF = intFalseAns.Slice(0, intFalseAns.Count);
                int k = rand.Next(3, ogr);
                int IQ = rand.Next(intQuest.Count);
                var AQ = mas[intQuest[IQ]];
                AQQQQ = AQ.text;
                myHash += $"{IQ}-{k + 1}-";
                if (!AQ.flag)
                {
                    GenerateQuest(mF, mT, k + 2);
                }
                else
                {
                    GenerateQuest(mT, mF, k + 2);
                }

            }
            return questions;
        }
    }
}