using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Technician";
        job1._company = "IBM";
        job1._startYear = 2000;
        job1._endYear = 2003;

        Job job2 = new Job();
        job2._jobTitle = "Project Manager Assistant";
        job2._company = "Nokia";
        job2._startYear = 2003;
        job2._endYear = 2005;

        Resume myResume = new Resume();
        myResume._name = "Dulio Delgado";
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();
    }
}