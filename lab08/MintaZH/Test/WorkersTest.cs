using MintaZH;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    [TestFixture]
    public class WorkersTest
    {
        public static IEnumerable<TestCaseData> FakeData
        {
            get
            {
                var testCases = new List<TestCaseData>();

                var input = new List<Worker>
                {
                    new Worker { Children = 1 },
                    new Worker { Children = 3 },
                    new Worker { Children = 2 },
                    new Worker { Children = 0 },
                    new Worker { Children = 37 },
                    new Worker { Children = -8 },
                };

                var expected = new List<Worker>
                {
                    new Worker { Children = 3 },
                    new Worker { Children = 37 },
                };
                testCases.Add(new TestCaseData(new object[] { input, expected }));

                return testCases;
            }
        }

        [TestCaseSource(nameof(FakeData))]
        public void WorkerFilterTest(List<Worker> workers, List<Worker> expected)
        {
            // Act
            var actual = WorkerFilter.Filter(workers).ToList();

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
