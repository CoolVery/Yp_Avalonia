using REG_MARK_LIB;

namespace TestREG_MARK_LIB
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void TestEasy_FirstAutoNumber_CheckMark_IsTrue()
        {
            REG_MARK_LIB_CLASS markLibClass = new REG_MARK_LIB_CLASS();
            bool result = markLibClass.CheckMark("a321be32");
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestEasy_SecondAutoNumber_CheckMark_IsTrue()
        {
            REG_MARK_LIB_CLASS markLibClass = new REG_MARK_LIB_CLASS();
            bool result = markLibClass.CheckMark("a000aa159");
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestEasy_ThirtAutoNumber_CheckMark_IsTrue()
        {
            REG_MARK_LIB_CLASS markLibClass = new REG_MARK_LIB_CLASS();
            bool result = markLibClass.CheckMark("x999xx196");
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestEasy_FirstAutoNumber_GetNextMarkAfter_AreEqual()
        {
            REG_MARK_LIB_CLASS markLibClass = new REG_MARK_LIB_CLASS();
            string result = markLibClass.GetNextMarkAfter("x999xx196");
            string exprcted = "a000aa196";
            Assert.AreEqual(exprcted, result);
        }
        [TestMethod]
        public void TestEasy_SecondAutoNumber_GetNextMarkAfter_AreEqual()
        {
            REG_MARK_LIB_CLASS markLibClass = new REG_MARK_LIB_CLASS();
            string result = markLibClass.GetNextMarkAfter("a000mh19");
            string exprcted = "a001mh19";
            Assert.AreEqual(exprcted, result);
        }
        [TestMethod]
        public void TestEasy_FitstAutoNumber_GetNextMarkAfterInRange_AreEqual()
        {
            REG_MARK_LIB_CLASS markLibClass = new REG_MARK_LIB_CLASS();
            string result = markLibClass.GetNextMarkAfterInRange("a050aa19", "a000aa19", "a100aa19");
            string exprcted = "a051aa19";
            Assert.AreEqual(exprcted, result);
        }
        [TestMethod]
        public void TestEasy_SecondAutoNumber_GetNextMarkAfterInRange_AreEqual()
        {
            REG_MARK_LIB_CLASS markLibClass = new REG_MARK_LIB_CLASS();
            string result = markLibClass.GetNextMarkAfterInRange("m050ty19", "e999mk19", "x999aa19");
            string exprcted = "m051ty19";
            Assert.AreEqual(exprcted, result);
        }
        [TestMethod]
        public void TestEasy_FirstAutoNumber_GetCombinationsCountInRange_AreEqual()
        {
            REG_MARK_LIB_CLASS markLibClass = new REG_MARK_LIB_CLASS();
            int result = markLibClass.GetCombinationsCountInRange("a000aa19", "a999aa19");
            int exprcted = 999;
            Assert.AreEqual(exprcted, result);
        }
        [TestMethod]
        public void TestEasy_SecondAutoNumber_GetCombinationsCountInRange_AreEqual()
        {
            REG_MARK_LIB_CLASS markLibClass = new REG_MARK_LIB_CLASS();
            int result = markLibClass.GetCombinationsCountInRange("с000ab19", "c000am19");
            int exprcted = 39960;
            Assert.AreEqual(exprcted, result);
        }
        [TestMethod]
        public void TestEasy_ThirdAutoNumber_GetCombinationsCountInRange_AreEqual()
        {
            REG_MARK_LIB_CLASS markLibClass = new REG_MARK_LIB_CLASS();
            int result = markLibClass.GetCombinationsCountInRange("b050bb19", "a100aa19");
            int exprcted = 8392;
            Assert.AreEqual(exprcted, result);
        }
        [TestMethod]
        public void TestHard_FirstAutoNumber_CheckMark_IsFalse()
        {
            REG_MARK_LIB_CLASS markLibClass = new REG_MARK_LIB_CLASS();
            bool result = markLibClass.CheckMark("z050bb19");
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestHard_SecondAutoNumber_CheckMark_IsFalse()
        {
            REG_MARK_LIB_CLASS markLibClass = new REG_MARK_LIB_CLASS();
            bool result = markLibClass.CheckMark("b050bb999");
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestHard_ThirdAutoNumber_CheckMark_IsFalse()
        {
            REG_MARK_LIB_CLASS markLibClass = new REG_MARK_LIB_CLASS();
            bool result = markLibClass.CheckMark("b050bb103");
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestHard_FirstAutoNumber_GetNextMarkAfterInRange_AreEqualOutOfStock()
        {
            REG_MARK_LIB_CLASS markLibClass = new REG_MARK_LIB_CLASS();
            string result = markLibClass.GetNextMarkAfterInRange("a050aa19", "a051aa19", "a060aa19");
            string expected = "out of stock";
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestHard_SecondAutoNumber_GetNextMarkAfterInRange_AreEqualOutOfStock()
        {
            REG_MARK_LIB_CLASS markLibClass = new REG_MARK_LIB_CLASS();
            string result = markLibClass.GetNextMarkAfterInRange("a050aa19", "b040aa19", "c060aa19");
            string expected = "out of stock";
            Assert.AreEqual(expected, result);
        }
    }
}
