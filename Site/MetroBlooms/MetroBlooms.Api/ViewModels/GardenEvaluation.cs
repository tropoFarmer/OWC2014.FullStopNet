using System;
using System.Collections.Generic;
using System.Linq;

using MetroBlooms.Api.JsonConverters;
using MetroBlooms.Api.ViewModels.GardenViewModels;

using Newtonsoft.Json;

namespace MetroBlooms.Api.ViewModels
{
    public class GardenEvaluation
    {
        public int Evaluation_Id { get; set; }

        [JsonConverter(typeof(BoolConverter))]
        public bool Completed { get; set; }

        public string Eval_Type { get; set; }
        public int Score { get; set; }
        public string Rating { get; set; }
        public int Rating_Year { get; set; }
        public string Best_Of { get; set; }
        public string Special_Award_Specified { get; set; }

        [JsonConverter(typeof(BoolConverter))]
        public bool Nate_Siegel_Award { get; set; }

        [JsonConverter(typeof(BoolConverter))]
        public bool Rainbarrel { get; set; }

        [JsonConverter(typeof(BoolConverter))]
        public bool Downspouts_Redirected { get; set; }

        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? Date_Assigned { get; set; }

        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? Date_Evaluated { get; set; }

        public string Comments { get; set; }
        public string Revisit { get; set; }
        public string Evaluator_Name { get; set; }
        public string Evaluator_Id { get; set; }
        public string Evaluator_Assigned { get; set; }
        public Garden Garden { get; set; }
    }
}