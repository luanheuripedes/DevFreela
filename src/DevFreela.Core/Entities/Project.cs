﻿using DevFreela.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Core.Entities
{
    public class Project: BaseEntity
    {
        public Project()
        {
            Title = string.Empty;
            Description = string.Empty;
            IdClient = 0;
            IdFreelancer = 0;
            TotalCost = 0.0M;

            CreatedAt = DateTime.Now;
            Status = ProjectStatusEnum.Created;
            Comments = new List<ProjectComment>();
        }
        public Project(string title, string description, int idClient, int idFreelancer, decimal totalCost)
        {
            Title = title;
            Description = description;
            IdClient = idClient;
            IdFreelancer = idFreelancer;
            TotalCost = totalCost;

            CreatedAt = DateTime.Now;
            Status = ProjectStatusEnum.Created;
            Comments = new List<ProjectComment>();
        }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public decimal TotalCost { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? StartedAt { get; private set; }
        public DateTime FinishedAt { get; private set; }
        public ProjectStatusEnum Status { get; private set; }
        

        public int IdClient { get; private set; }
        public int IdFreelancer { get; private set; }


        //Navegação
        public List<ProjectComment> Comments { get; private set; }
        public User Client { get; private set; }
        public User Freelancer { get; private set; }

        public void SetPaymentPending()
        {
            Status = ProjectStatusEnum.Pending;
        }
        public void CancelProject()
        {
            if(Status == ProjectStatusEnum.InProgress || Status == ProjectStatusEnum.InProgress)
            {
                Status = ProjectStatusEnum.Cancelled;
            }
        }

        public void FinishProject()
        {
            if (Status == ProjectStatusEnum.Pending)
            {
                Status = ProjectStatusEnum.Finished;
                FinishedAt = DateTime.Now;
            }
        }

        public void StartProject()
        {
            if(Status == ProjectStatusEnum.Created)
            {
                Status = ProjectStatusEnum.InProgress;
                StartedAt = DateTime.Now;
            }
        }

        public void Update(string title, string description, decimal totalCost)
        {
            Title = title;
            Description = description;
            TotalCost = totalCost;

        }
    }
}
