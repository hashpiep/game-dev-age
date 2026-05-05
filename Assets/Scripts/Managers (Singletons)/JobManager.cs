using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class JobManager : MonoBehaviour
{
    private List<Job> jobs = new List<Job>();
    private static JobManager instance;
    public static JobManager Instance { get { return instance; } }
    private void Start()
    {
        instance = this;
    }
    public void CreateJob(string name, float pay)
    {
        Job job = new Job($"{Guid.NewGuid().ToString()}_job", name, pay);

        jobs.Add(job);
    }
    public List<Job> GetJobs()
    {
        return jobs;
    }
    public Job GetJobFromID(string id)
    {
        return jobs.Where(job => job.ID == id).FirstOrDefault();
    }
}