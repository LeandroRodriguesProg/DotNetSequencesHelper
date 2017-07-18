using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sequences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sequences.Tests
{
    [TestClass()]
    public class SequencesHelperTests
    {
        #region SortAndCheckAllValuesAreSequential
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AllValuesInSequence_NullValues()
        {
            SequencesHelper.SortAndCheckAllValuesAreSequential(null);
        }

        [TestMethod()]
        public void AllValuesInSequence_AllInSequence()
        {
            List<int> values = new List<int>();
            values.Add(1);
            values.Add(2);
            values.Add(3);
            values.Add(4);
            Assert.IsTrue(SequencesHelper.SortAndCheckAllValuesAreSequential(values));
        }

        [TestMethod()]
        public void AllValuesInSequence_OneValuesIsNotInSequence()
        {
            List<int> values = new List<int>();
            values.Add(0);
            values.Add(2);
            values.Add(3);
            values.Add(4);
            Assert.IsFalse(SequencesHelper.SortAndCheckAllValuesAreSequential(values));
        }

        [TestMethod()]
        public void AllValuesInSequence_EmptyList()
        {
            Assert.IsFalse(SequencesHelper.SortAndCheckAllValuesAreSequential(new List<int>()));
        }
        #endregion

        #region SortAndGetListWithBiggestSequence
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetHigherElementsInSequenceTest_NullValues()
        {
            SequencesHelper.SortAndGetListWithBiggestSequence(null, 3);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetHigherElementsInSequenceTest_EmptyList()
        {
            SequencesHelper.SortAndGetListWithBiggestSequence(new List<int>(), 0);
        }
        [TestMethod()]
        public void GetHigherElementsInSequenceTest_EmptyListValues()
        {
            Assert.AreEqual(null, SequencesHelper.SortAndGetListWithBiggestSequence(new List<int>(), 3));
        }

        [TestMethod()]
        public void GetHigherElementsInSequenceTest_ElementsToRetriveIsLessThanListValuesCount()
        {
            List<int> values = new List<int>();
            values.Add(1);
            Assert.AreEqual(null, SequencesHelper.SortAndGetListWithBiggestSequence(values, 3));
        }

        [TestMethod()]
        public void GetHigherElementsInSequenceTest_GetThreeSequenceCards()
        {
            List<int> values = new List<int>();
            values.Add(2);
            values.Add(10);
            values.Add(11);
            values.Add(12);
            values.Add(13);

            List<int> result = SequencesHelper.SortAndGetListWithBiggestSequence(values, 3);
            if (result.Count != 3)
                Assert.Fail();
            if (result[0] != 13)
                Assert.Fail();
            if (result[1] != 12)
                Assert.Fail();
            if (result[2] != 11)
                Assert.Fail();
        }

        [TestMethod()]
        public void GetHigherElementsInSequenceTest_AllInSequence()
        {
            List<int> values = new List<int>();
            values.Add(9);
            values.Add(10);
            values.Add(11);
            values.Add(12);
            values.Add(13);

            List<int> result = SequencesHelper.SortAndGetListWithBiggestSequence(values, 3);
            if (result.Count != 3)
                Assert.Fail();
            if (result[0] != 13)
                Assert.Fail();
            if (result[1] != 12)
                Assert.Fail();
            if (result[2] != 11)
                Assert.Fail();
        }

        [TestMethod()]
        public void GetHigherElementsInSequenceTest_AllInSequenceRetrieveAll()
        {
            List<int> values = new List<int>();
            values.Add(9);
            values.Add(10);
            values.Add(11);
            values.Add(12);
            values.Add(13);

            List<int> result = SequencesHelper.SortAndGetListWithBiggestSequence(values, 5);
            if (result.Count != 5)
                Assert.Fail();
            if (result[0] != 13)
                Assert.Fail();
            if (result[1] != 12)
                Assert.Fail();
            if (result[2] != 11)
                Assert.Fail();
            if (result[3] != 10)
                Assert.Fail();
            if (result[4] != 9)
                Assert.Fail();
        }
        #endregion
    }
}