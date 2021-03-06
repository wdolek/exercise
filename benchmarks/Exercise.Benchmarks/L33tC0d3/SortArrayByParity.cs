﻿using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using Exercise.L33tC0d3.SortArrayByParity;

namespace Exercise.Benchmarks.L33tC0d3
{
    [BenchmarkCategory("Sort array by parity")]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    public class SortArrayByParity
    {
        private readonly ParityArraySortator _sortator = new ParityArraySortator();
        private int[] _data = null!;

        [Params(4, 128, 512)]
        public int InputSize;

        [GlobalSetup]
        public void Setup()
        {
            var rnd = new Bogus.Randomizer(1234);
            _data = Enumerable
                .Range(0, InputSize)
                .Select(_ => rnd.Number(0, 100))
                .ToArray();
        }

        [Benchmark(Description = "In place", Baseline = true)]
        public int[] SortBySwap() => _sortator.SortArrayByParityInPlace(_data);

        [Benchmark(Description = "In place, unsafe")]
        public int[] SortBySwapUnsafe() => _sortator.SortArrayByParityUnsafe(_data);

        [Benchmark(Description = "In place, ref")]
        public int[] SortBySwapRefs() => _sortator.SortArrayByParityRefs(_data);

        [Benchmark(Description = "In place, ref Span<T>")]
        public int[] SortBySwapRefSpan() => _sortator.SortArrayByParityRefSpan(_data);

        [Benchmark(Description = "LINQ")]
        public int[] SortUsingLinq() => _sortator.SortArrayByParity(_data);
    }
}
