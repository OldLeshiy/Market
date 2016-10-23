using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess;
using Model;

namespace BusinessLogic
{
    public class BarManager
    {
        public void Add(Bar bar)
        {
            using (var ctx = new MarketDbContext())
            {
                var repository = new BarRepository(ctx);
                repository.Add(bar);
                ctx.SaveChanges();
            }
        }

        public void AddRange(IEnumerable<Bar> range)
        {
            using (var ctx = new MarketDbContext())
            {
                var repository = new BarRepository(ctx);
                foreach (var bar in range)
                {
                    repository.Add(bar);
                }
                ctx.SaveChanges();
            }
        }

        public void Update(Bar bar)
        {
            using (var ctx = new MarketDbContext())
            {
                var repository = new BarRepository(ctx);
                repository.Update(bar);
                ctx.SaveChanges();
            }
        }

        public List<Bar> Get(string symbol, DateTime dateTimeFrom, DateTime dateTimeTo, Interval interval)
        {
            List<Bar> barList;
            using (var ctx = new MarketDbContext())
            {
                var repository = new BarRepository(ctx);

                barList = repository.Get()
                    .Where(c => c.Symbol == symbol
                    && (c.TimeStamp >= dateTimeFrom)
                    && (c.TimeStamp <= dateTimeTo))
                    .OrderBy(c => c.TimeStamp)
                    .ToList();
            }
            if (barList.Count == 0)
            {
                return null;
            }

            var sortList = new List<Bar>();
            var intervalIterator = (int)interval;
            var baseTime = barList[0].TimeStamp.Date;
            do
            {
                var sort = barList.Where(b => (b.TimeStamp - baseTime).TotalMinutes < intervalIterator).ToList();
                if (sort.Count != 0)
                {
                    barList.RemoveRange(0, sort.Count);
                    var bar = new Bar
                    {
                        TimeStamp = sort[0].TimeStamp,
                        Symbol = sort[0].Symbol,
                        Low = sort[0].Low,
                        High = sort[0].High
                    };
                    foreach (var s in sort)
                    {
                        bar.Open += s.Open;
                        bar.Close += s.Close;
                        if (bar.Low > s.Low) bar.Low = s.Low;
                        if (bar.High < s.High) bar.High = s.High;
                    }
                    bar.Open = bar.Open / sort.Count;
                    bar.Close = bar.Close / sort.Count;
                    sortList.Add(bar);
                }
                intervalIterator += (int)interval;
            } while (barList.Count != 0);
            return sortList;
        }
    }
}