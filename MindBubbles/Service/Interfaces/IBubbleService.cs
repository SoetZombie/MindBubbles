using MindBubbles.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindBubbles.Service.Interfaces
{
   public interface IBubbleService
    {
        void GenerateListsForEachColumn(List<BubbleCreateModel> bubbleCreateModels);

        void OrderList(List<BubbleCreateModel> bubbleCreateModels);

        void CreateRawList(InputStringModel inputStringModel);

        BubblesList GenerateBubbles(InputStringModel inputStringModel);

        void AddImageToExistingBubble(int id, string image);
    }
}
