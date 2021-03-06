﻿using ConStrServer.Models.Dbo;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ConStrServer.Models.Dto
{
    [DataContract]
    public class ProjectModel
    {
        [DataMember(Name = "ProjectId")]
        public int ProjectId { get; set; }

        [DataMember(Name = "ProjectName")]
        public string ProjectName { get; set; }

        [DataMember(Name = "ProjectOwner")]
        public string ProjectOwner { get; set; }

        [DataMember(Name = "Environments")]
        public virtual List<EnvironmentInfoModel> Environments { get; set; }

    }
}



//Projects
////Env
/// //Maichines
/// ////ConnectionStrings