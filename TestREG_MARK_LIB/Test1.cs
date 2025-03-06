using REG_MARK_LIB;

namespace TestREG_MARK_LIB
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void Test_FirstAutoNumber_CheckMark_IsTrue()
        {
            REG_MARK_LIB_CLASS markLibClass = new REG_MARK_LIB_CLASS();
            bool result = markLibClass.CheckMark("a321be32");
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void Test_SecondAutoNumber_CheckMark_IsTrue()
        {
            REG_MARK_LIB_CLASS markLibClass = new REG_MARK_LIB_CLASS();
            bool result = markLibClass.CheckMark("a000aa159");
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void Test_ThirtAutoNumber_CheckMark_IsTrue()
        {
            REG_MARK_LIB_CLASS markLibClass = new REG_MARK_LIB_CLASS();
            bool result = markLibClass.CheckMark("x999xx196");
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void Test_FirstAutoNumber_GetNextMarkAfter_AreEqual()
        {
            REG_MARK_LIB_CLASS markLibClass = new REG_MARK_LIB_CLASS();
            string result = markLibClass.GetNextMarkAfter("x999xx196");
            string exprcted = "a000aa196";
            Assert.AreEqual(exprcted, result);
        }
        [TestMethod]
        public void Test_SecondAutoNumber_GetNextMarkAfter_AreEqual()
        {
            REG_MARK_LIB_CLASS markLibClass = new REG_MARK_LIB_CLASS();
            string result = markLibClass.GetNextMarkAfter("a000mh19");
            string exprcted = "a001mh19";
            Assert.AreEqual(exprcted, result);
        }
        [TestMethod]
        public void Test_FitstAutoNumber_GetNextMarkAfterInRange_AreEqual()
        {
            REG_MARK_LIB_CLASS markLibClass = new REG_MARK_LIB_CLASS();
            string result = markLibClass.GetNextMarkAfterInRange("a050aa19", "a000aa19", "a100aa19");
            string exprcted = "a051aa19";
            Assert.AreEqual(exprcted, result);
        }
        [TestMethod]
        public void Test_SecondAutoNumber_GetNextMarkAfterInRange_AreEqual()
        {
            REG_MARK_LIB_CLASS markLibClass = new REG_MARK_LIB_CLASS();
            string result = markLibClass.GetNextMarkAfterInRange("m050ty19", "e999mk19", "x999aa19");
            string exprcted = "m051ty19";
            Assert.AreEqual(exprcted, result);
        }
    }
}
