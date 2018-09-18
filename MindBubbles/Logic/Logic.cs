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
        private List<BubbleCreateModel> headings;
        private List<BubbleCreateModel> sortedHeadings;


        public List<BubbleCreateModel>[] listsArray;
        public int cellsNumber;
        //creates raw list without any order or sort
        public BubblesList GenerateBubbles(InputStringModel inputStringModel)
        {
            CreateRawList(inputStringModel);
            return new BubblesList
            {
                ListArray = listsArray,
                TotalCellsNumber = cellsNumber
            };
        }

        public void CreateRawList(InputStringModel inputStringModel)
        {
            bubbleRawList = new List<BubbleCreateModel>();
            headings = new List<BubbleCreateModel>();

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

            OrderList(bubbleRawList);
        }

        public void OrderList(List<BubbleCreateModel> bubbleCreateModels)
        {
            List<BubbleCreateModel> orderedList = new List<BubbleCreateModel>();
            orderedList = bubbleCreateModels;

            foreach (var item in bubbleRawList)
            {
                var isHeading = int.TryParse(item.OrderNumber, out int n);
                if (isHeading)
                {
                    headings.Add(item);
                }

            }
            cellsNumber = headings.Count();

            foreach (var item in orderedList)
            {
                item.ThirdLevelList = new List<BubbleCreateModel>();
            }

            GenerateListsForEachColumn(orderedList);
        }

        public void GenerateListsForEachColumn(List<BubbleCreateModel> bubbleCreateModels)
        {
            var filterRegex = "";
            listsArray = new List<BubbleCreateModel>[cellsNumber];
            for (int i = 0; i < cellsNumber; i++)
            {
                filterRegex = i.ToString();
                // if you decide to remove space from a = a.ordernumber use ^ to make sure regex will take only numbers related i.e if you have 1 it won't take 11 and so on
                var regexDotPattern = new Regex($@"{headings[i].OrderNumber}(\.\d+)?$");

                listsArray[i] = bubbleCreateModels.Where(a => regexDotPattern.IsMatch(a.OrderNumber)).ToList();

                var thirdLevelRegex = new Regex($@"{headings[i].OrderNumber}(\.\d+){{2}}$");
                var thirdLevelsList = bubbleCreateModels.Where(b => thirdLevelRegex.IsMatch(b.OrderNumber)).ToList();
                foreach (var itm in thirdLevelsList)
                {
                    var parentExpression = Regex.Match(itm.OrderNumber, @" \d+.*(?=\.)").ToString();
                    var parentObject = listsArray[i].First(o => o.OrderNumber == parentExpression);
                    parentObject.ThirdLevelList.Add(itm);
                }
            }
        }
    }
}