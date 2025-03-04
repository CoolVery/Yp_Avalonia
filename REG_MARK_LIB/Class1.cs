namespace REG_MARK_LIB
{
    public class REG_MARK_LIB
    {
        List<char> correctSymbols = new List<char>() { 'A', 'B', 'E', 'K', 'M', 'H', 'O', 'P', 'C', 'T', 'Y', 'X'};
        List<int> correctNumRegion = new List<int>() { 102, 113, 116, 716, 121, 123, 124, 125, 134, 150, 190, 750, 790, 152, 154, 159, 161, 163, 164, 196, 173, 174, 177, 197, 199, 777, 799, 186 };
        public bool CheckMark(string mark)
        {
            switch (correctSymbols.Contains(mark[0]) && correctSymbols.Contains(mark[4]) && correctSymbols.Contains(mark[5]))
            {
                case false:
                    return false;
            }
            int numRegion = 0;
            switch (mark.Length)
            {
                case 9:
                    numRegion = Convert.ToInt32(mark[7] + mark[8] + mark[9]);
                    break;
                case 8:
                    numRegion = Convert.ToInt32(mark[8] + mark[9]);
                    break;
            }
            if (0 < numRegion && numRegion < 100)
            {
                return true;
            }
            if (correctNumRegion.Contains(numRegion))
            {
                return true;
            }
            return false;
        }
        string GetNextMarkAfter(string mark)
        {
            string resultNum = string.Copy(mark);
            int numberMark = Convert.ToInt32(mark[1..3]);
            if (numberMark != 999)
            {
                string numberMarkStr = numberMark++.ToString();
                resultNum.Replace(resultNum[1], numberMarkStr[0]);
                resultNum.Replace(resultNum[2], numberMarkStr[1]);
                resultNum.Replace(resultNum[3], numberMarkStr[2]);
                return resultNum;
            }
            else
            {
                resultNum.Replace(resultNum[1], '0');
                resultNum.Replace(resultNum[2], '0');
                resultNum.Replace(resultNum[3], '0');
                int countEndSymbol = resultNum.Count(x => x == 'X');
                if (countEndSymbol == 3)
                {
                    resultNum.Replace(resultNum[0], 'A');
                    resultNum.Replace(resultNum[4], 'A');
                    resultNum.Replace(resultNum[5], 'A');
                    return resultNum;
                }
                else if (countEndSymbol == 2)
                {
                    int indexFirstLastSymbol = resultNum.IndexOf('X');
                    int indexSecondLastSymbol = resultNum.LastIndexOf('X');
                    if (indexFirstLastSymbol == 0 && indexSecondLastSymbol == 4)
                    {
                        int indexInList = correctSymbols.IndexOf(resultNum[5]);
                        resultNum.Replace(resultNum[5], correctSymbols[indexInList++]);
                        return resultNum;
                    }
                    else if (indexFirstLastSymbol == 0 && indexSecondLastSymbol == 5)
                    {
                        int indexInList = correctSymbols.IndexOf(resultNum[4]);
                        resultNum.Replace(resultNum[4], correctSymbols[indexInList++]);
                        return resultNum;
                    }
                    else
                    {
                        int indexInList = correctSymbols.IndexOf(resultNum[0]);
                        resultNum.Replace(resultNum[0], correctSymbols[indexInList++]);
                        return resultNum;
                    }
                }
                else
                {
                    switch(resultNum.IndexOf('X'))
                    {
                        case 0:
                            int indexInList = correctSymbols.IndexOf(resultNum[5]);
                            resultNum.Replace(resultNum[5], correctSymbols[indexInList++]);
                            return resultNum;
                        case 4:
                            indexInList = correctSymbols.IndexOf(resultNum[5]);
                            resultNum.Replace(resultNum[5], correctSymbols[indexInList++]);
                            return resultNum;
                        case 5:
                            indexInList = correctSymbols.IndexOf(resultNum[4]);
                            resultNum.Replace(resultNum[4], correctSymbols[indexInList++]);
                            resultNum.Replace(resultNum[5], 'A');
                            return resultNum;
                    }
                }
            }
            return resultNum;
        }
        //string GetNextMarkAfterInRange(string prevMark, string rangeStart, string rangeEnd)
        //{
        //    int numberMark = Convert.ToInt32(prevMark[1..3]);
        //    if (numberMark < Convert.ToInt32(rangeStart[1..3]) || numberMark > Convert.ToInt32(rangeEnd[1..3]))
        //    {
        //        return "out of stock";
        //    }
        //    else if (numberMark == 999)
        //    {

        //    }
        //}
        //int GetCombinationsCountInRange(string mark1, string mark2)
        //{

        //}

    }
}
