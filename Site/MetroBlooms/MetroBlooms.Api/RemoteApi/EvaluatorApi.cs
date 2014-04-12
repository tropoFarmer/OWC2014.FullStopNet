using System;
using System.Collections.Generic;
using System.Linq;

using MetroBlooms.Api.ViewModels;

namespace MetroBlooms.Api.RemoteApi
{
    public class EvaluatorApi : ApiBase
    {
        public EvaluatorApi(string userName, string password) : base(userName, password)
        {
        }

        public GardenEvaluation GetByEvaluationId(int evaluationId)
        {
            return GetSingleFromList<GardenEvaluation>(string.Format("evaluation/evaluation_id/{0}", evaluationId));
        }

        public List<GardenEvaluation> GetByGardenId(int gardenId)
        {
            return GetList<GardenEvaluation>(string.Format("evaluation/garden_id/{0}", gardenId));
        }

        public List<GardenEvaluation> GetByEvaluatorId(int evaluatorId)
        {
            return GetList<GardenEvaluation>(string.Format("evaluation/evaluator_id/{0}", evaluatorId));
        }
    }
}