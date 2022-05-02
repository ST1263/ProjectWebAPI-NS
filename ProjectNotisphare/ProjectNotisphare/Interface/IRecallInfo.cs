using ProjectNS.Model;
using ProjectNS.ViewModel;
using System.Collections.Generic;

namespace ProjectNS.Interface
{
    public interface IRecallInfo
    {
        public List<RecallInfoVM> RecallInfos();
        public RecallInfo RecallInfoById(int RecallinfoId);
        public RecallInfo AddRecallInfo(RecallInfo recallInfo);
        public RecallInfo UpdateRecallInfo(RecallInfo recallInfo);
        public void DeleteRecallInfo(int RecallinfoId);
    }
}
