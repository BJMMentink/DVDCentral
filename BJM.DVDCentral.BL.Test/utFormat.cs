namespace BJM.DVDCentral.BL.Test
{
    [TestClass]
    public class utFormat
    {
        [TestMethod]
        public void LoadTest()
        {
            Assert.AreEqual(4, FormatManager.Load().Count);
        }
        [TestMethod]
        public void InsertTest()
        {
            Format format = new Format
            {
                Description = "Test"
            };

            int results = FormatManager.Insert(format, true);
            Assert.AreEqual(1, results);
        }

        [TestMethod]
        public void UpdateTest()
        {
            Format format = FormatManager.LoadById(3);
            format.Description = "Test";
            int results = FormatManager.Update(format, true);
            Assert.AreEqual(1, results);
        }

        [TestMethod]
        public void DeleteTest()
        {
            int results = FormatManager.Delete(3, true);
            Assert.AreEqual(1, results);
        }
    }
}