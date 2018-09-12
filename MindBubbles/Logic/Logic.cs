using MindBubbles.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace MindBubbles.Logic
{
    public class Logic
    {
        private List<BubbleCreateModel> bubbleRawList;
        public int cellsNumber;

        public BubblesList CreateBubbles(InputStringModel inputStringModel)
        {
            bubbleRawList = new List<BubbleCreateModel>();
            string[] splittedArray = inputStringModel.InputString.Split('|');
            var regex = new Regex(@"\d+(\.\d+)*");
            foreach (var item in splittedArray)
            {
                string transformedText;
                transformedText = new String(item.Where(c => c != '.' && (c < '0' || c > '9')).ToArray());

                var number = regex.Matches(item)
                                  .Cast<Match>()
                                  .Select(match => match.Value)
                                  .First();
                var bubbleToList = new BubbleCreateModel()
                {
                    PlainTextInCell = transformedText,
                    OrderNumber = " " + number


                };

                bubbleRawList.Add(bubbleToList);

            }
            List<BubbleCreateModel> orderedList = new List<BubbleCreateModel>();
            orderedList = bubbleRawList.OrderBy(p => p.OrderNumber).ToList();
            var highestNumber = orderedList.Last().OrderNumber;

            cellsNumber = Int32.Parse(Regex.Match(highestNumber, @" \d+").ToString());

            return GenerateLists(orderedList);

        }

        public BubblesList GenerateLists(List<BubbleCreateModel> bubbleCreateModels)
        {

            var filterRegex = "";
            List<BubbleCreateModel>[] listsArray = new List<BubbleCreateModel>[cellsNumber];
            for (int i = 0; i < cellsNumber; i++)
            {
                filterRegex = i.ToString();
                var regexDotPattern = new Regex($@" {i + 1}(\.\d+)*");

                listsArray[i] = bubbleCreateModels.Where(a => regexDotPattern.IsMatch(a.OrderNumber)).ToList();
            }


            return new BubblesList
            {
                ListArray = listsArray,
                TotalCellsNumber = cellsNumber
            };

        }
    }
}