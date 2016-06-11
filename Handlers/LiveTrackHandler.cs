using IndianCitizenService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IndianCitizenService.Handler
{
    public class LiveTrackHandler
    {
        public List<RenderMapDetail> getVoteDetail(IList<VoteDetail> voteDetail)
        {
            //voteDetail.Add(new VoteDetail()
            //{
            //    Id = 100,
            //    GradeValue = 100,
            //    LocationDetail = locationDetail
            //});
            //voteDetail.Add(new VoteDetail()
            //{
            //    Id = 100,
            //    GradeValue = 75,
            //    LocationDetail = locationDetail
            //});
            //voteDetail.Add(new VoteDetail()
            //{
            //    Id = 100,
            //    GradeValue = 75,
            //    LocationDetail = locationDetail
            //});
            //voteDetail.Add(new VoteDetail()
            //{
            //    Id = 100,
            //    GradeValue = 100,
            //    LocationDetail = locationDetail
            //});

            return getModel(voteDetail);
        }

        private List<RenderMapDetail> getModel(IList<VoteDetail> voteDetail)
        {
            long totalGrade = 0;
            long totalVote = 0;
            List<RenderMapDetail> renderMapDetails = new List<RenderMapDetail>();
            if (!voteDetail.Any())
                return renderMapDetails;
            var locationDetail = voteDetail[0].LocationDetail;
            foreach (var item in voteDetail)
            {
                var temp = Convert.ToInt64(item.GradeValue.ToString());
                totalGrade += temp;
                totalVote++;
            }
            var average = totalGrade / totalVote;
            renderMapDetails.Add(new RenderMapDetail()
            {
                ColorIndex = getColorIndex(average),
                LocLalitudeStart = locationDetail.LocLalitudeStart,
                LocLalitudeEnd = locationDetail.LocLalitudeEnd,
                LocLongitudeStart = locationDetail.LocLongitudeStart,
                LocLongitudeEnd = locationDetail.LocLongitudeEnd
            });
            return renderMapDetails;
        }

        private int getColorIndex(long average)
        {
            if (average > 75)
                return 4;
            else if (average > 50)
                return 2;
            else if (average > 25)
                return 3;
            else
                return 1;
        }

        public static int getGrade(int category)
        {
            if (category == 4)
                return 100;

            else if (category == 2)
                return 75;

            else if (category == 3)
                return 50;

            else if (category == 1)
                return 25;

            else
                return 0;
        }
    }
}
