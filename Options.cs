using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CommandLine;
using CommandLine.Text;

namespace IB.PriceFetcher
{
    public class Options
    {
        [Option('s', "symbol", Required = true, HelpText = "Input stock symbo to process.")]
        public string Symbol { get; set; }

        [Option('e', "end-date", Required = true, HelpText = "Input end date to process. Format: yyyyMMdd HH:mm:ss. Example: 20131009 23:59:59")]
        public string EndDate { get; set; }

        [Option('d', "duration", Required = true, HelpText = "Input duration to process. Duration unit: S, D, W, M, Y")]
        public string Duration { get; set; }

        [Option('b', "bar-size", Required = false, DefaultValue = "1 min", HelpText = "Input duration to process. Valid bar size: 1 sec, 5 secs, 15 secs, 30 secs, 1 min, 2 mins, 3 mins, 5 mins, 15 mins, 30 mins, 1 hour, 1 day")]
        public string BarSize { get; set; }

        [ParserState]
        public IParserState LastParserState { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            return HelpText.AutoBuild(this,
              (HelpText current) => HelpText.DefaultParsingErrorsHandler(this, current));
        }
    }
}
