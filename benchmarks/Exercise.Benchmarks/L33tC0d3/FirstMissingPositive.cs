using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using Exercise.L33tC0d3.FirstMissingPositive;
using System.Collections.Generic;
using System.Linq;

namespace Exercise.Benchmarks.L33tC0d3
{
    [BenchmarkCategory("First missing positive")]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [MemoryDiagnoser]
    public class FirstMissingPositive
    {
        private readonly FirstMissingPositiveFinder _finder = new FirstMissingPositiveFinder();
        private int[] _data = null!;

        [ParamsSource(nameof(ValuesForB))]
        public (int ContinuousSequenceSize, int NegativeInts, int PositiveAboveInts) Params;

        public static IEnumerable<(int, int, int)> ValuesForB()
        {
            // first missing positive is 1, all negatives
            yield return (0, 10, 0);
            yield return (0, 1024, 0);

            // first missing positive is 1, all positive numbers in range [2,)
            yield return (0, 0, 10);
            yield return (0, 0, 1024);

            // first missing is (n + 1)
            yield return (10, 0, 0);
            yield return (1024, 0, 0);

            yield return (10, 10, 10);
            yield return (1024, 1024, 1024);
        }

        [GlobalSetup]
        public void Setup()
        {
            var rnd = new Bogus.Randomizer(1234);

            var negativeNumbers = Enumerable
                .Range(0, Params.NegativeInts)
                .Select(_ => rnd.Number(int.MinValue, -1));

            var positiveAboveStart = Params.ContinuousSequenceSize + 2;
            var positiveAboveRange = Enumerable
                .Range(0, Params.PositiveAboveInts)
                .Select(_ => rnd.Number(positiveAboveStart, int.MaxValue));

            _data = Enumerable
                .Range(1, Params.ContinuousSequenceSize)
                .Concat(negativeNumbers)
                .Concat(positiveAboveRange)
                .OrderBy(x => rnd.Int())
                .ToArray();
        }

        [Benchmark(Description = "Find using HashSet")]
        public int FindWithSet() => _finder.FirstMissingPositive(_data);

        [Benchmark(Description = "Find using BitArray")]
        public int FindWithBitArray() => _finder.FirstMissingPositiveWithBitArray(_data);

        [Benchmark(Description = "Find with min-max value")]
        public int FindWithMinMax() => _finder.FirstMissingPositiveWithMinMax(_data);

        [Benchmark(Description = "Find with Counting(x)")]
        public int FindWithCount() => _finder.FirstMissingPositiveWithoutExtraMemory(_data);

        [Benchmark(Description = "Find with Any(x)")]
        public int FindWithAny() => _finder.FirstMissingPositiveWithoutExtraMemoryUsingAny(_data);
    }
}
