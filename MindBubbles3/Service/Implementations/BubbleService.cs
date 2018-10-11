namespace MindBubbles3.Service.Implementations
{
    using MindBubbles3.Models;
    using MindBubbles3.Service.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class BubbleService : IBubbleService
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();
        private List<BubbleCreateModel> bubbleRawList, headings, orderedList;
        private bool thirdLevel;
        public List<BubbleCreateModel>[] listsArray;
        public int cellsNumber;

        public BubbleService()
        {
            bubbleRawList = new List<BubbleCreateModel>();
            headings = new List<BubbleCreateModel>();
            orderedList = new List<BubbleCreateModel>();

        }

        public BubblesList GenerateBubbles(InputStringModel inputStringModel)
        {
            thirdLevel = inputStringModel.ThirdLevel;
            CreateRawList(inputStringModel);
            db.ExistingBubbles.Add(new ExistingBubbles
            {
                ExistingInputString = inputStringModel.InputString
            });
            db.SaveChanges();

            return new BubblesList
            {
                ListArray = listsArray,
                TotalCellsNumber = cellsNumber,
                DbId = FindLastId()
            };
        }
        public int FindLastId()
        {
            var ex = db.ExistingBubbles;
            return ex.OrderByDescending(a => a.BubbleId).First().BubbleId;
        }

        public void AddImageToExistingBubble(int id, string image)
        {
            ExistingBubbles ex = db.ExistingBubbles.Find(id);
            ex.ExistingImage = image;
            db.Entry(ex).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void CreateRawList(InputStringModel inputStringModel)
        {


            string[] splittedArray = inputStringModel.InputString.Split('|');
            var regex = new Regex(@"\d+(\.\d+)*");

            foreach (var item in splittedArray)
            {
                if (item != "")
                {
                    string transformedText;
                    transformedText = new String(item.Where(c => c != '.' && (c < '0' || c > '9')).ToArray());

                    var number = regex.Matches(item)
                                      .Cast<Match>()
                                      .Select(match => match.Value)
                                      .FirstOrDefault(); // changed first to firstordefault in order to prevent crashes when wrong sequences are entered.
                    var bubbleToList = new BubbleCreateModel()
                    {
                        PlainTextInCell = transformedText,
                        OrderNumber = " " + number
                    };

                    bubbleRawList.Add(bubbleToList);
                }
            }
            OrderList(bubbleRawList);
        }

        public void OrderList(List<BubbleCreateModel> bubbleCreateModels)
        {
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
                if (thirdLevel)
                {
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
}