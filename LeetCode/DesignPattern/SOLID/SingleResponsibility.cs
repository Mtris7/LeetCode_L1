﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LeetCode
{
    //Every software module should have only one responsibility
    public class SingleResponsibility
    {
        private readonly List<string> entries = new List<string>();
        private static int count = 0;
        public int AddEntry(string text)
        {
            entries.Add($"{++count} : {text}");
            return count;
        }
        public void RemoveEntry(int index)
        {
            entries.RemoveAt(index);
        }
        public override string ToString()
        {
            return string.Join(Environment.NewLine, entries);
        }
    }
    public class SingleResponsibilityAssist
    {
        public void SaveFile(SingleResponsibility s , string FileName, bool overwrite = false)
        { }
    }
}
